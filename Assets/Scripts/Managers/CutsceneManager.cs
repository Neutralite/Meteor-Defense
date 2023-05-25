using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class CutsceneManager : MonoBehaviour
{
    private IDisposable m_EventListener;
    
    [SerializeField]float timer,playerSpeed,meteorSpeed;
    Quaternion initialRotation;

    [SerializeField] GameObject doomedCity;
    [SerializeField] Animator animator;

    private void Start()
    {
        doomedCity.transform.rotation = UnityEngine.Random.rotation;
        doomedCity.SetActive(true);
    }

    public void RunCutscene()
    {
        m_EventListener = InputSystem.onAnyButtonPress.Call(OnButtonPressed);
        GameManager.instance.gameState = GameState.Cutscene;
        initialRotation = GameManager2.instance.player.transform.rotation;
        animator.enabled=true;
        animator.SetTrigger("Play");
    }

    private void Update()
    {
        if (GameManager.instance.gameState == GameState.Cutscene && GameManager2.instance.player.transform.rotation!= doomedCity.transform.rotation)
        {
            timer += playerSpeed;
            GameManager2.instance.player.transform.rotation = Quaternion.Lerp(initialRotation, doomedCity.transform.rotation, timer);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("New State 0"))
        {
            OnButtonPressed(null);
        }
    }
    void OnButtonPressed(InputControl button)
    {
        doomedCity.SetActive(false);
        m_EventListener.Dispose();
        MenuManager.instance.gameUI.SetActive(true);
        GameManager.instance.gameState = GameState.Playing;
        GameManager2.instance.PauseGame(false);
    }

}
