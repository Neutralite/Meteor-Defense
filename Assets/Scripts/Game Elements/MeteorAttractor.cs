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
                Vector3 dir = -item.transform.GetChild(0).position.normalized;
                Rigidbody rb = item.GetComponentInChildren<Rigidbody>();

                rb.AddForce(meteorSpeed * Time.deltaTime * dir);
            }
        }
    }
}
