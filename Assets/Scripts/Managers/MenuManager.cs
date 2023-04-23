using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    [SerializeField]
    GameObject menuCommons,mainMenu,pauseMenu;
    public GameObject gameUI;

    [SerializeField]
    Text subMenuTitle;

    private void Start()
    {
        instance = this;
    }

    public void OpenMenu(GameObject menu)
    {
        menuCommons.SetActive(true);
        subMenuTitle.text = menu.name;
        menu.SetActive(true);
    }

    public void OpenMainMenu()
    {
        if (GameManager.instance.gameState == GameState.MainMenu)
        {
            mainMenu.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
