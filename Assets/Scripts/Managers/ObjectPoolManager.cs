using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager instance;

    public List<ObjectPool> objectPools;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public GameObject ReleaseObject(ObjectID objectID)
    {
        ObjectPool objectPool = objectPools[(int)objectID];
        GameObject obj;

        if (objectPool.inactiveList.Count != 0)
        {
            obj = objectPool.inactiveList[0];
            objectPool.inactiveList.Remove(obj);
        }
        else
        {
            obj = Instantiate(objectPool.prefabVariants[Random.Range(0, objectPool.prefabVariants.Count)], transform);
        }
        objectPool.activeList.Add(obj);
        return obj;
    }

    public void ReturnObject(GameObject obj)
    {
        int temp = obj.CompareTag("City") ? 0 : 1;

        SupportFunctions.MoveBetweenLists(objectPools[temp].activeList, objectPools[temp].inactiveList,obj);
    }
}

[System.Serializable]
public struct ObjectPool
{
    public List<GameObject> prefabVariants;
    public List<GameObject> inactiveList;
    public List<GameObject> activeList;
}

public enum ObjectID
{
    City, Meteor
}