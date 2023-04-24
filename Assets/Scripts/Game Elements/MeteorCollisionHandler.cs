using UnityEngine;

public class MeteorCollisionHandler : MonoBehaviour
{
    [SerializeField]
    GameObject meteorAnchor;
    [SerializeField]
    Meteor meteorComponent;
    ObjectID scoreChangeID;
    private void OnCollisionEnter(Collision collision)
    {
        MeteorDefensePoolManager.instance.ReturnObject(meteorAnchor, ObjectID.Meteor);
        if (collision.gameObject.layer == GameManager.instance.planetLayer)
        {
            SupportFunctions.MoveBetweenLists(GameManager.instance.targetedCities, GameManager.instance.untargetedCities, meteorComponent.targetCity);

            scoreChangeID = ObjectID.Planet;
        }
        if (collision.gameObject.layer == GameManager.instance.cityLayer)
        {
            collision.gameObject.GetComponent<City>().health -= meteorComponent.size;

            if (collision.gameObject.GetComponent<City>().health <= 0)
            {
                MeteorDefensePoolManager.instance.ReturnObject(collision.transform.parent.gameObject, ObjectID.City);
            }
            else
            {
                SupportFunctions.MoveBetweenLists(GameManager.instance.targetedCities, GameManager.instance.untargetedCities, meteorComponent.targetCity);
            }
            scoreChangeID = ObjectID.City;
        }
        GetComponent<Meteor>().targetCity = null;
        ScoreManager.instance.Score += GameManager.instance.scoreChanges[scoreChangeID];
    }
}
