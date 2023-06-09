using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField]
    Text[] scoreTexts;
    int score = 0;
    public int Score
    {
        get => score;
        set
        {
            score = value;
            scoreTexts[0].text = $"Score: {score}";
            scoreTexts[1].text = $"{score}";
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
