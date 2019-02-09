using System;
using System.Text;

namespace Voice
{
    public static class WavConvert
    {
        public const int HeaderSize = 44;
        private const float RescaleFactor = 32767; //to convert float to Int16

        public static byte[] Convert(AudioData audioData)
        {
            var bytes = new byte[audioData.SampleCount * 2 + HeaderSize];
            var data = ConvertAndWrite(audioData, bytes);

            WriteHeader(audioData, data);

            return bytes;
        }

        private static byte[] ConvertAndWrite(AudioData audioData, byte[] bytes)
        {
            var p = HeaderSize;
            for (var c = 0; c < audioData.SampleCount; c++)
            {
                var i = (audioData.VoiceStartPos + c) % audioData.Samples.Length;
                var value = (short)(audioData.Samples[i] * RescaleFactor);
                bytes[p++] = (byte)(value >> 0);
                bytes[p++] = (byte)(value >> 8);
            }

            return bytes;
        }

        private static void AddDataToBuffer(byte[] buffer, ref uint offset, byte[] addBytes)
        {
            foreach (var b in addBytes) buffer[offset++] = b;
        }

        private static void WriteHeader(AudioData audioData, byte[] data)
        {
            int samples = audioData.SampleCount;
            ushort channels = (ushort) audioData.Channels;
            var offset = 0u;

            var riff = Encoding.UTF8.GetBytes("RIFF");
            AddDataToBuffer(data, ref offset, riff);

            var chunkSize = BitConverter.GetBytes(data.Length - 8);
            AddDataToBuffer(data, ref offset, chunkSize);

            var wave = Encoding.UTF8.GetBytes("WAVE");
            AddDataToBuffer(data, ref offset, wave);

            var fmt = Encoding.UTF8.GetBytes("fmt ");
            AddDataToBuffer(data, ref offset, fmt);

            var subChunk1 = BitConverter.GetBytes(16u);
            AddDataToBuffer(data, ref offset, subChunk1);

            const ushort two = 2;
            const ushort one = 1;

            var audioFormat = BitConverter.GetBytes(one);
            AddDataToBuffer(data, ref offset, audioFormat);

            var numChannels = BitConverter.GetBytes(channels);
            AddDataToBuffer(data, ref offset, numChannels);

            var sampleRate = BitConverter.GetBytes(audioData.Frequency);
            AddDataToBuffer(data, ref offset, sampleRate);

            var byteRate = BitConverter.GetBytes(audioData.Frequency * channels *2);
            AddDataToBuffer(data, ref offset, byteRate);

            var blockAlign = (ushort) (channels * 2);
            AddDataToBuffer(data, ref offset, BitConverter.GetBytes(blockAlign));

            ushort bps = 16;
            var bitsPerSample = BitConverter.GetBytes(bps);
            AddDataToBuffer(data, ref offset, bitsPerSample);

            var dataString = Encoding.UTF8.GetBytes("data");
            AddDataToBuffer(data, ref offset, dataString);

            var subChunk2 = BitConverter.GetBytes(samples * 2);
            AddDataToBuffer(data, ref offset, subChunk2);
        }
    }
}