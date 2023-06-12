using UnityEngine;

public class MainMenuMovement : MonoBehaviour
{
    [SerializeField] float speed;
    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameState == GameState.MainMenu)
        {
            transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            Destroy(this);
        }
    }
}
