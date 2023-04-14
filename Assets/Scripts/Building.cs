using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == GameManager.instance.meteorLayer)
        {
            MeteorDefensePoolManager.instance.ReturnObject(collision.transform.parent.gameObject);
            ScoreManager.instance.AddToScore(GameManager.instance.buildingHit);
        }
    }
}
