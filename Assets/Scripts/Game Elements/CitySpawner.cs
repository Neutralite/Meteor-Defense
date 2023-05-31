using UnityEngine;

public class CitySpawner : MonoBehaviour
{
    [SerializeField]
    int startAmount;
    private void Start()
    {
        for (int i = 0; i < startAmount; i++)
        {
            SpawnCity();
        }
    }

    void SpawnCity()
    {
        GameObject city = ObjectPoolManager.instance.ReleaseObject(ObjectID.City);
        city.transform.rotation = Random.rotation;
        city.SetActive(true);
    }
}
