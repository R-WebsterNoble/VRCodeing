using System.Linq;
using NUnit.Framework;

//using NUnit.Framework;

namespace Test
{
    public class AudioData
    {
        public AudioData(float[] c, int voiceStartPos, int voiceEndPos)
        {
            Samples = c;

            if (voiceEndPos >= voiceStartPos)
                SampleCount = voiceEndPos - voiceStartPos;
            else
            {
                SampleCount = ((c.Length) - voiceStartPos) // distance from start pos to end of buffer
                              + (voiceEndPos); // distance from start of buffer to end pos
            }

            VoiceStartPos = voiceStartPos;
            VoiceEndPos = voiceEndPos;
        }

        public float[] Samples { get; }
        public int VoiceStartPos { get; }
        public int VoiceEndPos { get; }
        public int SampleCount { get; }
    }

    [TestFixture]
    public class MoreTests
    {

        private static float[] ConvertAndWrite(AudioData audioData)
        {
            var bytes = new float[audioData.SampleCount];

            var p = 0;
            for (var c = 0; c < audioData.SampleCount; c++)
            {
                var i = (audioData.VoiceStartPos + c) % audioData.Samples.Length;
                bytes[p++] = audioData.Samples[i];
            }

            return bytes;//buffer;
        }
        [TestCase(/*start*/0, /*end*/8, /*expectedFirstNum*/1f, /*expectedLastNum*/8f, /*expectedCount*/8, ExpectedResult = 8, TestName = "woot")]
        [TestCase(/*start*/1, /*end*/8, /*expectedFirstNum*/2f, /*expectedLastNum*/8f, /*expectedCount*/7)]
        [TestCase(/*start*/0, /*end*/0, /*expectedFirstNum*/0f, /*expectedLastNum*/0f, /*expectedCount*/0)]
        [TestCase(/*start*/1, /*end*/0, /*expectedFirstNum*/2f, /*expectedLastNum*/10f, /*expectedCount*/9)]
        [TestCase(/*start*/1, /*end*/0, /*expectedFirstNum*/2f, /*expectedLastNum*/10f, /*expectedCount*/9)]
        [TestCase(/*start*/5, /*end*/3, /*expectedFirstNum*/6f, /*expectedLastNum*/3f, /*expectedCount*/8)]
        [TestCase(/*start*/1, /*end*/1, /*expectedFirstNum*/0f, /*expectedLastNum*/0f, /*expectedCount*/0)]
        [TestCase(/*start*/0, /*end*/1, /*expectedFirstNum*/1f, /*expectedLastNum*/1f, /*expectedCount*/1)]
        public int Test_Voice(int start, int end, float expectedFirstNum, float expectedLastNum, int expectedCount)
        {//                       0   1   2   3   4   5   6   7   8   9
            var samples = new[] { 1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f };
            var result = ConvertAndWrite(new AudioData(samples, start, end));

            Assert.AreEqual(expectedCount, result.Length);
            Assert.AreEqual(expectedFirstNum, result.FirstOrDefault());
            Assert.AreEqual(expectedLastNum, result.Reverse().FirstOrDefault());
            return result.Length;
        }
    }
}