using UnityEngine;

public class City : MonoBehaviour
{
    [SerializeField] GameObject unhit, hit;
    [SerializeField] Collider c;
    public int spawnOrder;

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
            if (GameManager.Instance.gameState == GameState.Playing)
            {
                Planet.Instance.Health -= 5;
                ScoreManager.Instance.Score -= 10;
            }
            c.enabled = false;
            unhit.SetActive(false);
            hit.SetActive(true);
            Shield.scoreIncrease--;
        }
    }
}
