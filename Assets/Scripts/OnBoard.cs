using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnBoard : MonoBehaviour
{
    private string baseUrl = "http://127.0.0.1:8090/avoid-dung/";
    public string scene;
    public string baseText;
    public TextMeshProUGUI bestScoreText;
    public TMP_InputField userNickNameText;
    private static string UserNickName;
    public void LoadGame() {
        UserNickName = userNickNameText.text;
        if (userNickNameText.text == "")
        {
            Debug.Log("올바른 닉네임을 입력해주세요.");
        }
        else
        {
            SceneManager.LoadScene(scene);
        }
    }

    private void Start()
    {
        LoadNickName();
        LoadBestScore();
        StartCoroutine(LoadRanking());
    }

    private IEnumerator LoadRanking()
    {
        UnityWebRequest req = UnityWebRequest.Get(baseUrl + "ranking/");
        yield return req.SendWebRequest();

        if (req.isNetworkError || req.isHttpError)
        {
            Debug.Log("www error");
        }
        else
        {
            string result = req.downloadHandler.text;
            Debug.Log("complete : " + result);
        }
    }

    private void LoadNickName()
    {
        if (UserNickName != "")
        {
            userNickNameText.text = UserNickName;
        }

    }

    private void LoadBestScore()
    {
        if (PlayerPrefs.HasKey("bestScore"))
        {
            bestScoreText.text = baseText + PlayerPrefs.GetInt("bestScore") + "s";
        }
        else
        {
            bestScoreText.text = baseText + "0s";
        }
    }
}
