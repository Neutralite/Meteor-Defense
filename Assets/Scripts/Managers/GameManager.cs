using System;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int cityLayer = 9, 
               meteorLayer = 10, 
               startingCities = 10, 
               meteorDelay = 10,
               meteorHeight = 30;

    public float timer,
                 meteorSpeed;

    public ScoreChange[] _scoreChanges;
    public Dictionary<ObjectID, int> scoreChanges = new();

    public GameState gameState = GameState.MainMenu;

    public List<GameObject> untargetedCities, targetedCities;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Time.timeScale = 0;
        foreach (ScoreChange item in _scoreChanges)
        {
            scoreChanges.Add(item.objectID, item.change);
        }
        Setup();
    }

    private void Setup()
    {
        MeteorDefensePoolManager.instance.ReleaseObjects(startingCities, ObjectID.City);
        untargetedCities = MeteorDefensePoolManager.instance.activeCities;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= meteorDelay && untargetedCities.Count > 0 &&gameState==GameState.Playing)
        {
            timer = 0;
            GameObject meteor = MeteorDefensePoolManager.instance.ReleaseObject(ObjectID.Meteor);
            GameObject city = untargetedCities[UnityEngine.Random.Range(0,untargetedCities.Count)];
            meteor.transform.rotation = city.transform.rotation;
            meteor.SetActive(true);
            SupportFunctions.MoveBetweenLists(GameManager.instance.untargetedCities, GameManager.instance.targetedCities, city);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void PauseGame(bool state)
    {
        Time.timeScale = state ? 0 : 1;
    }

    public void RestartGame()
    {
        MeteorDefensePoolManager.instance.ReturnAll();
        Setup();
    }
}

public enum GameState
{
    MainMenu,Cutscene,PauseMenu,Playing
}

public enum ObjectID
{
    Planet, City, Meteor
}

[Serializable]
public struct ScoreChange
{
    public ObjectID objectID; 
    public int change;
}