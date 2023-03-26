using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField]
    Text scoreText;
    int score = 0;
    private void Start()
    {
        instance = this;
    }
    public void AddToScore(int value)
    {
        scoreText.text = $"Score: {score += value}";
    }
    public void ScoreToLeaderboard()
    {
        LeaderboardManager.instance.AddHighScore(score);
    }
}
