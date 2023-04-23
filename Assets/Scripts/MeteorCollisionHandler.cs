using UnityEngine;

public class MeteorCollisionHandler : MonoBehaviour
{
    [SerializeField] ObjectID scoreChangeID;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == GameManager.instance.meteorLayer)
        {
            MeteorDefensePoolManager.instance.ReturnObject(collision.transform.parent.gameObject,ObjectID.Meteor);
            ScoreManager.instance.Score += GameManager.instance.scoreChanges[scoreChangeID];
        }
    }
}
