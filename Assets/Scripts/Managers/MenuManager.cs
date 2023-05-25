using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    [SerializeField]
    GameObject rootMenu, menuCommons, backButton;

    [SerializeField]
    Text subMenuTitle;

    public GameObject currentMenu, gameUI, scoreSubmit;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GameManager.instance.gameState == GameState.Playing)
        {
            gameUI.SetActive(true);
        }

        if (InputManager.instance.EscapeInput)
        {
            if (currentMenu.CompareTag("Pause Menu"))
            {
                TogglePauseMenu();
            } else
            {
                ReturnToRoot();
            }

        }

    }
    public void SwitchRootMenu(GameObject pauseMenu)
    {
        rootMenu = pauseMenu;
        currentMenu = pauseMenu;
    }

    public void OpenMenu(GameObject menu)
    {
        currentMenu.SetActive(false);
        currentMenu = menu;
        subMenuTitle.text = currentMenu.name;
        menuCommons.SetActive(!currentMenu.CompareTag("Main Menu"));
        backButton.SetActive(!currentMenu.CompareTag("Pause Menu") && !currentMenu.CompareTag("Main Menu"));
        currentMenu.SetActive(true);
    }

    public void ReturnToRoot()
    {
        OpenMenu(rootMenu);
    }

    public void TogglePauseMenu()
    {
        if (!currentMenu.activeSelf)
        {
            OpenMenu(rootMenu);
        }
        else
        {
            currentMenu.SetActive(false);
            menuCommons.SetActive(false);
        }

    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
