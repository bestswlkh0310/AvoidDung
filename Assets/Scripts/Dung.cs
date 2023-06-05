using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dung : MonoBehaviour
{
    void Update()
    {
        DestroyDung();
    }

    private void DestroyDung()
    {
        if (transform.position.y < 0.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("충돌함 ㅋ");
            PlayerController.isGameOver = true;
        }
    }
}
