using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    public static LeaderboardManager instance;
    [SerializeField]
    List<int> highScores = new List<int>();

    private void Start()
    {
        instance = this;
    }
    public void AddHighScore(int newScore)
    {

    }
}
