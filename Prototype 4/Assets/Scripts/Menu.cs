using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void RestartGame() => SceneManager.LoadSceneAsync(0);
    public void QuitGame() => Application.Quit();
}
