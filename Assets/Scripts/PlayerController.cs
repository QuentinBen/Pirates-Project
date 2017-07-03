using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private float veilSpeed;

	public float maxSpeed;

	enum speedState {stopped = 0, 
					 slow    = 3, 
					 medium  = 2,
					 fast    = 1};

	public speedState currentSpeedState;

	public float rotationSpeed = 100;

	private Rigidbody rb;

	// Use this for initialization
	void Start () 
	{
		veilSpeed = 0;

		currentSpeedState = speedState.stopped;

		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		if (Input.GetKeyDown (KeyCode.Z) && veilSpeed < maxSpeed) 
		{
			currentSpeedState = speedState[currentSpeedState + 1];
			Debug.Log (currentSpeedState);
		}

		if (Input.GetKeyDown (KeyCode.S) && veilSpeed > 0)
		{			
			
		}

		float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
		rotation *= Time.deltaTime;
		transform.Rotate(0, rotation, 0);

		rb.velocity = transform.right * maxSpeed/currentSpeedState;
	}
}
