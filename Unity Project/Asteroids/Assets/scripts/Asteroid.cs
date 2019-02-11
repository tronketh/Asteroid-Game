using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// for asteroids
/// </summary>
public class Asteroid : MonoBehaviour {

    [SerializeField]
    GameObject nextAsteroid;
    [SerializeField]
    int lives;
    [SerializeField]
    GameObject ship;
    GameObject hud;

    AsteroidSpawner spawner;
    const float MinImpulseForce = 0.2f;
    const float MaxImpulseForce = 0.3f;

    private void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<AsteroidSpawner>();
        hud = GameObject.FindGameObjectWithTag("HUD");

    }
    public SpriteRenderer SpriteRenderer
    {
        get
        {
            return GetComponent<SpriteRenderer>();
        }
    }


    public void Initialize(Vector3 location)
    {
        Vector3 direction = location - transform.position;
        Rigidbody2D rgbd = GetComponent<Rigidbody2D>();
        rgbd.AddForce(Random.Range(MinImpulseForce, MaxImpulseForce) * direction, ForceMode2D.Impulse);
     }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet"){
            Destroy(collision.gameObject);
            if (lives > 0)
            {
                GameObject asteroid1 = Instantiate<GameObject>(nextAsteroid, transform.position, Quaternion.identity);
                float angle1 = Random.Range(0, 2 * Mathf.PI);
                Vector2 moveDirection1 = new Vector2(
                Mathf.Cos(angle1), Mathf.Sin(angle1));
                float magnitude1 = Random.Range(MinImpulseForce, MaxImpulseForce);
                asteroid1.GetComponent<Rigidbody2D>().AddForce(
                    moveDirection1 * magnitude1,
                    ForceMode2D.Impulse);
                asteroid1.GetComponent<SpriteRenderer>().sprite = SpriteRenderer.sprite;

                GameObject asteroid2 = Instantiate<GameObject>(nextAsteroid, transform.position, Quaternion.identity);
                float angle2 = Random.Range(0, 2 * Mathf.PI);
                Vector2 moveDirection2 = new Vector2(
                Mathf.Cos(angle2), Mathf.Sin(angle2));
                float magnitude2 = Random.Range(MinImpulseForce, MaxImpulseForce);
                asteroid2.GetComponent<Rigidbody2D>().AddForce(
                    moveDirection2 * magnitude2,
                    ForceMode2D.Impulse);
                asteroid2.GetComponent<SpriteRenderer>().sprite = SpriteRenderer.sprite;
            }
            else {
                spawner.RemoveRock();
                spawner.SpawnRock(ship.transform.position);
            }
            hud.GetComponent<HUD>().Score+=lives*2 +1;
            Destroy(gameObject);
        }
    }

}
