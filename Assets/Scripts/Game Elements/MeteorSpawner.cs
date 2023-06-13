using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField]
    int spawnDelay;
    float timer;
    private void Update()
    {
        if (GameManager.Instance.gameState == GameState.Playing)
        {
            timer += Time.deltaTime;
            if (timer >= spawnDelay)
            {
                SpawnMeteor();
                timer = 0;
            }
        }
    }
    void SpawnMeteor()
    {
        GameObject meteor = ObjectPoolManager.Instance.ReleaseObject(ObjectID.Meteor);
        meteor.transform.rotation = Random.rotation;
        meteor.SetActive(true);
    }
}
