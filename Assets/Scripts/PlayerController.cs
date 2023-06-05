using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static bool isGameOver = false;
    private Rigidbody _rb;
    public TextMeshProUGUI timerText;
    private float time = 0.0f;
    
    public float speed;
    
    private void Start() {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        Move();
        UpdateTimer();
        
    }

    private void Move() {
        var xPos = Input.GetAxisRaw("Horizontal");
        var zPos = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(xPos, 0.0f, zPos).normalized * speed;
        
        _rb.MovePosition(transform.position + move * Time.deltaTime);
    }

    private void UpdateTimer()
    {
        time += Time.deltaTime;
        if (isGameOver == false)
        {
            timerText.text = "Time: " + (int)time + "s";
        }
        else
        {
            timerText.text = "gameOver";
            
        }
    }
}
