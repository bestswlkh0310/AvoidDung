using System;
using System.Collections;
using Palmmedia.ReportGenerator.Core.Common;
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
    private RankingResponse rankingResponse;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI rankingText;
    public TMP_InputField userNickNameText;
    public static string UserNickName;
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
        // 점수 초기화 (임시)
        // PlayerPrefs.SetInt("bestScore", 1);

        LoadNickName();
        LoadBestScore();
        StartCoroutine(LoadRanking());
    }

    private IEnumerator LoadRanking()
    {
        UnityWebRequest req = UnityWebRequest.Get(baseUrl + "ranking/");
        yield return req.SendWebRequest();

        if (req.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("www error");
        }
        else
        {
            string result = req.downloadHandler.text;
            rankingResponse = JsonUtility.FromJson<RankingResponse>(result);
            Debug.Log("complete : " + result + "\n" + rankingResponse.status);
            UpdateRankingText();
        }
    }

    private void UpdateRankingText()
    {
        string text = "- Ranking -\n";
        foreach (var rankingData in rankingResponse.data)
        {
            text += rankingData.nickName + ": " + rankingData.score + "s\n";
        }

        rankingText.text = text;
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
