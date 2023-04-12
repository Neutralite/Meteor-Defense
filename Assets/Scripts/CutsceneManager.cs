using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField]
    GameObject gameUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            MenuManager.instance.CloseUI();
            MenuManager.instance.OpenUI(gameUI);
        }
    }
}
