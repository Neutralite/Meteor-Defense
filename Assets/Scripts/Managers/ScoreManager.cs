using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField]
    Text scoreText;
    int score = 0;
    public int Score
    {
        get => score;
        set
        {
            score = value;
            scoreText.text = $"Score: {score}";
        }
    }
    private void Start()
    {
        instance = this;
    }
}
