using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private float xInput;
    private float yInput;
    private float xRotation;

    private Vector3 offSet;

    private void Start()
    {
        offSet = transform.position - player.transform.position;
    }

    void Update()
    {
        Rotate();
        Move();
        GetInput();
    }

    private void Rotate()
    {
        xRotation -= xInput;
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);
        
        transform.rotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, player.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }

    private void Move()
    {
        transform.position = player.transform.position + offSet;
    }

    private void GetInput()
    {
        xInput = Input.GetAxisRaw("Mouse Y");
        yInput = Input.GetAxisRaw("Mouse X");
        
    }
}
