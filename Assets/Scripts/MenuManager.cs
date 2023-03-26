using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject subMenuCommons;
    [SerializeField]
    Text subMenuTitle;
    [SerializeField]
    GameObject currentMenu;

    public void ToggleMenu()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
    public void ToggleSubMenu(GameObject menu)
    {
        currentMenu.SetActive(false);
        currentMenu = menu;
        subMenuCommons.SetActive(!subMenuCommons.activeSelf);
        subMenuTitle.text = currentMenu.name;
        currentMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}
