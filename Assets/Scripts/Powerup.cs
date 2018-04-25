using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {
    public GameObject Player1;
    public GameObject Player2;
    public GameObject ball;
    PowerupSpawn ps;
    int player;
    float t;
    bool powerUpOn;
	// Use this for initialization
	void Start () {
        ps = GetComponent<PowerupSpawn>();
        t = 0;
        powerUpOn = false;
        player = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (powerUpOn)
        {
            t += Time.deltaTime;
        }
        if (t >= 5f)
        {
            //slow Mo
            //Time.timeScale = 1;
            if(player == 1)
            {
                Player1.transform.localScale += new Vector3(0f, -1f, 0f);
            }
            if (player == 2)
            {
                Player2.transform.localScale += new Vector3(-0.5f, -1f, 0f);
            }
            
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
                //slowMo Code
                /*
                Time.timeScale = 0.2f;
                */
                Player2.transform.localScale += new Vector3(0.5f,1f,0.0f);
                player = 2;
                powerUpOn = true;
                
                
            }
            else
            {
                //player 2 powerup
                Debug.Log("Plyer Left");

                //slowMo code
                //Time.timeScale = 0.2f;
                Player1.transform.localScale += new Vector3(0.5f, 1f, 0.0f);
                player = 1;
                powerUpOn = true;
                
            }
            collision.transform.localScale = new Vector3(2.0f, 2.0f, collision.transform.localScale.z);
            this.transform.position = new Vector3(30.0f, 30.0f, this.transform.position.z);
            ps.setStayTimer(10.0f);
        }
    }
}
