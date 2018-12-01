using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float horizontalSpeed = 50.0f;
    public float verticalSpeed = 40.0f;

    public Rigidbody2D myRigidbody;

	// Use this for initialization
	void Start()
    {
		
	}
	
	// Update is called once per frame
	void Update()
    {
        Vector2 movement = Vector2.zero;

		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            movement.x -= horizontalSpeed;
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            movement.x += horizontalSpeed;
        }
        if(Input.GetKey(KeyCode.Space))
        {
            movement.y = verticalSpeed;
        }

        myRigidbody.AddForce(movement * Time.deltaTime);
	}
}
