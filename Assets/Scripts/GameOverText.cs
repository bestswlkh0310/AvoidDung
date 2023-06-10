using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverText : MonoBehaviour
{
    public string resultText;
    private TextMeshProUGUI gameOverText;
    
    void Start()
    {
        StartCoroutine(TypingGameOverText());
        gameOverText = GetComponent<TextMeshProUGUI>();
    }

    private IEnumerator TypingGameOverText()
    {
        var currentText = "";

        yield return new WaitForSeconds(0.5f);
        foreach (var chr in resultText)
        {
            currentText += chr;
            gameOverText.text = currentText;
            yield return new WaitForSeconds(0.3f);

        }
    }
}
