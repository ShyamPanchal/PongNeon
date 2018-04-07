using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawn : MonoBehaviour {

    float spawnTimer;
    float staytimer;
    bool spawn;
    bool stay;
	// Use this for initialization
	void Start () {
        spawnTimer = 0.0f;
        spawn = true;
        stay = false;
        staytimer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(spawn == true)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer > 1.0f)
            {
                float xrange = Random.Range(1.5f,6.5f);
                float yrange = Random.Range(1.5f,4.0f);
                float randomX, randomY;
                randomX = ((Random.value) > 0.5 ? 1.0f : -1.0f) * xrange;
                randomY = ((Random.value) > 0.5 ? 1.0f : -1.0f) * yrange;
                this.transform.position = new Vector3(randomX,randomY,this.transform.position.z);
                spawn = false;
                stay = true;
                staytimer = 0.0f;
            }
        }
        if(stay == true)
        {
            staytimer += Time.deltaTime;
            if(staytimer > 50.0f)
            {
                this.transform.position = new Vector3(10.0f, 10.0f, this.transform.position.z);
                stay = false;
                spawn = true;
                spawnTimer = 0.0f;
            }
        }
	}

    public void setStayTimer(float timer)
    {
        Debug.Log(staytimer);
        staytimer = timer;
        Debug.Log(staytimer);
    }
}
