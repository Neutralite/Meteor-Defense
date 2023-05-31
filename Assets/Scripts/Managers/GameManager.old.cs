using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{
    public static GameManager2 instance;

    public int planetLayer = 8,
               cityLayer = 9, 
               meteorLayer = 10,
               shieldLayer=11,
               startingCities = 10, 
               citiesIntialHealth = 1, 
               meteorDelay = 10,
               meteorHeight = 30;

    public float timer,
                 meteorSpeed;

    public ScoreChange[] _scoreChanges;
    public Dictionary<ObjectID, int> scoreChanges = new();


    public List<GameObject> untargetedCities, targetedCities;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {


        foreach (ScoreChange item in _scoreChanges)
        {
            scoreChanges.Add(item.objectID, item.change);
        }
        Setup();
    }

    private void Setup()
    {
        MeteorDefensePoolManager.instance.ReleaseObjects(startingCities, ObjectID.City);
        foreach (var item in MeteorDefensePoolManager.instance.activeCities)
        {
            untargetedCities.Add(item);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= meteorDelay && untargetedCities.Count > 0)
        {
            timer = 0;
            GameObject meteor = MeteorDefensePoolManager.instance.ReleaseObject(ObjectID.Meteor);
            GameObject city = untargetedCities[UnityEngine.Random.Range(0,untargetedCities.Count)];
            SupportFunctions.MoveBetweenLists(untargetedCities, targetedCities, city);
            meteor.GetComponentInChildren<Meteor>().targetCity = city;
            meteor.transform.rotation = city.transform.rotation;
            meteor.SetActive(true);
        }

        if (MeteorDefensePoolManager.instance.activeCities.Count == 0)
        {
            EndSession();
        }
    }

    public void EndSession()
    {
        PauseGame(true);
        if (ScoreManager.instance.Score < HighScoresManager.instance.scoreToBeat)
        {
            RestartGame();
        }
        else
        {
            MenuManager.instance.scoreSubmit.SetActive(true);
        }
    }

    public void PauseGame(bool state)
    {
        Time.timeScale = state ? 0 : 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}

[Serializable]
public struct ScoreChange
{
    public ObjectID objectID; 
    public int change;
}