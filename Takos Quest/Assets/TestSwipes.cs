﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSwipes : MonoBehaviour {

	public float speedMovement;
	private Vector2 touchOrigin = -Vector2.one;
	public int horizontal = 0;     //Used to store the horizontal move direction.
	public int vertical = 0;       //Used to store the vertical move direction.
	private Rigidbody2D rbPlayer;

	void Start () {
		rbPlayer = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate(){

		if (Input.touchCount > 0) {
			//Store the first touch detected.
			Touch myTouch = Input.touches [0];

			//Check if the phase of that touch equals Began
			if (myTouch.phase == TouchPhase.Began) {
				//If so, set touchOrigin to the position of that touch
				touchOrigin = myTouch.position;
			}

		//If the touch phase is not Began, and instead is equal to Ended and the x of touchOrigin is greater or equal to zero:
		else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0) {
				//Set touchEnd to equal the position of this touch
				Vector2 touchEnd = myTouch.position;

				//Calculate the difference between the beginning and end of the touch on the x axis.
				float x = touchEnd.x - touchOrigin.x;

				//Calculate the difference between the beginning and end of the touch on the y axis.
				float y = touchEnd.y - touchOrigin.y;

				//Set touchOrigin.x to -1 so that our else if statement will evaluate false and not repeat immediately.
				touchOrigin.x = -1;

				//Check if the difference along the x axis is greater than the difference along the y axis.
				if (Mathf.Abs (x) > Mathf.Abs (y)) {
					//If x is greater than zero, set horizontal to 1, otherwise set it to -1
					horizontal = x > 0 ? 1 : -1;
				} else {
					//If y is greater than zero, set horizontal to 1, otherwise set it to -1
					vertical = y > 0 ? 1 : -1;
				}
			}
		}

		rbPlayer.velocity = new Vector2 (horizontal * speedMovement, vertical* speedMovement);

	}
}