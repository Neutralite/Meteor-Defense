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
        //if (collision.gameObject.layer == GameManager2.instance.shieldLayer)
        //{
        //    SupportFunctions.MoveBetweenLists(GameManager2.instance.targetedCities, GameManager2.instance.untargetedCities, targetCity);
        //    ScoreManager.instance.Score += 5;
        //    return;
        //}

        //if (collision.gameObject.layer == GameManager2.instance.planetLayer)
        //{
        //    SupportFunctions.MoveBetweenLists(GameManager2.instance.targetedCities, GameManager2.instance.untargetedCities, targetCity);

        //    scoreChangeID = ObjectID.Meteor;
        //}

        //if (collision.gameObject.layer == GameManager2.instance.cityLayer)
        //{
        //    collision.gameObject.GetComponent<City>().health -= size;

        //    if (collision.gameObject.GetComponent<City>().health <= 0)
        //    {
        //        MeteorDefensePoolManager.instance.ReturnObject(collision.transform.parent.gameObject, ObjectID.City);
        //    }
        //    else
        //    {
        //        SupportFunctions.MoveBetweenLists(GameManager2.instance.targetedCities, GameManager2.instance.untargetedCities, targetCity);
        //    }
        //    scoreChangeID = ObjectID.Meteor;
        //}

        //GetComponent<Meteor>().targetCity = null;
        //ScoreManager.instance.Score += GameManager2.instance.scoreChanges[scoreChangeID];
        //MeteorDefensePoolManager.instance.ReturnObject(transform.parent.gameObject, ObjectID.Meteor);
    }
}
