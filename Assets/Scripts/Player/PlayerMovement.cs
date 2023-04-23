using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 movementInput;
    [SerializeField] float movementScale;
    private void Update()
    {
        transform.Rotate(movementInput.y * movementScale * Time.deltaTime, 0,-movementInput.x * movementScale * Time.deltaTime);
    }
    void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }
}
