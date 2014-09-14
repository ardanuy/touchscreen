using UnityEngine;
using System.Collections;

public class RightControl : TouchInput {
	
	// show information about the touch
	public GUIText textCurrentPoint;
	public GUIText textPointDown;
	public GUIText textPointUp;
	public GUIText textXDistance;
	public GUIText textYDistance;
	public GUIText textDistance;
	
	public GUIText textAnimationName;
	
	
	// recognize gestures
	private Vector2 pointDown, pointUp;
	private bool defaultJumping = false;
	private bool touchMoving = false;

	private float xDistance = 0f;
	private float yDistance = 0f;
	private float distance = 0f;


	// tweaks 
	public float xPixelThreshold = 20;
	public float yPixelThreshold = 20;
	public float distanceThreshold = 0f;

	/**
	 * 
	 */
	void Awake(){
		textCurrentPoint.text = "Current (x,y)";
		textPointDown.text = "Down (x,y)";
		textPointUp.text = "Up (x,y)";
		textAnimationName.text = "Animation Name";
		
		pointDown = new Vector2 (0, 0);
		pointUp = new Vector2 (0, 0);
	}

	/**
	 * 
	 */
	void OnTouchUp(Vector2 hitPoint){
		pointUp = hitPoint;
		// debuging
		ShowInformation (hitPoint);
		// update distances
		xDistance = Mathf.Abs (pointDown.x - pointUp.x);
		yDistance = Mathf.Abs (pointDown.y - pointUp.y);
		distance = Vector2.Distance(pointDown, pointUp);

	} // end of OnTouchUp
	
	/**
	 * 
	 */
	void OnTouchDown(Vector2 hitPoint){
		pointDown = hitPoint;
		// debuging
		ShowInformation (hitPoint);
		
		
		
	} // end of OnTouchDown
	
	
	void OnTouchStay(Vector2 hitPoint){
		touchMoving = false;
		// debuging
		ShowInformation (hitPoint);


	} // end of OnToucStay
	
	
	/**
	 * 
	 */
	void OnTouchMove(Vector2 hitPoint){
		// player's finger is moving
		touchMoving = true;

		// update distances
		xDistance = Mathf.Abs (pointDown.x - hitPoint.x);
		yDistance = Mathf.Abs (pointDown.y - hitPoint.y);
		distance = Vector2.Distance(pointDown, hitPoint);

		// debuging
		ShowInformation (hitPoint);

	} // end of OnTouchMove
	
	
	/**
	 * 
	 */
	void OnTouchExit(Vector2 hitPoint){
		
		touchMoving = false;
		
		pointDown = new Vector2 (0, 0);
		pointUp = new Vector2 (0, 0);
	} // end of OnTouchExit
	
	
	
	/**
	 * 
	 */
	// ------------------------ Debuging ---------------------------------
	void ShowInformation(Vector2 hitPoint){
		textPointDown.text = "Down (" + pointDown.x + "," + pointDown.y + ")";
		textPointUp.text = "Up (" + pointUp.x + "," + pointUp.y + ")";
		textCurrentPoint.text = "Current (" + hitPoint.x + "," + hitPoint.y + ")";	
		textXDistance.text = "X distance = " + xDistance + " pixels";
		textYDistance.text = "Y distance = " + yDistance + " pixels";
		textDistance.text = "Distance = " + distance;

	}

	// ------------------------ Gesture Recognizer ----------------------------
	/**
	 * 
	 */
	private void GestureRecognition(){



	} // end of GestureRecognition

	/**
	 * 
	 */
	private void GestureManagement(){
		
	} // end of GestureManagement
}
