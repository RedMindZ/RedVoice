using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using MFWrapper;

namespace RedVoice.Loaders
{
    public class PcmAudioProvider : IDisposable
    {
        private SimplePcmAudioReader _pcmReader;

        private bool _keepProducing;
        private Thread _loadingThread;
        private BlockingCollection<float[]> _samplesBuffer;
        private readonly int _maxBufferedSamples;
        private readonly int _sampleSize;

        public int AvailableSamples => _samplesBuffer == null ? 0 : _samplesBuffer.Count;
        public bool IsCompleted => _samplesBuffer == null ? true : _samplesBuffer.IsCompleted;

        public PcmAudioProvider(string url, int sampleSize, int maxBufferedSamples)
        {
            _pcmReader = new SimplePcmAudioReader(url, null);
            _maxBufferedSamples = maxBufferedSamples;
            _sampleSize = sampleSize;
        }

        public void StartLoading()
        {
            if (_loadingThread == null)
            {
                _loadingThread = new Thread(LoadSamples);
                _samplesBuffer = new BlockingCollection<float[]>(_maxBufferedSamples);
                _keepProducing = true;
                _loadingThread.Start();
            }
        }

        public void StopLoading()
        {
            if (_loadingThread != null)
            {
                _keepProducing = false;
                _loadingThread.Join();
                _samplesBuffer.Dispose();

                _loadingThread = null;
                _samplesBuffer = null;
            }
        }

        public float[] GetNextSample()
        {
            if (_samplesBuffer != null)
            {
                return _samplesBuffer.Take();
            }
            else
            {
                throw new InvalidOperationException("Can not take samples while the provider is stopped.");
            }
        }

        private void LoadSamples()
        {
            float[] buffer = new float[_sampleSize];
            int bufferIndex = 0;

            while (_keepProducing && _pcmReader.TryGetNextSample(out object sampleData))
            {
                if (_pcmReader.BitsPerSample == 8)
                {
                    byte[] data = (byte[])sampleData;
                    int dataIndex = 0;

                    while (dataIndex < data.Length)
                    {
                        int samplesToCopy = Math.Min(buffer.Length - bufferIndex, data.Length - dataIndex);

                        for (int i = 0; i < samplesToCopy; i++)
                        {
                            buffer[bufferIndex] = (float)data[dataIndex] / byte.MaxValue;

                            bufferIndex++;
                            dataIndex++;
                        }

                        if (bufferIndex == buffer.Length)
                        {
                            _samplesBuffer.Add(buffer);

                            bufferIndex = 0;
                            buffer = new float[_sampleSize];
                        }
                    }
                }

                else if (_pcmReader.BitsPerSample == 16)
                {
                    short[] data = (short[])sampleData;
                    int dataIndex = 0;

                    while (dataIndex < data.Length)
                    {
                        int samplesToCopy = Math.Min(buffer.Length - bufferIndex, data.Length - dataIndex);

                        for (int i = 0; i < samplesToCopy; i++)
                        {
                            buffer[bufferIndex] = (float)data[dataIndex] / short.MaxValue;

                            bufferIndex++;
                            dataIndex++;
                        }

                        if (bufferIndex == buffer.Length)
                        {
                            _samplesBuffer.Add(buffer);

                            bufferIndex = 0;
                            buffer = new float[_sampleSize];
                        }
                    }
                }

                else if (_pcmReader.BitsPerSample == 32)
                {
                    int[] data = (int[])sampleData;
                    int dataIndex = 0;

                    while (dataIndex < data.Length)
                    {
                        int samplesToCopy = Math.Min(buffer.Length - bufferIndex, data.Length - dataIndex);

                        for (int i = 0; i < samplesToCopy; i++)
                        {
                            buffer[bufferIndex] = (float)data[dataIndex] / int.MaxValue;

                            bufferIndex++;
                            dataIndex++;
                        }

                        if (bufferIndex == buffer.Length)
                        {
                            _samplesBuffer.Add(buffer);

                            bufferIndex = 0;
                            buffer = new float[_sampleSize];
                        }
                    }
                }
            }

            if (bufferIndex > 0)
            {
                _samplesBuffer.Add(buffer);
            }

            _samplesBuffer.CompleteAdding();
        }

        public void Dispose()
        {
            StopLoading();
        }
    }
}
