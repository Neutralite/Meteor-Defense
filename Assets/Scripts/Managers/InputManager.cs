using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    public bool EscapeInput { get; private set; }
    public Vector2 MovementInput { get; private set; }

    bool click,onMove;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Update()
    {
        if (MovementInput == Vector2.zero)
        {
            onMove = false;
        }
        if (!click && !onMove)
        {
            MovementInput = Vector2.zero;
        }
    }
    void OnCancel(InputValue inputValue)
    {
        EscapeInput = inputValue.isPressed;
    }

    void OnClick(InputValue inputValue)
    {

        click = inputValue.isPressed && !onMove;
    }
    void OnLook(InputValue inputValue)
    {
        if (click)
        {
            MovementInput = inputValue.Get<Vector2>();
        }
    }

    void OnMove(InputValue inputValue)
    {
        if (!click)
        {
            MovementInput = inputValue.Get<Vector2>();
            onMove = true;
        }
    }

}
