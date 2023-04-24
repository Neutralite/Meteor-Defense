using System.Collections.Generic;
using UnityEngine;

public class MeteorDefensePoolManager : MonoBehaviour
{
    public static MeteorDefensePoolManager instance;
 
    [SerializeField]
    List<GameObject> citiesPrefabs = new(),
                     meteorsPrefabs = new(),
                     inactiveCities = new(), 
                     inactiveMeteors = new();

    public List<GameObject> activeCities = new(),
                     activeMeteors = new();

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
    public void ReleaseObjects(int amount, ObjectID objectID)
    {
        GameObject temp;
        for (int i = 0; i < amount; i++)
        {
            switch (objectID)
            {
                case ObjectID.City:
                    temp =GetObject(inactiveCities,activeCities, citiesPrefabs);
                    break;
                case ObjectID.Meteor:
                    temp = GetObject(inactiveMeteors,activeMeteors, meteorsPrefabs);
                    break;
                default:
                    temp = null;
                    break;
            }
            temp.transform.rotation = Random.rotation;
            temp.SetActive(true);
        }
    }
    public GameObject ReleaseObject(ObjectID objectID)
    {
        switch (objectID)
        {
            case ObjectID.City:
                return GetObject(inactiveCities, activeCities, citiesPrefabs);
            case ObjectID.Meteor:
                return GetObject(inactiveMeteors, activeMeteors, meteorsPrefabs);
            default:
                return null;
        }
    }
    private GameObject GetObject(List<GameObject> inactiveList, List<GameObject> activeList, List<GameObject> prefabList)
    {
        GameObject temp;
        if (inactiveList.Count != 0)
        {
            temp = inactiveList[0];
            inactiveList.Remove(temp);
        }
        else
        {
            temp = Instantiate(prefabList[Random.Range(0, prefabList.Count)],transform);
        }
        activeList.Add(temp);
        return temp;
    }
    public void ReturnObject(GameObject obj,ObjectID objectID)
    {
        obj.SetActive(false);

        switch (objectID)
        {
            case ObjectID.City:
                SupportFunctions.MoveBetweenLists(activeCities, inactiveCities, obj);

                break;
            case ObjectID.Meteor:
                SupportFunctions.MoveBetweenLists(activeMeteors, inactiveMeteors, obj);
                obj.transform.GetChild(0).localPosition = new(0, GameManager.instance.meteorHeight,0);
                obj.GetComponentInChildren<Rigidbody>().velocity = Vector3.zero;
                break;
        }
    }

    public void ReturnAll()
    {
        foreach (var item in activeCities)
        {
            ReturnObject(item, ObjectID.City);

        }
        foreach (var item in activeMeteors)
        {
            ReturnObject(item, ObjectID.Meteor);
        }
    }
}