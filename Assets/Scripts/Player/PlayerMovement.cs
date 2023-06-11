using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementScale;
    private void Update()
    {
        if (GameManager.Instance.gameState == GameState.Playing)
        {
            transform.Rotate(InputManager.Instance.MovementInput.y * movementScale * Time.deltaTime, 0,
                            -InputManager.Instance.MovementInput.x * movementScale * Time.deltaTime);
        }
    }
}
