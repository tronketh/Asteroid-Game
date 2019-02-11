using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayMenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject hud;
    [SerializeField]
    GameObject pauseMenu;
    [SerializeField]
    GameObject gameOverMenu;

    bool paused;
    bool gameover;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        gameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameover) {
            if (paused)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
            else {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }
        }
    }

    public void FinishGame() {
        int score = hud.GetComponent<HUD>().Score;
        if (PlayerPrefs.GetInt("Highscore") < score)
            PlayerPrefs.SetInt("Highscore",score);
        hud.SetActive(false);
        gameOverMenu.SetActive(true);
        gameOverMenu.GetComponent<GameOver>().score.text = "Score : " + score;
        Debug.Log(""+score);
    }
    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Quit()
    {
        SceneManager.LoadScene("Mainmenu");
    }
}
