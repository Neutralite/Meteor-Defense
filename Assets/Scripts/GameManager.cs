using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    CutsceneManager cutsceneManager;
    [SerializeField]
    MeteorDefensePoolManager poolManger;
    [SerializeField]
    GameObject gameUI;
    public int meteorLayer = 10, 
               startingCities = 10, 
               buildingHit = -10, 
               planetHit = 10,
               meteorDelay = 10;
    float timer;

    public GameState gameState = GameState.MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Time.timeScale = 0;
        poolManger.ReleaseObject(startingCities, "City");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
        }
        timer += Time.deltaTime;

        if (timer >= meteorDelay)
        {
            timer = 0;
            poolManger.ReleaseObject(1, "Meteor");
        }
    }
}

public enum GameState
{
    MainMenu,Cutscene,PauseMenu,Playing
}