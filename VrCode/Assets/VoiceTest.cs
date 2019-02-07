using System.Threading;
using System.Threading.Tasks;
using Google.Cloud.Speech.V1;
using JetBrains.Annotations;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class VoiceTest : MonoBehaviour
{
    private int _minFreq;
    private int _maxFreq;

    private AudioSource _audioSource;
    private SpeechClient _speechClient;
    private RecognitionConfig _recognitionConfig;
    private bool _recording;
    private StreamingRecognizeRequest _streamingRecognizeRequest;
    private float _lastChunk;
    private SpeechClient.StreamingRecognizeStream _streamingRecognize;
    private Task _printResponses;

    [UsedImplicitly]
    private void Start()
    {

        if (Microphone.devices.Length <= 0)
        {
            Debug.LogWarning("Microphone not connected!");
        }
        else 
        {
            Microphone.GetDeviceCaps(null, out _minFreq, out _maxFreq);

            if (_minFreq == 0 && _maxFreq == 0)
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

    private const float ChunkFrequency = 0.5f;
    [UsedImplicitly]
    private async void FixedUpdate()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("start");
            _audioSource.clip = Microphone.Start(null, false, 1, _maxFreq); //Currently set for a 7 second clip
            _recording = true;
            _lastChunk = Time.fixedUnscaledTime;

            _streamingRecognize = _speechClient.StreamingRecognize();

            await _streamingRecognize.WriteAsync(_streamingRecognizeRequest);

            // Print responses as they arrive.
            _printResponses = Task.Run(async () =>
            {
                while (await _streamingRecognize.ResponseStream.MoveNext(default(CancellationToken)))
                {
                    //Debug.Log("Results: " + _streamingRecognize.ResponseStream.Current.Results.Count);
                    foreach (var result in _streamingRecognize.ResponseStream.Current.Results)
                    {
                        if(result.IsFinal)
                            foreach (var alternative in result.Alternatives)
                            {
                                Debug.Log(" " + alternative.Transcript);
                            }
                    }
                }
            });
        }
        else if (_recording && !Input.GetKey("space"))
        {

            Debug.Log("end");
            _recording = false;

            await SendVoiceData(true);
            await _streamingRecognize.WriteCompleteAsync();
            await _printResponses;
            //_lastSamplePos = 0;
            Microphone.End(null); //Stop the audio recording

            //byte[] audioBytes = SavWav.GetWav(_audioSource.clip, out var length, true);

            //var recognitionAudio = RecognitionAudio.FromBytes(audioBytes, 0, (int)length);

            //var response = _speechClient.Recognize(_recognitionConfig, recognitionAudio);
            //foreach (var result in response.Results)
            //{
            //    foreach (var alternative in result.Alternatives)
            //    {
            //        Debug.Log(alternative.Transcript);
            //    }
            //}

            //var res1 = SavWav.GetWav(_audioSource.clip, out _, true);
        }
        else if(_recording)
        {
            //if (Input.GetKeyDown("v"))
            //{
            //    var streamingRecognitionResults = _streamingRecognize.ResponseStream.Current.Results;
            //    var transcript = streamingRecognitionResults.FirstOrDefault()?.Stability.Alternatives.FirstOrDefault()?.Transcript;
            //    Debug.Log(transcript + );
            //}

            if (_lastChunk + ChunkFrequency < Time.fixedUnscaledTime)
            {
                Debug.Log($"Last {_lastChunk}, now: {Time.fixedUnscaledTime}, Diff: {Time.fixedUnscaledTime - _lastChunk}");
                _lastChunk = Time.fixedUnscaledTime;

                await SendVoiceData(false);

                //Microphone.End(null); //Stop the audio recording
                //_audioSource.clip = Microphone.Start(null, false, 1, _maxFreq); //Currently set for a 7 second clip
                
            }
        }
    }

    private async Task SendVoiceData(bool end)
    {
        var voiceData2 = SavWav.GetWav(_audioSource.clip, out var length, true);
        Microphone.End(null); //Stop the audio recording

        if(!end)
            _audioSource.clip = Microphone.Start(null, false, 1, _maxFreq); //Currently set for a 7 second clip

        await _streamingRecognize.WriteAsync(
            new StreamingRecognizeRequest()
            {
                AudioContent = Google.Protobuf.ByteString.CopyFrom(voiceData2, 0, (int) length)
            });
    }
}