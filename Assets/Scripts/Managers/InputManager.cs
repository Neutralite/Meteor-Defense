using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    public bool EscapeInput { get; private set; }
    public Vector2 MovementInput { get; private set; }

    bool onClick,onMove; 

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
        if (MovementInput == Vector2.zero && onMove == true)
        {
            onMove = false;
        }
        if (!onClick && !onMove && MovementInput != Vector2.zero)
        {
            MovementInput = Vector2.zero;
        }
    }
    void OnCancel(InputValue inputValue)
    {
        EscapeInput = inputValue.isPressed;
    }

    void OnMove(InputValue inputValue)
    {
        if (!onClick)
        {
            MovementInput = inputValue.Get<Vector2>();
            onMove = true;
        }
    }

    void OnClick(InputValue inputValue)
    {
        onClick = inputValue.isPressed && !onMove;
    }
    void OnLook(InputValue inputValue)
    {
        if (onClick)
        {
            MovementInput = inputValue.Get<Vector2>() * -1;
        }
    }
}
