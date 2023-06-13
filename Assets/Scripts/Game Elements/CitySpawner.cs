using UnityEngine;

public class CitySpawner : MonoBehaviour
{
    [SerializeField]
    int startAmount,cityCounter;
    private void Start()
    {
        cityCounter = 0;
        for (int i = 0; i < startAmount; i++)
        {
            SpawnCity();
        }
        Shield.scoreIncrease = startAmount;
    }

    void SpawnCity()
    {
        GameObject city = ObjectPoolManager.Instance.ReleaseObject(ObjectID.City);
        city.transform.rotation = Random.rotation;
        city.GetComponent<City>().spawnOrder = cityCounter;
        cityCounter++;
        city.SetActive(true);
    }
}
