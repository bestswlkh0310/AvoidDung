using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static bool isGameOver;
    private Rigidbody _rb;
    public TextMeshProUGUI timerText;
    private float time;
    public float rotateYSensitivity;
    
    private float xInput;
    private float yInput;
    
    public float speed;

    private void OnValidate()
    {
        isGameOver = false;
    }

    private void Start() {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        Move();
        UpdateTimer();
        GetInput();
        Rotate();
    }
    
    

    private void Move() {
        var xPos = Input.GetAxisRaw("Horizontal");
        var zPos = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.forward * zPos + transform.right * xPos;

        _rb.MovePosition(transform.position + move.normalized * Time.deltaTime * speed);
    }

    private void Rotate()
    {
        transform.Rotate(0.0f, yInput * rotateYSensitivity, 0.0f);
    }

    private void UpdateTimer()
    {
        time += Time.deltaTime;
        timerText.text = "Time: " + (int)time + "s";
    }
    
    private void GetInput()
    {
        xInput = Input.GetAxisRaw("Mouse Y");
        yInput = Input.GetAxisRaw("Mouse X");
    }
}
