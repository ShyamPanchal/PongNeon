using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    Vector3 originalPos;
    float shakeDuration = 0.0f;
    float shakeAmount = 0.7f;
    float decreaseFactor = 1.0f;
    public Camera c;

    void Start()
    {
        originalPos = c.transform.position;

        //originalPos = c.transform.localScale;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            c.transform.position = originalPos + Random.insideUnitSphere * shakeAmount;
            c.orthographicSize = 4.8f;
            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0.0f;
            c.transform.position = originalPos;
            c.orthographicSize = 5;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            shakeDuration = 0.2f;
        }
    }
    public void setDuration(float duration)
    {
        shakeDuration = duration;
    }
}
