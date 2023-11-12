using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Meta.WitAi;
using OpenAI;
using OpenAI.Chat;
using OpenAI.Models;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ChatGPTTextManager : MonoBehaviour
{

    public UnityEvent<string> afterChatEvent;
      private static bool isChatPending;
    
      private readonly List<Message> chatMessages = new List<Message>();
      private CancellationTokenSource lifetimeCancellationTokenSource;
      private OpenAIClient openAI;

      public TextMeshProUGUI outputTextMesh, inputTextMesh;
      
      public bool isWeb = false;
      
      [SerializeField] private VoiceService _voiceService;
      
      

      private void Awake()
      {
          lifetimeCancellationTokenSource = new CancellationTokenSource();
          openAI = new OpenAIClient("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");
          chatMessages.Add(new Message(Role.System, "You are a helpful assistant."));
      }

      private void OnEnable()
      {
          _voiceService.VoiceEvents.OnFullTranscription.AddListener(OnFullTranscription);
          _voiceService.VoiceEvents.OnPartialTranscription.AddListener(OnTranscriptionChange);
      }
      
      private void OnDisable()
      {
          _voiceService.VoiceEvents.OnFullTranscription.RemoveListener(OnFullTranscription);
          _voiceService.VoiceEvents.OnPartialTranscription.RemoveListener(OnTranscriptionChange);
      }
      
      private void OnTranscriptionChange(string text)
      {
          inputTextMesh.text = text;
      }
      
      private void OnFullTranscription(string text)
      {
          if (string.IsNullOrEmpty(text)) return;
        
          SubmitChat(text);
      }

      [ContextMenu("Submit Chat")] 
      public void ChatToUser() { SubmitChat("Hello"); }

      private async void SubmitChat(string str)
        {
            if (isChatPending || string.IsNullOrWhiteSpace(str)) { return; }
            isChatPending = true;

            // inputField.ReleaseSelection();
            // inputField.interactable = false;
            // submitButton.interactable = false;
            var input = "";
            if (isWeb)
            {
                input =
                    "What is the best search keyword to find an information on the Youtube when you got below question? no spacing, just letter and just give me a keyword, not additional explanation;;;" + str;
            }
            else
            {
                input = str;
            }
            var userMessage = new Message(Role.User, input);
            chatMessages.Add(userMessage);
            // var userMessageContent = AddNewTextMessageContent();
            // userMessageContent.text = $"User: {inputField.text}";
            // inputField.text = string.Empty;
            // var assistantMessageContent = AddNewTextMessageContent();
            // assistantMessageContent.text = "Assistant: ";
            outputTextMesh.text = "";
            try
            {
                var request = new ChatRequest(chatMessages, Model.GPT3_5_Turbo);
                // openAI.ChatEndpoint.EnableDebug = enableDebug;
                var response = await openAI.ChatEndpoint.StreamCompletionAsync(request, resultHandler: deltaResponse =>
                {
                    if (deltaResponse?.FirstChoice?.Delta == null) { return; }
                    // assistantMessageContent.text += deltaResponse.FirstChoice.Delta.ToString();
                    // scrollView.verticalNormalizedPosition = 0f;

                    outputTextMesh.text += deltaResponse.FirstChoice.Delta.ToString();
                }, lifetimeCancellationTokenSource.Token);
                // GenerateSpeech(response);
                afterChatEvent?.Invoke(response.ToString());
                print(response.ToString());
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
            finally
            {
                if (lifetimeCancellationTokenSource is { IsCancellationRequested: false })
                {
                    // inputField.interactable = true;
                    // EventSystem.current.SetSelectedGameObject(inputField.gameObject);
                    // submitButton.interactable = true;
                }

                isChatPending = false;
            }
        }

        // private async void GenerateSpeech(ChatResponse response)
        // {
        //     try
        //     {
        //         var request = new SpeechRequest(response.FirstChoice.ToString(), Model.TTS_1);
        //         openAI.AudioEndpoint.EnableDebug = enableDebug;
        //         var (clipPath, clip) = await openAI.AudioEndpoint.CreateSpeechAsync(request, lifetimeCancellationTokenSource.Token);
        //         audioSource.PlayOneShot(clip);
        //         Debug.Log(clipPath);
        //     }
        //     catch (Exception e)
        //     {
        //         Debug.LogError(e);
        //     }
        // }
}
