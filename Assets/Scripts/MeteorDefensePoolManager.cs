using System.Collections.Generic;
using UnityEngine;

public class MeteorDefensePoolManager : PoolManager
{
    public static MeteorDefensePoolManager instance;
    [SerializeField]
    List<Building> buildings;
    [SerializeField]
    List<Meteor> meteors;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
