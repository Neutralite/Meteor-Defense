using UnityEngine;

public class Shield : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Meteor"))
        {
            ScoreManager.Instance.Score += 1;
        }
    }
}
