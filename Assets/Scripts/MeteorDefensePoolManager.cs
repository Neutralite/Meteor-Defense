using System.Collections.Generic;
using UnityEngine;

public class MeteorDefensePoolManager : MonoBehaviour
{
    public static MeteorDefensePoolManager instance;
 
    [SerializeField]
    List<GameObject> citiesPrefabs = new List<GameObject>(),
                     meteorsPrefabs = new List<GameObject>(),
                     cities = new List<GameObject>(), 
                     meteors = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
    public void ReleaseObject(int amount, string tag)
    {
        switch(tag)
        {
            case "City":
                for (int i = 0; i < amount; i++)
                {
                    ReleaseCity();
                }
            break;
            case "Meteor":
                for (int i = 0; i < amount; i++)
                {
                    ReleaseMeteor();
                }
                break;
        }
    }
    private void ReleaseCity()
    {
        GameObject temp;
        if (cities.Count != 0)
        {
            temp = cities[0];
            cities.Remove(temp);
        }
        else
        {
            temp = Instantiate(citiesPrefabs[Random.Range(0,citiesPrefabs.Count)],transform);
        }
        temp.SetActive(true);
        temp.transform.rotation = UnityEngine.Random.rotation;
    }
    private void ReleaseMeteor()
    {
        GameObject temp;
        if (meteors.Count!=0)
        {
            temp = meteors[0];
            meteors.Remove(temp);
        }
        else
        {
            temp = Instantiate(meteorsPrefabs[Random.Range(0, meteorsPrefabs.Count)], transform);
        }
        temp.SetActive(true);
        temp.transform.rotation = UnityEngine.Random.rotation;
    }
    public void ReturnObject(GameObject obj)
    {
        switch (obj.tag)
        {
            case "City":
                cities.Add(obj);
                break;
            case "Meteor":
                obj.GetComponentInChildren<Transform>().position = new(0, 20);
                obj.GetComponentInChildren<Rigidbody>().velocity = Vector3.zero;
                meteors.Add(obj);
                break;
        }
        obj.SetActive(false);
    }
}
