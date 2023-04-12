using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    [SerializeField]
    GameObject currentUI, previousUI, menuCommons;
    [SerializeField]
    Text subMenuTitle;

    private void Start()
    {
        instance = this;
    }
    
    public void CloseUI()
    {
        currentUI.SetActive(false);
    }

    public void OpenUI(GameObject newUI)
    {
        previousUI = currentUI;
        currentUI = newUI;
        currentUI.SetActive(true);
    }

    public void OpenPreviousUI()
    {
        currentUI = previousUI;
        currentUI.SetActive(true);
    }

    public void ToggleMenuCommons(bool active)
    {
        menuCommons.SetActive(active);
        subMenuTitle.text = currentUI.name;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}
