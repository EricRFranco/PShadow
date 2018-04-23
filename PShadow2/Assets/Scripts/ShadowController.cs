using System.Collections;
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
        camera.transform.position = new Vector3(camera.transform.position.x, cameraYPos, camera.transform.position.z);
	}


    private void ChangeSize(bool grow)
    {
        int growFactor = (grow) ? 1 : -1;
        transform.localScale += new Vector3(0f, growFactor * scaleFactor, 0f);
        transform.localScale = new Vector3(1f, Mathf.Max(0f, transform.localScale.y), 1f);
    }

    private void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 forward = Vector3.forward;
        forward.Normalize();

        Vector3 desiredMovement = forward * vertical;
        transform.Translate(desiredMovement * moveSpeedFactor * Time.deltaTime);
        transform.Rotate(0f, horizontal, 0f);
    }
}
