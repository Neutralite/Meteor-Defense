using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    
    public bool EscapeInput { get; private set; }

    [SerializeField]
    private PlayerInput playerInput;

    private InputAction pauseAction;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        pauseAction = playerInput.actions["Cancel"];
    }

    
    // Update is called once per frame
    void Update()
    {
        EscapeInput = pauseAction.WasReleasedThisFrame();
    }
}
