﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowController : MonoBehaviour {

    //public variables
    public float scaleFactor;
    public float moveSpeedFactor;

    //private variables
    [SerializeField]
    ParticleSystem myParticles;
    [SerializeField]
    Camera camera;

    float initHeight;
    float shrinkTimer = 0f;
    float cameraYPos;

	// Use this for initialization
	void Start () {
        cameraYPos = camera.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        MovePlayer();
        //Lock camera to default yPos (for now)
        camera.transform.position = new Vector3(camera.transform.position.x, cameraYPos, camera.transform.position.z);
	}


    private void ChangeSize(bool grow)
    {
        //grow if true, shrink if false
        int growFactor = (grow) ? 1 : -1;
        transform.localScale += new Vector3(0f, growFactor * scaleFactor, 0f);
        //ensure GameObject does not shrink past scale y = 0
        transform.localScale = new Vector3(1f, Mathf.Max(0f, transform.localScale.y), 1f);
    }

    private void MovePlayer()
    {
        //retrieve input values
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //normalize the GameObject's normal vector to retrieve
        //current facing direction
        Vector3 forward = Vector3.forward;
        forward.Normalize();
        //scale the normalized vector by the vertical axis value
        Vector3 desiredMovement = forward * vertical;
        transform.Translate(desiredMovement * moveSpeedFactor * Time.deltaTime);
        //rotate according to horizontal axis value
        transform.Rotate(0f, horizontal, 0f);
    }
}
