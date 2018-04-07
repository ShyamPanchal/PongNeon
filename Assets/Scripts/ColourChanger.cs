using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChanger : MonoBehaviour {
    SpriteRenderer sr;
    float t;
	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        sr.color = Color.white;
        t = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (t > 3.0f)
        {
            t = 0f;
            sr.color = Random.ColorHSV(0.2f,0.5f,1,1,0.5f,1,1,1);
        }
        else
        {
            t += Time.deltaTime;
        }
	}
}
