using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject explosion;

    private void Update()
    {
        if (explosion != null && explosion.GetComponent<Explosion>().eraseAffected)
        {
            Despawn();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (explosion == null)
        {
            explosion = ObjectPoolManager.Instance.ReleaseObject(ObjectID.Explosion);
            explosion.transform.position = transform.position;
            explosion.SetActive(true);
        }
    }

    private void Despawn()
    {
        explosion = null;
        transform.parent.gameObject.SetActive(false);
        transform.localPosition = new(0, 25, 0);
        transform.localRotation = Quaternion.identity;
        ObjectPoolManager.Instance.ReturnObject(transform.parent.gameObject);
    }
}
