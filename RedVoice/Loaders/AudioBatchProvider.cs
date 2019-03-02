using CNTK;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RedVoice.Loaders
{
    public class AudioBatchProvider : IDisposable
    {
        private string[][] _urlSources;
        private int[] _sourcesIndices;
        private PcmAudioProvider[] _audioProviders;
        private readonly bool _loopSources;

        private bool _keepProducing;
        private Thread _batchingThread;
        private BlockingCollection<Value> _batchesBuffer;
        private readonly int _maxBufferedBatches;
        private readonly int _sampleSize;
        private readonly DeviceDescriptor _computeDevice;

        public int AvailableSamples => _batchesBuffer == null ? 0 : _batchesBuffer.Count;
        public bool IsCompleted => _batchesBuffer == null ? true : _batchesBuffer.IsCompleted;

        public AudioBatchProvider(string[][] urlSources, bool loopSources, int sampleSize, int maxBufferedBatches, DeviceDescriptor computeDevice)
        {
            _urlSources = new string[urlSources.Length][];

            for (int i = 0; i < _urlSources.Length; i++)
            {
                if (urlSources[i].Length < 1)
                {
                    throw new ArgumentException("All of the arrays must contain at least one string.");
                }

                _urlSources[i] = new string[urlSources[i].Length];
                Array.Copy(urlSources[i], _urlSources[i], urlSources[i].Length);
            }

            _maxBufferedBatches = maxBufferedBatches;
            _sampleSize = sampleSize;
            _computeDevice = computeDevice;
            _loopSources = loopSources;
        }

        public void StartBatching()
        {
            if (_batchingThread == null)
            {
                _batchingThread = new Thread(CreateBatches);
                _batchesBuffer = new BlockingCollection<Value>(_maxBufferedBatches);

                _sourcesIndices = new int[_urlSources.Length];
                _audioProviders = new PcmAudioProvider[_urlSources.Length];

                for (int i = 0; i < _audioProviders.Length; i++)
                {
                    _audioProviders[i] = new PcmAudioProvider(_urlSources[i][_sourcesIndices[i]], _sampleSize, 4);
                    _audioProviders[i].StartLoading();
                }

                _keepProducing = true;
                _batchingThread.Start();
            }
        }

        public Value GetNextBatch()
        {
            if (_batchesBuffer != null)
            {
                return _batchesBuffer.Take();
            }
            else
            {
                throw new InvalidOperationException("Can not take batches while the provider is stopped.");
            }
        }

        public void StopBatching()
        {
            if (_batchingThread != null)
            {
                _keepProducing = false;
                _batchingThread.Join();
                _batchesBuffer.Dispose();

                for (int i = 0; i < _audioProviders.Length; i++)
                {
                    if (_audioProviders[i] != null)
                    {
                        _audioProviders[i].Dispose();
                        _audioProviders[i] = null;
                    }
                }

                _sourcesIndices = null;
                _audioProviders = null;
                _batchesBuffer = null;
                _batchingThread = null;
            }
        }

        private void CreateBatches()
        {
            while(_keepProducing)
            {
                for (int i = 0; i < _audioProviders.Length; i++)
                {
                    if (_audioProviders[i].IsCompleted && _audioProviders[i].AvailableSamples == 0)
                    {
                        _audioProviders[i].Dispose();
                        _audioProviders[i] = null;
                        _sourcesIndices[i]++;

                        if (_sourcesIndices[i] >= _urlSources[i].Length)
                        {
                            if (_loopSources)
                            {
                                _sourcesIndices[i] = 0;
                            }
                            else
                            {
                                _keepProducing = false;
                                break;
                            } 
                        }

                        _audioProviders[i] = new PcmAudioProvider(_urlSources[i][_sourcesIndices[i]], _sampleSize, 4);
                        _audioProviders[i].StartLoading();
                    }
                }

                if (!_keepProducing)
                {
                    break;
                }

                float[] batchData = new float[_urlSources.Length * _sampleSize];

                for (int i = 0; i < _audioProviders.Length; i++)
                {
                    float[] sample = _audioProviders[i].GetNextSample();
                    Array.Copy(sample, 0, batchData, _sampleSize * i, _sampleSize);
                }

                NDArrayView batchView = new NDArrayView(NDShape.CreateNDShape(new int[2] { _urlSources.Length, _sampleSize }), batchData, _computeDevice);
                _batchesBuffer.Add(new Value(batchView));
            }

            for (int i = 0; i < _audioProviders.Length; i++)
            {
                if (_audioProviders[i] != null)
                {
                    _audioProviders[i].Dispose();
                    _audioProviders[i] = null;
                }
            }

            _batchesBuffer.CompleteAdding();
        }

        public void Dispose()
        {
            StopBatching();
        }
    }
}
