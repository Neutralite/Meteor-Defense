using UnityEngine;

public class City : MonoBehaviour
{
    static int cityCounter;
    public int spawnOrder;
    public int health;

    private void OnEnable()
    {
        spawnOrder = cityCounter;
        cityCounter++;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("City"))
        {
            if (collision.gameObject.GetComponent<City>().spawnOrder<spawnOrder)
            {
                transform.rotation = Random.rotation;
            }
        }
    }
}
