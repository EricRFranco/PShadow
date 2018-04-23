using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {

    public GameObject player;
	
	// Update is called once per frame
	void LateUpdate () {
        transform.LookAt(player.transform);
	}
}
