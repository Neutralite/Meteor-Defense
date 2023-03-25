using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldMovement : MonoBehaviour
{
    [SerializeField]
    GameObject shield;
    bool bouncing,falling;
    float movementScale = 0.5f;
    float rotationScale = 0.01f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.right * movementScale);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * movementScale);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.left * movementScale);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.down * movementScale);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !bouncing && !falling)
        {
            bouncing = true;
        }

        if (bouncing)
        {
            if (shield.transform.localPosition.z > -7)
            {
                shield.transform.localPosition -= rotationScale * Vector3.forward;
            }
            else
            {
                bouncing = false;
                falling = true;
            }
        }

        if (falling)
        {
            if (shield.transform.localPosition.z < -6)
            {
                shield.transform.localPosition += rotationScale * Vector3.forward;
            }
            else
            {
                shield.transform.localPosition = Vector3.forward * - 6;
                falling = false;
            }

        }
    }
}
