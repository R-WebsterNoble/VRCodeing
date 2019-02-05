using System;
using System.Collections.Generic;
using System.Text;
using Google.Cloud.Speech.V1;

namespace CsGenerator
{
    public class QuickStart
    {
        public static void DoVoice()
        {
            var path = "R:\\Games\\Steam\\SteamApps\\common\\Left 4 Dead 2\\left4dead2_dlc3\\sound\\player\\survivor\\voice\\manager\\thanks14.wav";
            var speech = SpeechClient.Create();
            var response = speech.Recognize(new RecognitionConfig()
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                //SampleRateHertz = 48000,
                LanguageCode = "en-US",
            }, RecognitionAudio.FromFile(path));
            foreach (var result in response.Results)
            {
                foreach (var alternative in result.Alternatives)
                {
                    Console.WriteLine(alternative.Transcript);
                }
            }
        }
    }
}
