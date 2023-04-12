using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardSubmission : MonoBehaviour
{
    public static LeaderboardSubmission instance;



    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void AddHighScore(int score)
    {
        throw new NotImplementedException();
    }

    
}
