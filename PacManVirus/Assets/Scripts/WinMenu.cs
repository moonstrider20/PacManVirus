using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public string newGameScene;

    public AudioClip bgMusic;
    public AudioSource musicSource;

    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = bgMusic;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewGame()
    {
        SceneManager.LoadScene(newGameScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
