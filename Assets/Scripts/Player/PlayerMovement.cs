using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    GameObject shieldAnchor;
    [SerializeField]
    Vector2 initialHeight, bounceHeight;
    Vector2 movementInput;
    [SerializeField] float movementScale;
    bool bouncing,falling;
    private void Update()
    {
        transform.Rotate(movementInput.y * movementScale * Time.deltaTime, 0,-movementInput.x * movementScale * Time.deltaTime);

        //Mathf.PingPong(Time.time, 8)
    }
    void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }
    void OnFire()
    {
        if (!bouncing && !falling)
        {
            bouncing = true;
        }
    }
}
