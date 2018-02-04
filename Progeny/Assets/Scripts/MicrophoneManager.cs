using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class MicrophoneManager : MonoBehaviour
{
    int frequency = 44100;

    AudioSource audioSource;
    string deviceName;
    bool isCapturingAudio;
    DictationRecognizer dictationRecognizer;

    public string youSaid;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        foreach (string device in Microphone.devices)
        {
            deviceName = device;
            Debug.Log("Device detected: " + device);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && Microphone.devices.Length > 0)
        {
            if (!isCapturingAudio)
            {
                StartCapturingAudio();
            }
            else
            {
                StopCapturingAudio();
            }
        }
    }


    // begin capturing audio from microphone
    void StartCapturingAudio()
    {
        isCapturingAudio = true;
        audioSource.clip = Microphone.Start(deviceName, true, 30, frequency);
        audioSource.loop = true;
        audioSource.Play();

        dictationRecognizer = new DictationRecognizer();
        dictationRecognizer.DictationResult += DictationRecognizer_DictationResult;
        dictationRecognizer.DictationError += DictationRecognizer_DictationError;
        dictationRecognizer.Start();
    }

    private void DictationRecognizer_DictationResult(string text, ConfidenceLevel confidence)
    {
        youSaid = text;
    }

    private void DictationRecognizer_DictationError(string error, int hresult)
    {
        Debug.Log("Dictation Error: " + error);
    }

    // stop capturing audio from microphone
    void StopCapturingAudio()
    {
        isCapturingAudio = false;
        Microphone.End(deviceName);
        dictationRecognizer.DictationResult -= DictationRecognizer_DictationResult;
        dictationRecognizer.DictationError -= DictationRecognizer_DictationError;
        dictationRecognizer.Dispose();
    }
}
