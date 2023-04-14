using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    [SerializeField]
    GameObject currentUI, previousUI, menuCommons;
    public GameObject gameUI;
    [SerializeField]
    Text subMenuTitle;

    private void Start()
    {
        instance = this;
    }

    public void CloseUI()
    {
        currentUI.SetActive(false);
        menuCommons.SetActive(false);
    }

    void ToggleMenuCommons()
    {
        if (currentUI.name != "Main Menu" && currentUI.name != "Game UI" && currentUI.name != "Score Submitter")
        {
            menuCommons.SetActive(true);
            subMenuTitle.text = currentUI.name;
        }
    }

    public void OpenUI(GameObject newUI)
    {
        CloseUI();

        previousUI = currentUI;

        currentUI = newUI;

        ToggleMenuCommons();

        currentUI.SetActive(true);
    }

    public void OpenPreviousUI()
    {
        if (currentUI.name == "Pause Menu")
        {
            previousUI = gameUI;
        }
        OpenUI(previousUI);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
