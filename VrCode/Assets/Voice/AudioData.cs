using UnityEngine;

namespace Voice
{
    public class AudioData
    {
        public AudioData(AudioClip c, int voiceStartPos, int voiceEndPos)
        {
            Samples = new float[c.samples];
            c.GetData(Samples, 0);

            if(voiceEndPos >= voiceStartPos)
                SampleCount = voiceEndPos - voiceStartPos;
            else
            {
                SampleCount = ((c.samples) - voiceStartPos) // distance from start pos to end of buffer
                              + (voiceEndPos); // distance from start of buffer to end pos
            }

            VoiceStartPos = voiceStartPos;
            VoiceEndPos = voiceEndPos;
            Frequency = c.frequency;
            Channels = c.channels;
        }


        public float[] Samples { get; }
        public int VoiceStartPos { get; }
        public int VoiceEndPos { get; }
        public int SampleCount { get; }
        public int Frequency { get; }
        public int Channels { get; }
    }
}