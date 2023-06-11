using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    public bool EscapeInput { get; private set; }
    public Vector2 MovementInput { get; private set; }

    [SerializeField]
    private PlayerInput playerInput;

    private InputAction pauseAction;

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

        pauseAction = playerInput.actions["Cancel"];
    }

    // Update is called once per frame
    void Update()
    {
        EscapeInput = pauseAction.WasReleasedThisFrame();
    }

    void OnMove(InputValue inputValue)
    {
        MovementInput = inputValue.Get<Vector2>();
    }
}
