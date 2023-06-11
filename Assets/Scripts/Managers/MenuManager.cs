using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }

    [SerializeField]
    GameObject rootMenu, menuCommons, backButton;

    [SerializeField]
    Text subMenuTitle;

    public GameObject currentMenu, gameUI, scoreSubmit;

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
    private void Update()
    {
        if (InputManager.Instance.EscapeInput && GameManager.Instance.gameState != GameState.GameOver)
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
        if (GameManager.Instance.gameState!=GameState.GameOver)
        {
            OpenMenu(rootMenu);
        }
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
}
