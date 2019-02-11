using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    Text highScore;
    [SerializeField]
    public Text score;
    // Start is called before the first frame update
    void Start()
    {
        highScore.text = "Highscore : " + PlayerPrefs.GetInt("Highscore");   
    }

    public void PlayAgain() {
        SceneManager.LoadScene("Gameplay");
    }
}
