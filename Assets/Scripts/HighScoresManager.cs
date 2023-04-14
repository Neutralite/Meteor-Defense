using System;
using UnityEngine;
using UnityEngine.UI;

public class HighScoresManager : MonoBehaviour
{
    [SerializeField]
    ScoreEntry[] highScores;
    [SerializeField]
    Text[] highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        LoadScores();
        UpdateLeaderboard();
    }

    private void LoadScores()
    {
        for (int i = 0; i < highScores.Length; i++)
        {
            highScores[i].name = PlayerPrefs.GetString($"name{i}", "AAA");
            highScores[i].score = PlayerPrefs.GetInt($"score{i}", 0);
        }
    }

    public void AddHighScore(ScoreEntry newEntry)
    {
        if (newEntry.score < highScores[highScores.Length - 1].score)
        {
            return;
        }
        if (newEntry.score > highScores[0].score)
        {
            highScores[0] = newEntry;
        }
        //highScores[highScores.Length - 1] = newEntry;
        //Array.Sort(highScores);
        SaveHighScores();
        UpdateLeaderboard();
    }

    void SaveHighScores()
    {
        for (int i = 0; i < highScoreText.Length; i++)
        {
            PlayerPrefs.SetString($"name{i}", highScores[i].name);
            PlayerPrefs.SetInt($"score{i}", highScores[i].score);
        }
    }

    void UpdateLeaderboard()
    {
        for (int i = 0; i < highScoreText.Length; i++)
        {
            highScoreText[i].text = $"{i + 1}. {highScores[i].name} {highScores[i].score}";
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            AddHighScore(
            new() { name = "afs", score = UnityEngine.Random.Range(0,999)}

            );
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}

[Serializable]
public class ScoreEntry
{
    public string name;
    public int score;
}