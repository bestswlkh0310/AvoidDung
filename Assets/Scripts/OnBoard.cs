using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnBoard : MonoBehaviour
{
    public string scene;
    public void LoadGame() {
        SceneManager.LoadScene(scene);
    }
}
