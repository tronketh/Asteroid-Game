using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A ship
/// </summary>
public class Ship : MonoBehaviour
{
    
    GameObject canvas;

    // thrust and rotation support
    Rigidbody2D rb2D;
    Vector2 thrustDirection = new Vector2(1, 0);
    const float ThrustForce = 10;
    const float RotateDegreesPerSecond = 180;

    [SerializeField]
    GameObject prefabBullet;

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{
		// saved for efficiency
        rb2D = GetComponent<Rigidbody2D>();
        canvas = GameObject.FindGameObjectWithTag("Canvas");
	}
	
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
        // check for rotation input
        float rotationInput = Input.GetAxis("Rotate");
        if (rotationInput != 0) {

            // calculate rotation amount and apply rotation
            float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
            if (rotationInput < 0) {
                rotationAmount *= -1;
            }
            transform.Rotate(Vector3.forward, rotationAmount);

            // change thrust direction to match ship rotation
            float zRotation = transform.eulerAngles.z * Mathf.Deg2Rad;
            thrustDirection.x = Mathf.Cos(zRotation);
            thrustDirection.y = Mathf.Sin(zRotation);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            Vector3 position = gameObject.transform.position;
            GameObject bullet = Instantiate(prefabBullet) as GameObject;
            bullet.transform.position = position;
            bullet.AddComponent<Bullet>();
            bullet.GetComponent<Bullet>().ApplyForce(thrustDirection, transform.eulerAngles.z);
        }
	}

    /// <summary>
    /// FixedUpdate is called 50 times per second
    /// </summary>
    void FixedUpdate()
    {
        // thrust as appropriate
        if (Input.GetAxis("Thrust") != 0)
        {
            rb2D.AddForce(ThrustForce * thrustDirection,
                ForceMode2D.Force);
        }
    }
    /// <summary>
    /// For collision detection
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        canvas.GetComponent<GameplayMenuManager>().FinishGame();
        Destroy(gameObject);
    }

}
