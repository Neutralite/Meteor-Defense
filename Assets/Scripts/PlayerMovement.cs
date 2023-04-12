using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    GameObject shield;
    bool bouncing,falling;
    float movementScale = 0.5f;
    float bounceScale = 0.01f;
    // Update is called once per frame
    void Update()
    {
        MoveShield();

        BounceShield();
    }

    private void MoveShield()
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
    }

    private void BounceShield()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !bouncing && !falling)
        {
            bouncing = true;
        }

        if (bouncing)
        {
            if (shield.transform.localPosition.z > -1)
            {
                shield.transform.localPosition -= bounceScale * Vector3.forward;
            }
            else
            {
                bouncing = false;
                falling = true;
            }
        }

        if (falling)
        {
            if (shield.transform.localPosition.z < 0)
            {
                shield.transform.localPosition += bounceScale * Vector3.forward;
            }
            else
            {
                shield.transform.localPosition = Vector3.zero;
                falling = false;
            }

        }
    }
}
