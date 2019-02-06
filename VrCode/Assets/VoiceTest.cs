using Google.Cloud.Speech.V1;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using NAudio.Lame;
using NAudio.Wave;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class VoiceTest : MonoBehaviour
{
    const int HEADER_SIZE = 44;

    private int _minFreq;
    private int _maxFreq;

    private AudioSource _audioSource;
    private SpeechClient _speechClient;


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
        }
    }
    [UsedImplicitly]
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            _audioSource.clip = Microphone.Start(null, true, 7, _maxFreq); //Currently set for a 7 second clip
        }
        else if (Input.GetKeyUp("space"))
        {
            //_lastSamplePos = 0;
            Microphone.End(null); //Stop the audio recording

            _audioSource.PlayOneShot(_audioSource.clip);


            var samples = new float[_audioSource.clip.samples];

            _audioSource.clip.GetData(samples, 0);


            //var res1 = SavWav.GetWav(_audioSource.clip, out _, true);

        }
    }
}