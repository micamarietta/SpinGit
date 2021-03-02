using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinController : MonoBehaviour
{

    float rotSpeed = 0;

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            this.rotSpeed = 10;
        }
     
        transform.Rotate(0, 0, this.rotSpeed);

        this.rotSpeed *= 0.96f;
    }
}
