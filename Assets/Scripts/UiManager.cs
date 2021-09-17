using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    //int say = 0;
    //float tm;

    Scene currentScene;
    string sceneName;

    [Header("Canvas")]
    public GameObject CanvasGame;
    public GameObject CanvasRestart;
    public GameObject PauseGame;
    public GameObject panel;
    public GameObject ModePanel;

    [Header("CanvasRestart")]
    public GameObject WinTxt;
    public GameObject LoseTxt;

    [Header("Other")]
    public ScoreScript scoreScript;

    public GameObject bluePlayer;
    public PuckScript puckScript;
    public PlayerMovement playerMovement;
    public AiScript aiScript;
    public Sprite BlueWin;
    public Sprite RedWin;
    public GameObject PauseBtn;

    //public GameObject TextDNM;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        if (SceneManager.GetActiveScene().name != "StartMenu")
        {
            Time.timeScale = 0f;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
    }
    public void ShowRestartCanvas(bool didAiWin)
    {
        Time.timeScale = 0f;

        CanvasGame.SetActive(false);
        CanvasRestart.SetActive(true);

        if (didAiWin)
        {
            panel.GetComponent<Image>().sprite = BlueWin;
        }
        else
        {
            panel.GetComponent<Image>().sprite = RedWin;
        }
    }

    private void Update()
    {
        /*tm = tm + Time.deltaTime;
        say = Convert.ToInt32(tm);
        if (say%2==1)
        {
            TextDNM.transform.localScale = new Vector3(TextDNM.transform.localScale.x + 0.005f, TextDNM.transform.localScale.y + 0.005f, 1);
            
        }
        if (say % 2 == 0 && TextDNM.transform.localScale.x > 0)
        {
            TextDNM.transform.localScale = new Vector3(TextDNM.transform.localScale.x - 0.005f, TextDNM.transform.localScale.y - 0.005f, 1);
        }
        if (say == 8)
        {
            TextDNM.GetComponent<Text>().text = "Game table empty!";
            TextDNM.GetComponent<Text>().color = Color.green;
        }*/
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (CanvasRestart.activeInHierarchy == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
            else if (PauseGame.activeInHierarchy == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
            else if (CanvasRestart.activeInHierarchy == false && PauseGame.activeInHierarchy == false)
            {
                PauseGame.SetActive(true);
            }

            
        }
    }

    public void RestartGame()
    {
        /*Time.timeScale = 1f;

        CanvasGame.SetActive(true);
        CanvasRestart.SetActive(false);
        PauseGame.SetActive(false);
        scoreScript.ResetScores();
        puckScript.CenterPuck();
        PauseBtn.SetActive(true);

        playerMovement.ResetPosition();
        aiScript.ResetPosition();
        Time.timeScale = 0f;*/
        SceneManager.LoadScene("GameScene");
    }

    public void GoToMenu()
    {
        Time.timeScale = 1.0f;
        PlayerPrefs.SetInt("GameMode", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    public void OnePlayer()
    {
        ModePanel.SetActive(true);
    }

    public void TwoPlayer()
    {
        PlayerPrefs.SetInt("GameMode", 2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Pause()
    {
        PauseBtn.SetActive(false);
        Time.timeScale = 0f;
        PauseGame.SetActive(true);
    }

    public void Back()
    {
        Time.timeScale = 1f;
        PauseBtn.SetActive(true);
        PauseGame.SetActive(false);
    }

    public void Easy()
    {
        PlayerPrefs.SetInt("ModeSpeed", 5);
        PlayerPrefs.SetInt("GameMode", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Medium()
    {
        PlayerPrefs.SetInt("ModeSpeed", 10);
        PlayerPrefs.SetInt("GameMode", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Hard()
    {
        PlayerPrefs.SetInt("ModeSpeed", 20);
        PlayerPrefs.SetInt("GameMode", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Impossible()
    {
        PlayerPrefs.SetInt("ModeSpeed", 30);
        PlayerPrefs.SetInt("GameMode", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CloseBtn()
    {
        ModePanel.SetActive(false);
    }
}
