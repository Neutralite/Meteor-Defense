using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;

    private void OnCollisionEnter(Collision collision)
    {
        transform.parent.gameObject.SetActive(false);
        transform.position = new(0, 25, 0);
        transform.rotation = Quaternion.identity;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        ObjectPoolManager.Instance.ReturnObject(transform.parent.gameObject);
    }
}
