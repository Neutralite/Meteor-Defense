using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMovement : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0)
            transform.Rotate(new(0, 0.1f));

    }
}
