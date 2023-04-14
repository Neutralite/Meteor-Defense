using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    bool cutsceneFinished;
    // Start is called before the first frame update
    public void RunCutscene()
    {
        GameManager.instance.gameState = GameState.Cutscene;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            MenuManager.instance.OpenUI(MenuManager.instance.gameUI);
            GameManager.instance.gameState = GameState.Playing;
        }
    }
}
