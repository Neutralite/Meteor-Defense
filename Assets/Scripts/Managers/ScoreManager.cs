using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    [SerializeField]
    Text[] scoreTexts;
    int score = 0;
    public int Score
    {
        get => score;
        set
        {
            score = value;
            score = Mathf.Clamp(score, 0, 9999);
            scoreTexts[0].text = $"Score: {score}";
            scoreTexts[1].text = $"{score}";
        }
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
}
