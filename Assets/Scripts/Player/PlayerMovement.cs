using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    GameObject shieldAnchor;
    [SerializeField]
    Vector2 initialHeight, bounceHeight;
    Vector2 movementInput;
    [SerializeField] float movementScale, bounceSpeed;
    bool bouncing,falling;
    private void Update()
    {
        transform.Rotate(movementInput.y * movementScale * Time.deltaTime, 0,-movementInput.x * movementScale * Time.deltaTime);

        BounceShield();
    }
    void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }
    void OnFire()
    {
        if (!bouncing)
        {
            bouncing = true;
        }
    }

    private void BounceShield()
    {

        if (bouncing)
        {
            if (shieldAnchor.transform.localPosition.y < bounceHeight.y)
            {
                shieldAnchor.transform.localPosition += bounceSpeed * Time.deltaTime * Vector3.up;
            }
            else
            {
                bouncing = false;
                falling = true;
            }
        }

        if (falling)
        {
            if (shieldAnchor.transform.localPosition.y > initialHeight.y)
            {
                shieldAnchor.transform.localPosition += bounceSpeed * Time.deltaTime * Vector3.down;
            }
            else
            {
                shieldAnchor.transform.localPosition = initialHeight;
                falling = false;
            }

        }
    }
}
