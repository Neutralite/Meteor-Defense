using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    float speed = 1f;
    void FixedUpdate()
    {
        Vector3 diff = transform.position - GameManager.instance.transform.position;
        rb.AddForce(-diff.normalized * speed * rb.mass);
    }
}
