using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    GameObject subMenuCommons;
    [SerializeField]
    Text subMenuTitle;
    GameObject currentMenu;

    private void Start()
    {
        currentMenu = gameObject;
    }

    public void OpenMenu(GameObject menu)
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
