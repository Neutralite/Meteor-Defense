using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    public static LeaderboardManager instance;
    [SerializeField]
    Dictionary<string, int> leaderboard;

    private void Start()
    {
        instance = this;
    }
    public void AddHighScore(int newScore)
    {

    }
}
