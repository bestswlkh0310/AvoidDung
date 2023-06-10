using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Dung : MonoBehaviour
{
    private Material dungMaterial;
    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        dungMaterial = GetComponent<Renderer>().material;
        float fadeCnt = 0.0f;
        while (fadeCnt < 1.0f)
        {
            fadeCnt += 0.04f;
            dungMaterial.color = new Color(205 / 255.0f, 100 / 255.0f, 32 / 255.0f, fadeCnt);
            yield return new WaitForSeconds(0.1f);
            Debug.Log(fadeCnt);
        }
    }
    
    private void Update()
    {
        Rotate();
        DestroyDung();
    }

    private void Rotate()
    {
        transform.Rotate(0, 3, 0);
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
            PlayerController.IsGameOver = true;
            SceneManager.LoadScene("GameOver");
            var myScore = (int)PlayerController.Time;

            if (PlayerPrefs.HasKey("bestScore"))
            {
                var bestScore = PlayerPrefs.GetInt("bestScore");
                
                if (bestScore < myScore)
                {
                    PlayerPrefs.SetInt("bestScore", myScore);
                }
            }
            else
            {
                PlayerPrefs.SetInt("bestScore", myScore);
            }
        }
    }
}
