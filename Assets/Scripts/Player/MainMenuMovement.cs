using UnityEngine;

public class MainMenuMovement : MonoBehaviour
{
    [SerializeField] float speed;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
        if (GameManager.instance.gameState != GameState.MainMenu)
        {
            Destroy(this);
        }
    }
}
