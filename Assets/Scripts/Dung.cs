using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Dung : MonoBehaviour
{
    private string baseUrl = "http://127.0.0.1:8090/avoid-dung/";

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
            StartCoroutine(UpdateRanking(OnBoard.UserNickName, myScore));
        }
    }

    private IEnumerator UpdateRanking(string nickName, int score)
    {
        byte[] data = Encoding.UTF8.GetBytes("{\"nickName\": \""+ nickName + "\", \"score\": " + score + "}");
        UnityWebRequest req = UnityWebRequest.Put(baseUrl + "ranking/", data);
        req.SetRequestHeader("Content-Type", "application/json");
        yield return req.SendWebRequest();
        
        if (req.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("www error");
        }
        else
        {
            string result = req.downloadHandler.text;
            Debug.Log("complete : " + result);
        }
    }
}
