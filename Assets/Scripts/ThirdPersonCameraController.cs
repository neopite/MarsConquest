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
        
    }

    // Update is called once per frame
    void Update()
    {
        float dX = Input.GetAxis("Mouse X");
        float dY = Input.GetAxis("Mouse Y");
        dY = Mathf.Clamp(dY,-35, 60);
        mouseX += dX;
        mouseY -= dY;
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
