using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {
    public GameObject Player1;
    public GameObject Player2;
    public GameObject ball;
    PowerupSpawn ps;
    float t;
    bool powerUpOn;
	// Use this for initialization
	void Start () {
        //ps = new PowerupSpawn();
        t = 0;
        powerUpOn = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (powerUpOn)
        {
            
            t += Time.deltaTime;
        }
        if (t >= 2f)
        {
            Time.timeScale = 1;
            powerUpOn = false;
            t = 0;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter");
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log(collision.transform.position.x);
            if (collision.transform.position.x > this.transform.position.x)
            {
                //player 1 powerup
                Debug.Log("Player right");
                Time.timeScale = 0.2f;
                powerUpOn = true;
                
            }
            else
            {
                //player 2 powerup
                Debug.Log("Plyer Left");
                Time.timeScale = 0.2f;
                powerUpOn = true;
            }
            //collision.transform.localScale = new Vector3(2.0f, 2.0f, collision.transform.localScale.z);
            //this.transform.position = new Vector3(30.0f, 30.0f, this.transform.position.z);
            //ps.setStayTimer(60.0f);
        }
    }
}
