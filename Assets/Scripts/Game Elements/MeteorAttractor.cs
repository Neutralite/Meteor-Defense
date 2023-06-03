using UnityEngine;

public class MeteorAttractor : MonoBehaviour
{
    [SerializeField]
    int meteorSpeed;
    void Update()
    {
        if (GameManager.instance.gameState == GameState.Playing)
        {
            foreach (GameObject item in ObjectPoolManager.instance.objectPools[1].activeList)
            {
                Vector3 dir = -item.transform.GetChild(0).position.normalized;
                Rigidbody rb = item.GetComponentInChildren<Rigidbody>();

                rb.AddForce(meteorSpeed * Time.deltaTime * dir);
            }
        }
    }
}
