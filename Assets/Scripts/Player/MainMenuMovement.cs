using UnityEngine;

public class MainMenuMovement : MonoBehaviour
{
    [SerializeField] float speed;
    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.gameState == GameState.MainMenu)
            transform.Rotate(Vector3.forward*speed);
    }
}
