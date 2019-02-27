using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MFWrapper
{
    public class SimpleAudioPcmReader
    {
        private readonly MFSourceReader _sourceReader;
        private uint _currentStreamIndex;

        public uint BitsPerSample { get; private set; }
        public uint ChannelsCount { get; private set; }

        public SimpleAudioPcmReader(string url, MFAttributes attributes)
        {
            _sourceReader = new MFSourceReader(url, attributes);
            SetActiveStream(MFGuids.MF_SOURCE_READER_FIRST_AUDIO_STREAM);
        }

        public void SetActiveStream(uint streamIndex)
        {
            _currentStreamIndex = streamIndex;

            _sourceReader.SetStreamSelection(MFGuids.MF_SOURCE_READER_ALL_STREAMS, false);
            _sourceReader.SetStreamSelection(_currentStreamIndex, true);

            MFMediaType pcmMT = new MFMediaType();
            pcmMT.SetGUID(MFGuids.MF_MT_MAJOR_TYPE, MFGuids.MFMediaType_Audio);
            pcmMT.SetGUID(MFGuids.MF_MT_SUBTYPE, MFGuids.MFAudioFormat_PCM);
            _sourceReader.SetCurrentMediaType(_currentStreamIndex, pcmMT);

            UpdateBitsPerSample();
            UpdateChannelsCount();
        }

        public MFMediaType GetMediaType()
        {
            _sourceReader.GetCurrentMediaType(_currentStreamIndex, out MFMediaType mt);
            return mt;
        }

        private void UpdateBitsPerSample()
        {
            _sourceReader.GetCurrentMediaType(_currentStreamIndex, out MFMediaType mt);
            mt.GetUINT32(MFGuids.MF_MT_AUDIO_BITS_PER_SAMPLE, out uint bitsPerSample);
            BitsPerSample = bitsPerSample;
        }

        private void UpdateChannelsCount()
        {
            _sourceReader.GetCurrentMediaType(_currentStreamIndex, out MFMediaType mt);
            mt.GetUINT32(MFGuids.MF_MT_AUDIO_NUM_CHANNELS, out uint channelsCount);
            ChannelsCount = channelsCount;
        }

        public bool TryGetNextSample(out object sampleData)
        {
            sampleData = null;

            MFSample sample;
            MFSourceReaderFlag readerFlags;
            _sourceReader.ReadSample(MFGuids.MF_SOURCE_READER_FIRST_AUDIO_STREAM, MFSourceReaderControlFlag.None, out uint _, out readerFlags, out long _, out sample);

            while (sample.NativePointer == IntPtr.Zero && ((readerFlags & MFSourceReaderFlag.EndOfStream) != MFSourceReaderFlag.EndOfStream))
            {
                _sourceReader.ReadSample(MFGuids.MF_SOURCE_READER_FIRST_AUDIO_STREAM, MFSourceReaderControlFlag.None, out uint _, out readerFlags, out long _, out sample);
            }

            if ((readerFlags & MFSourceReaderFlag.EndOfStream) == MFSourceReaderFlag.EndOfStream)
            {
                return false;
            }

            sample.ConvertToContiguousBuffer(out MFMediaBuffer buffer);
            buffer.Lock(out IntPtr bufferPtr, out uint _, out uint bufferLength);

            if (BitsPerSample == 8)
            {
                byte[] managedBuffer = new byte[bufferLength];
                Marshal.Copy(bufferPtr, managedBuffer, 0, managedBuffer.Length);
                sampleData = managedBuffer;
            }
            else if (BitsPerSample == 16)
            {
                short[] managedBuffer = new short[bufferLength / 2];
                Marshal.Copy(bufferPtr, managedBuffer, 0, managedBuffer.Length);
                sampleData = managedBuffer;
            }
            else if (BitsPerSample == 32)
            {
                int[] managedBuffer = new int[bufferLength / 4];
                Marshal.Copy(bufferPtr, managedBuffer, 0, managedBuffer.Length);
                sampleData = managedBuffer;
            }

            buffer.Unlock();

            buffer.Dispose();
            sample.Dispose();

            return true;
        }
    }
}
