using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Google.Cloud.Speech.V1;
using Google.Protobuf;
using Google.Protobuf.Collections;
using UnityEngine;

namespace Voice
{
    public class VoiceRecognitionStreamer
    {
        public RepeatedField<StreamingRecognitionResult> LatestResults { get; private set; }

        readonly BufferBlock<AudioData> _voiceData = new BufferBlock<AudioData>();

        public VoiceRecognitionStreamer(SpeechClient speech, StreamingRecognizeRequest streamingRecognizeRequest)
        {
            Task.Factory.StartNew(async () =>
            {
                try
                {
                    var streamingCall = speech.StreamingRecognize();
                    // Write the initial request with the config.
                    await streamingCall.WriteAsync(streamingRecognizeRequest);

                    // Print responses as they arrive.
                    var printResponses = Task.Run(async () =>
                    {
                        while (await streamingCall.ResponseStream.MoveNext(
                            default).ConfigureAwait(false))
                        {
                            LatestResults = streamingCall.ResponseStream.Current.Results;
                        }
                    });

                    while (await _voiceData.OutputAvailableAsync().ConfigureAwait(false))
                    {
                        var data = await _voiceData.ReceiveAsync().ConfigureAwait(false);
                        
                        var voiceData = WavConvert.Convert(data);

                        await streamingCall.WriteAsync(new StreamingRecognizeRequest
                        {
                            AudioContent = ByteString.CopyFrom(voiceData)
                        }).ConfigureAwait(false);
                    }

                    await _voiceData.Completion.ConfigureAwait(false);
                    await streamingCall.WriteCompleteAsync().ConfigureAwait(false);
                    await printResponses.ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    Debug.Log(ex.Message);
                }

                Debug.Log("done");
            }, TaskCreationOptions.LongRunning);
        }


        public void RecognizeChunk(AudioData audioData)
        {
            _voiceData.Post(audioData);
        }

        public void EndVoiceRecognition()
        {
            _voiceData.Complete();
        }
    }
}