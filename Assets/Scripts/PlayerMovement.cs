using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public string axis;
	public int x;
    Rigidbody2D rb;
    public Boundary boundary;
    AudioSource a;

    public void Start()
    {
        a = this.GetComponent<AudioSource>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate(){
		float vertical = Input.GetAxis (axis);
		Vector2 movement = new Vector2 (0.0f, vertical);
		//Debug.Log ("v = "+movement.ToString());
		
		rb.velocity = movement * x;
        rb.position = new Vector2(Mathf.Clamp(rb.position.x,rb.position.x,rb.position.x),Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax));
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            a.Play();
        }
        
    }
}
[System.Serializable]
public class Boundary
{
    public float yMin, yMax;
}
