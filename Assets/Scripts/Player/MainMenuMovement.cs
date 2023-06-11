using UnityEngine;

public class MainMenuMovement : MonoBehaviour
{
    [SerializeField] float speed;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        if (GameManager.Instance.gameState != GameState.MainMenu)
        {
            Destroy(this);
        }
    }
}
