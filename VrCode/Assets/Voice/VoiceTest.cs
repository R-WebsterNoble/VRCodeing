using System.Linq;
using Google.Cloud.Speech.V1;
using JetBrains.Annotations;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Voice
{
    public class VoiceTest : MonoBehaviour
    {
        private int _maxFreq;

        private AudioSource _audioSource;
        private TextMesh _text;

        private SpeechClient _speechClient;
        private RecognitionConfig _recognitionConfig;
        private StreamingRecognizeRequest _streamingRecognizeRequest;
        private SpeechClient.StreamingRecognizeStream _streamingRecognize;

        public VoiceRecognitionStreamer Streamer;

        private bool _recording;
        private float _lastChunk;
        private int _lastVoicePos;

        private const float ChunkFrequency = 0.5f;

        [UsedImplicitly]
        private void Start()
        {
            _text = gameObject.GetComponent<TextMesh>();
            if (Microphone.devices.Length <= 0)
            {
                Debug.LogWarning("Microphone not connected!");
            }
            else 
            {
                Microphone.GetDeviceCaps(null, out var minFreq, out _maxFreq);

                if (minFreq == 0 && _maxFreq == 0)
                    _maxFreq = 44100;

                _audioSource = GetComponent<AudioSource>();

                _speechClient = SpeechClient.Create();

                _recognitionConfig = new RecognitionConfig
                {
                    Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                    SampleRateHertz = _maxFreq,
                    LanguageCode = "en-GB",
                    EnableAutomaticPunctuation = true,
                    Model = "command_and_search",
                };

                _streamingRecognizeRequest = new StreamingRecognizeRequest
                {
                    StreamingConfig = new StreamingRecognitionConfig
                    {
                        Config = _recognitionConfig,
                        InterimResults = true,
                        SingleUtterance = false
                    }
                };
            }
        }

        [UsedImplicitly]
        private void FixedUpdate()
        {
            var transcript = Streamer?.LatestResults?.FirstOrDefault()?.Alternatives?.FirstOrDefault()?.Transcript;

            if (!string.IsNullOrEmpty(transcript))
                _text.text = transcript;

            //if (Streamer?.LatestResults != null)
            //{
            //    var text = "";
            //    for (var i = 0; i < Streamer.LatestResults.Count; i++)
            //    {
            //        var result = Streamer.LatestResults[i];
            //        foreach (var alt in result.Alternatives)
            //        {
            //            text += $"Result: {i}, Stability: {result.Stability}, Confidence: {alt.Confidence} Final: {result.IsFinal}: \"{alt.Transcript}\"\n";
            //        }
            //    }
            //    _text.text = text;
            //}

            if (Input.GetKeyDown("space"))
            {
                StartVoice();
            }
            else if (_recording && (!Input.GetKey("space") || (Streamer?.LatestResults?.Any(r => r.IsFinal) ?? false)))
            {
                EndVoice();
            }
            else if(_recording)
            {
                if (_lastChunk + ChunkFrequency < Time.fixedUnscaledTime)
                {
                    //Debug.Log($"Last {_lastChunk}, now: {Time.fixedUnscaledTime}, Diff: {Time.fixedUnscaledTime - _lastChunk}");
                    SendVoiceChunk();

                    _lastChunk = Time.fixedUnscaledTime;
                }
            }
        }

        private void StartVoice()
        {
            Debug.Log("start");
            _audioSource.clip = Microphone.Start(null, true, 1, _maxFreq);
            _recording = true;
            _lastVoicePos = 0;
            _lastChunk = Time.fixedUnscaledTime;
            
            Streamer = new VoiceRecognitionStreamer(_speechClient, _streamingRecognizeRequest);
        }

        private void EndVoice()
        {
            Debug.Log("end");

            _recording = false;

            SendVoiceChunk();

            Streamer.EndVoiceRecognition();

            Microphone.End(null);
        }

        private void SendVoiceChunk()
        {
            var pos = Microphone.GetPosition(null);

            if (pos == _lastVoicePos)
                return;

            var audioData = new AudioData(_audioSource.clip, _lastVoicePos, pos);

            Streamer.RecognizeChunk(audioData);

            _lastVoicePos = pos;
        }
    }
}