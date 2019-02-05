using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Speech.V1;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = System.Diagnostics.Debug;

public class VoiceTest : MonoBehaviour
{
    // Start is called before the first frame update
    //[UsedImplicitly]
    //void Start()
    //{
    //    var speech = SpeechClient.Create();
    //    var path = "R:\\Games\\Steam\\SteamApps\\common\\Left 4 Dead 2\\left4dead2_dlc3\\sound\\player\\survivor\\voice\\manager\\thanks14.wav";
    //    var file = RecognitionAudio.FromFile(path);
    //    var response = speech.Recognize(new RecognitionConfig()
    //    {
    //        Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
    //        //SampleRateHertz = 16000,
    //        LanguageCode = "en",
    //    }, file);
    //    foreach (var result in response.Results)
    //    {
    //        foreach (var alternative in result.Alternatives)
    //        {
    //            Debug.Log(alternative.Transcript);
    //        }
    //    }
    //}

    //public async void Start()
    //{
    //    // Wait one second
    //    await new WaitForSeconds(1.0f);

    //    // Wait for IEnumerator to complete
    //    await CustomCoroutineAsync();

    //    await LoadModelAsync();

    //    // You can also get the final yielded value from the coroutine
    //    var value = (string)(await CustomCoroutineWithReturnValue());
    //    // value is equal to "asdf" here

    //    // Open notepad and wait for the user to exit
    //    var returnCode = await Process.Start("notepad.exe");

    //    // Load another scene and wait for it to finish loading
    //    await SceneManager.LoadSceneAsync("scene2");
    //}

    //async Task LoadModelAsync()
    //{
    //    var assetBundle = await GetAssetBundle("www.my-server.com/myfile");
    //    var prefab = await assetBundle.LoadAssetAsync<GameObject>("myasset");
    //    GameObject.Instantiate(prefab);
    //    assetBundle.Unload(false);
    //}

    //async Task<AssetBundle> GetAssetBundle(string url)
    //{
    //    return (await new WWW(url)).assetBundle;
    //}

    //IEnumerator CustomCoroutineAsync()
    //{
    //    yield return new WaitForSeconds(1.0f);
    //}

    //IEnumerator CustomCoroutineWithReturnValue()
    //{
    //    yield return new WaitForSeconds(1.0f);
    //    yield return "asdf";
    //}

    // Update is called once per frame
    [UsedImplicitly]
    void Update()
    {
        
    }
}
