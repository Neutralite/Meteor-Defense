using UnityEngine;

public class MeteorAttractor : MonoBehaviour
{
    [SerializeField]
    int meteorSpeed;
    void Update()
    {
        if (GameManager.Instance.gameState == GameState.Playing || GameManager.Instance.gameState == GameState.Cutscene)
        {
            foreach (GameObject item in ObjectPoolManager.Instance.objectPools[(int)ObjectID.Meteor].activeList)
            {
                Vector3 dir = meteorSpeed * Time.deltaTime * Vector2.down;
                item.transform.GetChild(0).transform.Translate(dir, Space.Self);
            }
        }
    }
}
