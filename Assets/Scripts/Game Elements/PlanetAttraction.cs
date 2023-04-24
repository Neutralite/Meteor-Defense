using UnityEngine;

public class PlanetAttraction : MonoBehaviour
{
    void Update()
    {
        foreach (GameObject item in MeteorDefensePoolManager.instance.activeMeteors)
        {
            Vector3 diff = item.transform.GetChild(0).position - Vector3.zero;
            Rigidbody rb = item.GetComponentInChildren<Rigidbody>();
            rb.AddForce(GameManager.instance.meteorSpeed * Time.deltaTime * -diff.normalized);
        }
    }
}
