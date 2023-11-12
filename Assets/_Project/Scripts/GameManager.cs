using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Static instance of GameManager which allows it to be accessed by any other script.
    public static GameManager instance = null;
    public GameStage currentStage = GameStage.Ready;

    public GameObject characterCanvas;

    public void GameStartButtonClicked()
    {
        characterCanvas.SetActive(false);
        updateGameStage(GameStage.PrepareTask);
    }
    
    
    

    void Awake()
    {
        // Check if instance already exists
        if (instance == null)
        {
            // if not, set instance to this
            instance = this;
        }
        // If instance already exists and it's not this:
        else if (instance != this)
        {
            // Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }

        // Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        // Call any initialization code here
        // InitGame();
    }

    private void Start()
    {
        updateGameStage(currentStage);
    }

    public void updateGameStage(GameStage stage)
    {
        print(stage);
        currentStage = stage;
        
        switch (stage)
        {
            case GameStage.Ready:
                break;
            case GameStage.PrepareTask:
                break;
            case GameStage.Main:
                break;
            case GameStage.Finish:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(stage), stage, null);
        }
        
    }

    // // Initialize the game (can be empty for now)
    // void InitGame()
    // {
    //     // TODO: Add initialization code here
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     // TODO: Add per frame logic here
    // }

    public enum GameStage
    {
        Ready,
        PrepareTask,
        Main,
        Finish
    }
}
