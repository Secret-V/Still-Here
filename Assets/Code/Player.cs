using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float horizontalSpeed = 50.0f;
    public float verticalSpeed = 40.0f;

    public float dashForceMultiplier = 5.0f;

    public ForceMode2D dashForceMode;

    public float maxFuel = 100.0f;
    public float fuel = 100.0f;
    public float fuelDecreasePerSecond = 50.0f;
    public float fuelIncreasePerSecond = 100.0f;

    public Rigidbody2D myRigidbody;

	// Use this for initialization
	void Start()
    {
		
	}

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 200), fuel.ToString());
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
        if(Input.GetKey(KeyCode.Space) && fuel > .0f)
        {
            movement.y = verticalSpeed;
            fuel -= fuelDecreasePerSecond * Time.deltaTime;
            if(fuel < .0f) fuel = .0f;
        }
        else if(!Input.GetKey(KeyCode.Space))
        {
            fuel += fuelIncreasePerSecond * Time.deltaTime;
            if(fuel > maxFuel) fuel = maxFuel;
        }

        myRigidbody.AddForce(movement * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.F))
        {
            myRigidbody.AddForce(movement * dashForceMultiplier * Time.deltaTime, dashForceMode);
        }
	}
}
