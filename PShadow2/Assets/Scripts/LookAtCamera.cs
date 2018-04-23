using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {
	
	//player refers to empty Player container, not the mesh object
    public GameObject player;
	
	// Update is called once per frame
	void LateUpdate () {
        transform.LookAt(player.transform);
	}
}
