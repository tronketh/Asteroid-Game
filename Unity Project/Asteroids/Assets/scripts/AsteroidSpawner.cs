using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Asteroid spawning
/// </summary>
public class AsteroidSpawner : MonoBehaviour {

    [SerializeField]
    GameObject prefabAsteroid;

    [SerializeField]
    Sprite whiteAsteroid;
    [SerializeField]
    Sprite greenAsteroid;
    [SerializeField]
    Sprite magentaAsteroid;

    float numRocks = 4;
    int totalNumRock = 4;
	// Use this for initialization
	void Start () {
        Vector3 position = Vector3.zero;
        position.x = ScreenUtils.ScreenRight;
        position.y = Random.Range(ScreenUtils.ScreenTop,ScreenUtils.ScreenBottom);
        position.z = 0;
        SpawnRock(position, new Vector3(0, 0, 0));

        position.x = ScreenUtils.ScreenLeft;
        position.y = Random.Range(ScreenUtils.ScreenTop, ScreenUtils.ScreenBottom);
        SpawnRock(position, new Vector3(0, 0, 0));

        position.x = Random.Range(ScreenUtils.ScreenLeft, ScreenUtils.ScreenRight);
        position.y = ScreenUtils.ScreenTop;
        SpawnRock(position, new Vector3(0, 0, 0));

        position.x = Random.Range(ScreenUtils.ScreenLeft, ScreenUtils.ScreenRight);
        position.y = ScreenUtils.ScreenBottom;
        SpawnRock(position,new Vector3(0,0,0));
    }

    public void SpawnRock(Vector3 initialPosition,Vector3 directionPosition) {
        GameObject asteroid = Instantiate<GameObject>(prefabAsteroid, initialPosition, Quaternion.identity) as GameObject;
        asteroid.GetComponent<Asteroid>().Initialize(directionPosition);
        int rand = Random.Range(0, 3);
        if (rand == 0)
        {
            asteroid.GetComponent<Asteroid>().SpriteRenderer.sprite = whiteAsteroid;
        }
        else if (rand == 1)
        {
            asteroid.GetComponent<Asteroid>().SpriteRenderer.sprite = greenAsteroid;
        }
        else if (rand == 2)
        {
            asteroid.GetComponent<Asteroid>().SpriteRenderer.sprite = magentaAsteroid;
        }
        Debug.Log("RockSpawned " + initialPosition);
    }
    public void SpawnRock(Vector3 directionPosition)
    {
        while (numRocks < totalNumRock)
        {
            int rand1 = Random.Range(0, 2);
            Vector3 initialPosition = new Vector3(0, 0, 0);
            if (rand1 == 0)
            {
                int rand3 = Random.Range(0, 2);
                if (rand3 == 0)
                    initialPosition.y = ScreenUtils.ScreenBottom;
                else
                    initialPosition.y = ScreenUtils.ScreenTop;

                initialPosition.x = Random.Range(ScreenUtils.ScreenLeft, ScreenUtils.ScreenRight);
            }
            else
            {
                int rand3 = Random.Range(0, 2);
                if (rand3 == 0)
                    initialPosition.x = ScreenUtils.ScreenLeft;
                else
                    initialPosition.x = ScreenUtils.ScreenRight;

                initialPosition.y = Random.Range(ScreenUtils.ScreenTop, ScreenUtils.ScreenBottom);
            }
            GameObject asteroid = Instantiate<GameObject>(prefabAsteroid, initialPosition, Quaternion.identity) as GameObject;
            asteroid.GetComponent<Asteroid>().Initialize(directionPosition);
            int rand2 = Random.Range(0, 3);
            if (rand2 == 0)
            {
                asteroid.GetComponent<Asteroid>().SpriteRenderer.sprite = whiteAsteroid;
            }
            else if (rand2 == 1)
            {
                asteroid.GetComponent<Asteroid>().SpriteRenderer.sprite = greenAsteroid;
            }
            else if (rand2 == 2)
            {
                asteroid.GetComponent<Asteroid>().SpriteRenderer.sprite = magentaAsteroid;
            }
            Debug.Log("RockSpawned " + initialPosition);
            numRocks += 1;
        }
    }
    public void RemoveRock() {
        numRocks -= 0.25f;
    }
    public void IncreaseTotalRock() {
        if(totalNumRock <= 10)
            totalNumRock += 1;
    }
}
