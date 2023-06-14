using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameState gameState = GameState.MainMenu;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (MenuManager.Instance.currentMenu.activeSelf && gameState == GameState.Playing)
        {
            gameState = GameState.Paused;
        }

        if (InputManager.Instance.EscapeInput && MenuManager.Instance.currentMenu.CompareTag("Pause Menu") && gameState!=GameState.GameOver)
        {
            TogglePauseState();
        }

        if ((Planet.Instance.Health == 0 || Shield.scoreIncrease == 0) && gameState != GameState.GameOver)
        {
            gameState = GameState.GameOver;
            Time.timeScale = 0;
            EndSession();
        }
    }

    public void TogglePauseState()
    {
        gameState = gameState==GameState.Playing? GameState.Paused : GameState.Playing;

        Time.timeScale = gameState == GameState.Paused ? 0 : 1;
    }

    public void ChangeState(int state)
    {
        gameState = (GameState)state;
    }

    public void EndSession()
    {
        if (ScoreManager.Instance.Score < HighScoresManager.Instance.ScoreToBeat)
        {
            Restart();
        }
        else
        {
            MenuManager.Instance.OpenMenu(MenuManager.Instance.scoreSubmit);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}

public enum GameState
{
    MainMenu, Cutscene, Playing, Paused, GameOver
}