using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    const float timetolive = 2;
    Timer deathtimer;

	// Use this for initialization
	void Start () {
        deathtimer=gameObject.AddComponent<Timer>();
        deathtimer.Duration = timetolive;
        deathtimer.Run();
	}
	
	// Update is called once per frame
	void Update () {
        if (!deathtimer.Running)
            Destroy(gameObject);
	}

    public void ApplyForce(Vector2 direction,float rotation) {
        const float force =13;
        GetComponent<Rigidbody2D>().AddForce(force: force * direction , mode: ForceMode2D.Impulse);
        gameObject.transform.Rotate(Vector3.forward,rotation);
    }
}
