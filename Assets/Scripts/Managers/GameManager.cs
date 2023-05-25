using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameState gameState = GameState.MainMenu;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameState == GameState.Cutscene)
        {
            gameState = GameState.Playing;
        }
        
        if (InputManager.instance.EscapeInput && MenuManager.instance.currentMenu.CompareTag("Pause Menu"))
        {
            TogglePauseState();
        }
    }

    public void TogglePauseState()
    {
        if (gameState == GameState.Paused)
        {
            gameState = GameState.Playing;
            Time.timeScale = 1;
        }
        else
        {
            gameState = GameState.Paused;
            Time.timeScale = 0;
        }
    }

    public void ChangeState(int state)
    {
        gameState = (GameState)state;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}

public enum GameState
{
    MainMenu, Cutscene, Playing, Paused
}