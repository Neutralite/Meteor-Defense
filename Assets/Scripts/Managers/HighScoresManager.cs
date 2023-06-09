using System;
using UnityEngine;
using UnityEngine.UI;

public class HighScoresManager : MonoBehaviour
{
    public static HighScoresManager instance;
    [SerializeField]
    ScoreEntry[] highScores = new ScoreEntry[5];
    [SerializeField]
    Text[] highScoreText;
    public int scoreToBeat;
    [SerializeField]
    InputField nameInput;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        LoadScores();
        UpdateLeaderboard();
        scoreToBeat = highScores[^1].score;
    }

    void LoadScores()
    {
        for (int i = 0; i < highScores.Length; i++)
        {
            highScores[i].name = PlayerPrefs.GetString($"name{i}", "AAA");
            highScores[i].score = PlayerPrefs.GetInt($"score{i}", 0);
        }
    }

    public void AddHighScore()
    {
        ScoreEntry newEntry = new() { name = nameInput.text, score = ScoreManager.instance.Score };
        highScores[^1] = newEntry;
        for (int i = highScores.Length - 1; i > 0; i--)
        {
            if (highScores[i].score > highScores[i-1].score)
            {
                highScores[i] = highScores[i - 1];
                highScores[i - 1] = newEntry;
            }
            else
            {
                break;
            }
        }
        UpdateLeaderboard();
        SaveHighScores();
    }

    void UpdateLeaderboard()
    {
        for (int i = 0; i < highScoreText.Length; i++)
        {
            highScoreText[i].text = $"{i + 1}. {highScores[i].name} {highScores[i].score}";
        }
    }

    void SaveHighScores()
    {
        for (int i = 0; i < highScoreText.Length; i++)
        {
            PlayerPrefs.SetString($"name{i}", highScores[i].name);
            PlayerPrefs.SetInt($"score{i}", highScores[i].score);
        }
    }
}

[Serializable]
public class ScoreEntry
{
    public string name;
    public int score;
}