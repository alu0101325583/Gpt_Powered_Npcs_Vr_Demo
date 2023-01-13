using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpeech;
using UnityEngine.Android;
using UnityLibrary;

public class VoiceController : MonoBehaviour
{
    const string LANG_CODE = "es-SP";

    public static VoiceController Instance;

    public TextMesh input;
    
    //Singleton
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            throw (new System.Exception("Only one instance of OpenAI is allowed"));
        }
    }

    private void Start()
    {
        Setup(LANG_CODE);

#if UNITY_ANDROID
        SpeechToText.Instance.onPartialResultsCallback = OnPartialSpeechResult;
#endif
        SpeechToText.Instance.onResultCallback = OnFinalSpeechResult;
        TextToSpeech.Instance.onDoneCallback = OnSpeakStop;
        TextToSpeech.Instance.onStartCallBack = OnSpeakStart;
        CheckPermission();
    }
    
    void CheckPermission()
    {
#if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
#endif
    }

    #region Text To Speech

    public void StartSpeaking(string message)
    {
        TextToSpeech.Instance.StartSpeak(message);
    }

    public void StopSpeaking()
    {
        TextToSpeech.Instance.StopSpeak();
    }

    void OnSpeakStart()
    {
        Debug.Log("OnSpeakStart");
    }

    void OnSpeakStop()
    {
        Debug.Log("OnSpeakStop");
    }
    #endregion

    #region Speech To Text

    public void StartListening()
    {
        input.text = "Listening...";
        SpeechToText.Instance.StartRecording();
        
    }

    public void StopListening()
    {
        SpeechToText.Instance.StopRecording();
    }

    void OnFinalSpeechResult(string result)
    {
        input.text = result;
        OpenAI.Instance.Execute(result);
    }

    void OnPartialSpeechResult(string result)
    {
        Debug.Log("OnPartialSpeechResult: " + result);
    }
    #endregion

    void Setup(string code)
    {
        TextToSpeech.Instance.Setting(code, 1, 1);
        SpeechToText.Instance.Setting(code);
    }   
}
