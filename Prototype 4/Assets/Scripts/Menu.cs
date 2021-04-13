using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    AudioSource AS;
    void Awake()
    {
        AS = Camera.main.GetComponent<AudioSource>();
    }
    public void RestartGame()
    {   
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1;
    }
    public void QuitGame() => Application.Quit();
    public void PauseGame()
    {
        if (Time.timeScale == 1)
            Time.timeScale = 0;
        else Time.timeScale = 1;
    }
    public void OnOffMusic()
    {

        if (AS.isPlaying)
            AS.Stop();
        else AS.Play();
    }
}
