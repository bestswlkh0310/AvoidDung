using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private float xInput;
    private float yInput;

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
        transform.Rotate(new Vector3(-xInput, 0.0f, 0.0f));
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
