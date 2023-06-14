using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class CutsceneManager : MonoBehaviour
{
    private IDisposable m_EventListener;

    [SerializeField] GameObject doomedCity, player,shield;

    [SerializeField] float timer, playerSpeed;
    Quaternion initialRotation,destinationRotation;

    private void Update()
    {
        if (GameManager.Instance.gameState == GameState.Cutscene)
        {
            if (player.transform.rotation != doomedCity.transform.rotation)
            {
                timer += playerSpeed;
                player.transform.rotation = Quaternion.Lerp(initialRotation, destinationRotation, timer);
            }

            if (!doomedCity.GetComponentInChildren<Collider>().enabled)
            {
                EndCutscene(null);
            }
        }
    }

    public void RunCutscene()
    {
        m_EventListener = InputSystem.onAnyButtonPress.Call(EndCutscene);
        GameManager.Instance.ChangeState((int)GameState.Cutscene);
        MenuManager.Instance.cutsceneUI.SetActive(true);


        initialRotation = player.transform.rotation;
        destinationRotation = doomedCity.transform.rotation;

        GameObject meteor = ObjectPoolManager.Instance.ReleaseObject(ObjectID.Meteor);
        meteor.transform.rotation = destinationRotation;
        meteor.SetActive(true);
    }

    void EndCutscene(InputControl button)
    {
        GameManager.Instance.ChangeState((int)GameState.Playing);
        shield.SetActive(true);
        MenuManager.Instance.cutsceneUI.SetActive(false);
        MenuManager.Instance.gameUI.SetActive(true);
        m_EventListener.Dispose();
    }
}
