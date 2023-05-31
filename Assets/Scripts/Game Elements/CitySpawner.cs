using UnityEngine;

public class CitySpawner : MonoBehaviour
{
    private void Start()
    {
        GameObject city = ObjectPoolManager.instance.ReleaseObject(ObjectID.City);
        city.transform.rotation = Random.rotation;
        city.SetActive(true);
    }
}
