using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField]
    GameObject meteorAnchor;
    ObjectID scoreChangeID;
    public GameObject targetCity;
    public int size = 1;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == GameManager.instance.shieldLayer)
        {
            SupportFunctions.MoveBetweenLists(GameManager.instance.targetedCities, GameManager.instance.untargetedCities, targetCity);
            ScoreManager.instance.Score += GameManager.instance.scoreChanges[ObjectID.Shield];
            return;
        }

        if (collision.gameObject.layer == GameManager.instance.planetLayer)
        {
            SupportFunctions.MoveBetweenLists(GameManager.instance.targetedCities, GameManager.instance.untargetedCities, targetCity);

            scoreChangeID = ObjectID.Planet;
        }

        if (collision.gameObject.layer == GameManager.instance.cityLayer)
        {
            collision.gameObject.GetComponent<City>().health -= size;

            if (collision.gameObject.GetComponent<City>().health <= 0)
            {
                MeteorDefensePoolManager.instance.ReturnObject(collision.transform.parent.gameObject, ObjectID.City);
            }
            else
            {
                SupportFunctions.MoveBetweenLists(GameManager.instance.targetedCities, GameManager.instance.untargetedCities, targetCity);
            }
            scoreChangeID = ObjectID.City;
        }

        GetComponent<Meteor>().targetCity = null;
        ScoreManager.instance.Score += GameManager.instance.scoreChanges[scoreChangeID];
        MeteorDefensePoolManager.instance.ReturnObject(transform.parent.gameObject, ObjectID.Meteor);
    }
}
