using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class CutsceneManager : MonoBehaviour
{
    // We want to remove the event listener we install through InputSystem.onAnyButtonPress
    // after we're done so remember it here.
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
        initialRotation = GameManager.instance.player.transform.rotation;
        animator.enabled=true;
        animator.SetTrigger("Play");
    }

    private void Update()
    {
        if (GameManager.instance.gameState == GameState.Cutscene && GameManager.instance.player.transform.rotation!= doomedCity.transform.rotation)
        {
            timer += playerSpeed;
            GameManager.instance.player.transform.rotation = Quaternion.Lerp(initialRotation, doomedCity.transform.rotation, timer);
        }
        if (GameManager.instance.player.transform.rotation == doomedCity.transform.rotation && animator.GetCurrentAnimatorStateInfo(0).IsName("New State 0"))
        {
            OnButtonPressed(null);
        }
    }
    void OnButtonPressed(InputControl button)
    {
        doomedCity.SetActive(false);
        m_EventListener.Dispose();
        //ScoreManager.instance.Score = 0;
        MenuManager.instance.gameUI.SetActive(true);
        GameManager.instance.gameState = GameState.Playing;
        GameManager.instance.PauseGame(false);
    }

}
