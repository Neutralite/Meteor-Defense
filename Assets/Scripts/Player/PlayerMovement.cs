using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementScale;
    public bool invertControls;
    private void Update()
    {
        if (GameManager.Instance.gameState == GameState.Playing)
        {
            Vector3 movement = new(InputManager.Instance.MovementInput.y * movementScale * Time.deltaTime, 0,
                            -InputManager.Instance.MovementInput.x * movementScale * Time.deltaTime);
            transform.Rotate(movement * (invertControls ? -1 : 1));
        }
    }
}
