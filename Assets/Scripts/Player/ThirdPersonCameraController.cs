using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    public Transform Player;
    public Transform CameraTransform;
    [SerializeField] private float _rotationSpeed = 1f;
    private float mouseX, mouseY;
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float dX = Input.GetAxis("Mouse X");
        float dY = Input.GetAxis("Mouse Y");
       
        dY = Mathf.Clamp(dY,-10, 10);
        dX = Mathf.Clamp(dX, -2, 2);
        mouseX += dX;
        mouseY -= dY;
        mouseY = Mathf.Clamp(mouseY, 0, 22);
        transform.LookAt(CameraTransform);
        if (Input.GetMouseButton(1))
        {
            CameraTransform.rotation = Quaternion.Euler(mouseY*_rotationSpeed , mouseX*_rotationSpeed , 0);
        }
        else
        {
            CameraTransform.rotation = Quaternion.Euler(mouseY*_rotationSpeed , mouseX*_rotationSpeed , 0);
            Player.rotation = Quaternion.Euler(0,mouseX*_rotationSpeed,0);   
        }
    }
}
