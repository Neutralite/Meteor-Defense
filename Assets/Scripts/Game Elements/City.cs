using UnityEngine;

public class City : MonoBehaviour
{
    [SerializeField] GameObject unhit, hit;
    public int spawnOrder, health;

    // Overlapping cities prevention
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("City"))
        {
            if (collision.gameObject.GetComponent<City>().spawnOrder < spawnOrder)
            {
                transform.rotation = Random.rotation;
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Meteor"))
        {
            if (health == 1)
            {
                if (GameManager.Instance.gameState == GameState.Playing)
                {
                    Planet.Instance.Health -= 5;
                    ScoreManager.Instance.Score -= 5;
                }
                health -= 1;
                unhit.SetActive(false);
                hit.SetActive(true);
            }
            else
            {
                Planet.Instance.Health -= 10;
            }
        }
    }
}
