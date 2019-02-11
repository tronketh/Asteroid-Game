using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
    [SerializeField]
    Text scoreText;

    bool running;
    float elapsedSeconds;
    int score;
    [SerializeField]
    GameObject spawnerObj;
    [SerializeField]
    GameObject ship;
    AsteroidSpawner spawner;

    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
        }
    }

    // Use this for initialization
    void Start () {
        elapsedSeconds = 0;
        score = 0;
        spawner = spawnerObj.GetComponent<AsteroidSpawner>();

    }
	
	// Update is called once per frame
	void Update () {
        elapsedSeconds += Time.deltaTime;
        if (elapsedSeconds>=1) {
            score += 1;
            elapsedSeconds = 0;
            scoreText.text = "Score : " + score;
        }
        if (score%20 == 0) {
            spawner.SpawnRock(ship.transform.position);
        }
	}
      
}
