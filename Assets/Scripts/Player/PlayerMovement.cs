using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementScale;
    [SerializeField] bool invertControls;
    [SerializeField]
    Toggle invertToggle;

    private void Update()
    {
        if (GameManager.Instance.gameState == GameState.Playing)
        {
            Vector3 movement = new(InputManager.Instance.MovementInput.y * movementScale * Time.deltaTime, 0,
                            -InputManager.Instance.MovementInput.x * movementScale * Time.deltaTime);
            transform.Rotate(movement * (invertControls ? -1 : 1));
        }
    }

    void Start()
    {
        invertToggle.isOn = PlayerPrefs.GetInt("inverted",0) == 1;
        InvertControls();
    }

    public void InvertControls()
    {
        invertControls = invertToggle.isOn;
        PlayerPrefs.SetInt("inverted", invertControls ? 1 : 0);
    }
}
