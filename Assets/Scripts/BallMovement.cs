using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour {
    CameraShake c;
    AudioSource a;
    Rigidbody2D rb;
	public int maxScore=3;
    public float speed;
    bool flag;
    float t;
	public Text player1Score;
	public Text player2Score;
    public AudioClip endgame;
    bool gameend = false;
    public GameObject backgroundMusic;
    public GameObject gameEndPanel;
    public GameObject mainPanel;
    float gameEndTime = 0;
    public Text GMtext;
	// Use this for initialization
	void Start () {
        a = GetComponent<AudioSource>();
        c = GetComponent<CameraShake>();
		player1Score.text = "0";
		player2Score.text = "0";
        rb = this.gameObject.GetComponent<Rigidbody2D>();
		/*float side = Random.value > 0.5f ? 1f : -1f;
		float rotation = Random.value;
		if (rotation < 0.5f && rotation > -0.5f) {
			rotation = (rotation/-rotation) *0.5f;
		}
		rb.velocity = new Vector2(side,rotation)* speed;*/
        flag = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (flag)
        {
            t = 0.0f;
        }
        else
        {
            t += Time.deltaTime;
        }
        if (t > 3.0f)
        {
            if (!gameend)
            {
                flag = true;
                float side = Random.value > 0.5f ? 1f : -1f;
                float rotation = Random.value;
                if (rotation < 0.3f && rotation > -0.3f)
                {
                    rotation = (rotation / -rotation) * 0.35f;
                }
                rb.velocity = new Vector2(side, rotation) * speed;
                //throws the ball
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void FixedUpdate()
    {
        if (rb.transform.position.x > 9f || rb.transform.position.x < -9f)
        {
            a.Play();
        }
        if(rb.transform.position.x > 9f || rb.transform.position.x < -9f)
        {
            shake();
        }
        if (rb.transform.position.x > 9f || rb.transform.position.x < -9f)
        {
			if (rb.transform.position.x > 8.5f) {
				player1Score.text = (int.Parse(player1Score.text) + 1).ToString();
			} else {
				player2Score.text = (int.Parse(player2Score.text) + 1).ToString();
            }
            rb.position = new Vector2(0.0f,0.0f);
            flag = false;
            rb.velocity = new Vector2(0f,0f) * speed;            
            //holds the ball back at the center.
        }
        if (!gameend)
        {
            if (int.Parse(player1Score.text) == maxScore || int.Parse(player2Score.text) == maxScore)
            {
                //play end game music
                
                AudioSource temp = backgroundMusic.GetComponent<AudioSource>();
                temp.Stop();
                
                a.clip = endgame;
                a.Play();
            }
            if (int.Parse(player1Score.text) == maxScore || int.Parse(player2Score.text) == maxScore)
            {
                if (int.Parse(player1Score.text) == maxScore)
                {
                    //player 1 win
                    GMtext.text += "Player 1 wins";
                }
                if (int.Parse(player2Score.text) == maxScore)
                {
                    //player 2 win
                    GMtext.text += "Player 2 wins";
                }
                gameend = true;
                Gameend();
                //game end situation
            }
        }
        
			
    }
    void Gameend()
    {
        //Destroy(mainPanel.gameObject);
        //gameEndTime += Time.deltaTime;
        Animator an = gameEndPanel.GetComponent<Animator>();
        if (an == null)
        {
            Debug.Log("null");
        }
        an.enabled = !an.enabled;
        
    }
    void shake()
    {
        c.setDuration(0.5f);
    }
}
