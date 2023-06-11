using UnityEngine;

public class CitySpawner : MonoBehaviour
{
    [SerializeField]
    int startAmount,cityCounter,initialHealth = 1;
    private void Start()
    {
        cityCounter = 0;
        for (int i = 0; i < startAmount; i++)
        {
            SpawnCity();
        }
    }

    void SpawnCity()
    {
        GameObject city = ObjectPoolManager.Instance.ReleaseObject(ObjectID.City);
        city.transform.rotation = Random.rotation;
        city.GetComponent<City>().spawnOrder = cityCounter;
        city.GetComponent<City>().health = initialHealth;
        cityCounter++;
        city.SetActive(true);
    }
}
