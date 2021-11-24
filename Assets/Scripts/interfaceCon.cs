using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class interfaceCon : MonoBehaviour
{
    public GameObject MenuScreen;
    public GameObject DeadScreen;
    public Transform SpawnPoint;
    public GameObject Player;
    public AudioSource LevelMusic;
    public Text time;
    private float sec;
    private float min;
    public rbPlayerCon spielerCon;

    private void Update()
    {
        Clock();
        if (sec<=10)
        {
            time.text = "Time: " + min + ":0" + sec;
        }
        else
        {
            time.text = "Time: " + min + ":" + sec;
        }
    }
    


    void Clock()
    {
        sec += Time.deltaTime;
        if (sec>=60f)
        {
            sec = 0f;
            min++;
        }

    }

    public void StartGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void OpenMenu()
    {
        Time.timeScale = 0f;
        LevelMusic.Pause();
        spielerCon.allowtoMove = false;
        MenuScreen.SetActive(true);

    }

    public void OpenDeadScrren()
    {
        Time.timeScale = 0f;
        DeadScreen.SetActive(true);
        LevelMusic.Stop();
    }

    public void CloseMenu()
    {
        Time.timeScale = 1f;

        LevelMusic.UnPause();
        spielerCon.allowtoMove = true;
        MenuScreen.SetActive(false);
    }

    public void MainMenuSwitch()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);

    }

    public void ResetGame()
    {
        Player.transform.position = SpawnPoint.position;
        spielerCon.allowtoMove = true;
        LevelMusic.Stop();
        LevelMusic.Play();
        MenuScreen.SetActive(false);
        DeadScreen.SetActive(false);
        Time.timeScale = 1f;
        min = 0; sec = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
