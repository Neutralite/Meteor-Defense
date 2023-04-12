using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    MeteorDefensePoolManager poolManger;
    public int meteorLayer = 10, 
               buildingHit = -10, 
               planetHit = 10,
               meteorDelay = 10;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Time.timeScale = 0;
        poolManger.ReleaseObject(10, "City");
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
