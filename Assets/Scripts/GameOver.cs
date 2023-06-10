using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public string main;
    public string game;

    public void LoadMain()
    {
        SceneManager.LoadScene(main);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(game);
        
    }
}
