using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Meta.WitAi;
using Meta.WitAi.Requests;
using UnityEngine;
using UnityEngine.Events;

public class VoiceListenerToChatGPT : MonoBehaviour
{
    
    [SerializeField] private VoiceService[] _voiceServices;
    
    
    private void Awake()
    {
        if (_voiceServices == null || _voiceServices.Length == 0)
        {
            _voiceServices = FindObjectsOfType<VoiceService>();
        }
    }

    // Add service delegates
    private void OnEnable()
    {
        if (_voiceServices != null)
        {
            foreach (var service in _voiceServices)
            {
                service.VoiceEvents.OnFullTranscription.AddListener(OnFullTranscription);
                // service.VoiceEvents.OnStartListening.AddListener(OnStartListening);
                // service.VoiceEvents.OnPartialTranscription.AddListener(OnTranscriptionChange);
                // service.VoiceEvents.OnFullTranscription.AddListener(OnTranscriptionChange);
                // service.VoiceEvents.OnError.AddListener(OnError);
                // service.VoiceEvents.OnComplete.AddListener(OnComplete);
            }
        }
    }
    // Remove service delegates
    private void OnDisable()
    {
        if (_voiceServices != null)
        {
            foreach (var service in _voiceServices)
            {
                service.VoiceEvents.OnFullTranscription.RemoveListener(OnFullTranscription);
                // service.VoiceEvents.OnStartListening.RemoveListener(OnStartListening);
                // service.VoiceEvents.OnPartialTranscription.RemoveListener(OnTranscriptionChange);
                // service.VoiceEvents.OnFullTranscription.RemoveListener(OnTranscriptionChange);
                // service.VoiceEvents.OnError.RemoveListener(OnError);
                // service.VoiceEvents.OnComplete.RemoveListener(OnComplete);
            }
        }
    }

    public UnityEvent<string> OnFullTranscriptionEvent;

    private void OnFullTranscription(string text)
    {
        if (string.IsNullOrEmpty(text)) return;
        
        OnFullTranscriptionEvent?.Invoke(text);
    }
    private void OnComplete(VoiceServiceRequest request)
    {
        // print(request.Results.Message.);
        // if (Label != null && string.Equals(Label?.text, _promptListening))
        // {
        //     SetText(_promptDefault, _promptColor);
        // }
    }
}
