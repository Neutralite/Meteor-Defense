using UnityEngine;

public class Shield : MonoBehaviour
{
    public static int scoreIncrease;

   void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Meteor"))
        {
            if (collision.gameObject.GetComponent<Meteor>().notBlocked)
            {
                ScoreManager.Instance.Score += scoreIncrease;
            }
        }
    }
}
