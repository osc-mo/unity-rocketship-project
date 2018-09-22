using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour {

    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 2f;

    //todo remove from inspector later
    float movementFactor; //0 for not moved; 1 for fully moved 

    Vector3 startingPos;

	// Use this for initialization
	void Start () {
        startingPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //protect against period being zero
        CheckPeriod();


        float cycles = Time.time / period; //grows continually from zero

        const float tau = Mathf.PI * 2f; //about 6.28
        float rawSineWave = Mathf.Sin(cycles * tau);

        movementFactor = rawSineWave / 2f + .5f; //goes from -1 to +1

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
	}

    void CheckPeriod()
    {
        if (period <= Mathf.Epsilon) {
            return;
        }
    }
}
