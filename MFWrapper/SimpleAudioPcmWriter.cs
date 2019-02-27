using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MFWrapper
{
    public class SimpleAudioPcmWriter
    {
        private readonly MFSinkWriter _sinkWriter;
        private uint _currentStreamIndex;
        private long _currentSampleTime = 0;

        public uint SamplesPerSecond { get; }
        public uint BitsPerSample { get; }
        public uint ChannelsCount { get; }

        public SimpleAudioPcmWriter(string url, MFMediaType inputType)
        {
            MFAttributes attributes = new MFAttributes(1);
            attributes.SetUINT32(MFGuids.MF_SINK_WRITER_DISABLE_THROTTLING, 1);
            _sinkWriter = new MFSinkWriter(url, attributes);

            inputType.GetUINT32(MFGuids.MF_MT_AUDIO_SAMPLES_PER_SECOND, out uint spm);
            SamplesPerSecond = spm;

            inputType.GetUINT32(MFGuids.MF_MT_AUDIO_BITS_PER_SAMPLE, out uint bps);
            BitsPerSample = bps;

            inputType.GetUINT32(MFGuids.MF_MT_AUDIO_NUM_CHANNELS, out uint nc);
            ChannelsCount = nc;

            _sinkWriter.AddStream(inputType, out _currentStreamIndex);
            _sinkWriter.SetInputMediaType(_currentStreamIndex, inputType, null);
        }

        public void BeginWriting()
        {
            _sinkWriter.BeginWriting();
            _currentSampleTime = 0;
        }

        public void WriteSample(object sampleData)
        {
            MFMediaBuffer buffer = null;
            long sampleDuration = 0;

            if (BitsPerSample == 8)
            {
                byte[] data = (byte[])sampleData;

                buffer = new MFMediaBuffer((uint)data.Length * 1);
                buffer.Lock(out IntPtr bufferPtr, out uint bufferLength, out uint _);
                Marshal.Copy(data, 0, bufferPtr, data.Length);
                buffer.Unlock();
                buffer.SetCurrentLength((uint)data.Length * 1);

                sampleDuration = (long)Math.Round((10_000_000D * data.Length) / (ChannelsCount * SamplesPerSecond));
            }
            else if (BitsPerSample == 16)
            {
                short[] data = (short[])sampleData;

                buffer = new MFMediaBuffer((uint)data.Length * 2);
                buffer.Lock(out IntPtr bufferPtr, out uint bufferLength, out uint _);
                Marshal.Copy(data, 0, bufferPtr, data.Length);
                buffer.Unlock();
                buffer.SetCurrentLength((uint)data.Length * 2);

                sampleDuration = (long)Math.Round((10_000_000D * data.Length) / (ChannelsCount * SamplesPerSecond));
            }
            else if (BitsPerSample == 32)
            {
                int[] data = (int[])sampleData;

                buffer = new MFMediaBuffer((uint)data.Length * 4);
                buffer.Lock(out IntPtr bufferPtr, out uint bufferLength, out uint _);
                Marshal.Copy(data, 0, bufferPtr, data.Length);
                buffer.Unlock();
                buffer.SetCurrentLength((uint)data.Length * 4);

                sampleDuration = (long)Math.Round((10_000_000D * data.Length) / (ChannelsCount * SamplesPerSecond));
            }

            MFSample sample = new MFSample();
            sample.AddBuffer(buffer);
            
            sample.SetSampleTime(_currentSampleTime);
            sample.SetSampleDuration(sampleDuration);
            _currentSampleTime += sampleDuration;

            _sinkWriter.WriteSample(_currentStreamIndex, sample);

            buffer.Dispose();
            sample.Dispose();
        }

        public void FinalizeWriter()
        {
            _sinkWriter.FinalizeWriter();
        }
    }
}
