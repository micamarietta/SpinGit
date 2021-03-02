using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpinController : MonoBehaviour
{

    float rotSpeed = 0;
    public GameObject spinnerButton;

    private void Update()
    {

        if (Input.GetMouseButtonDown(0) && EventSystem.current.currentSelectedGameObject == spinnerButton)
        {
            this.rotSpeed = 20;
        }

        transform.Rotate(0, 0, this.rotSpeed);

        this.rotSpeed *= 0.96f;
    }
}
