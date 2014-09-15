/*
 * 
 * 8-point Compass Rose system for gestures
 * North		N	  0°				Jump Up
 * North-East	NE	 45° (45°×1)		Normal Jumping Forward
 * East			E	 90° (45°×2)		Turn Right (turn 180)
 * South-East	SE	135° (45°×3)	
 * South		S	180° (45°×4)	Roll
 * South-West	SW	225° (45°×5)	
 * West			W	270° (45°×6)	Turn Left (turn 180)
 * North-West	NW	315° (45°×7)	Normal Jumping Forward
 * 
 * 
 * 
 */ 
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

	private float xDistance = 0f;
	private float yDistance = 0f;
	private float distance = 0f;

	private string currentAnimation;


	// tweaks 
	public float xPixelDistanceThreshold = 50f;
	public float yPixelDistanceThreshold = 50f;
	public float distanceThreshold = 20f;

	/**
	 * 
	 */
	void Awake(){
		textCurrentPoint.text = "Current (x,y)";
		textPointDown.text = "Down (x,y)";
		textPointUp.text = "Up (x,y)";
		textAnimationName.text = "Current Animation";
		
		pointDown = new Vector2 (0, 0);
		pointUp = new Vector2 (0, 0);
	}

	/**
	 * 
	 */
	void OnTouchUp(Vector2 hitPoint){
		pointUp = hitPoint;

		// update distances
		UpdateDistances (hitPoint);

		// look which gesture was made
		GestureRecognition ();

		// debuging
		ShowInformation (hitPoint);
	} // end of OnTouchUp
	
	/**
	 * 
	 */
	void OnTouchDown(Vector2 hitPoint){
		pointDown = hitPoint;
		// debuging
		//ShowInformation (hitPoint);	
	} // end of OnTouchDown
	
	
	void OnTouchStay(Vector2 hitPoint){
		// debuging
		ShowInformation (hitPoint);
	} // end of OnToucStay
	
	
	/**
	 * 
	 */
	void OnTouchMove(Vector2 hitPoint){
		// update distances
		//UpdateDistances (hitPoint);

		// debuging
		ShowInformation (hitPoint);
	} // end of OnTouchMove
	
	
	/**
	 * 
	 */
	void OnTouchExit(Vector2 hitPoint){
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
		textAnimationName.text = "Current Animation: " + currentAnimation;

	}


	// ------------------------ Gesture Recognizer ----------------------------

	/**
	 * 
	 */
	private void UpdateDistances(Vector2 hitPoint){
		// update distances
		xDistance = hitPoint.x - pointDown.x;
		yDistance = hitPoint.y - pointDown.y;
		distance = Vector2.Distance(pointDown, hitPoint);
	} // end of UpdateDistances

	/**
	 * 
	 */
	private void GestureRecognition(){

		// if distance is greater than a threshold
		if(distance > distanceThreshold){
			// there was a movement on the touch screen, so a gesture

			// if is rotate gesture
			if(isRotate180Gesture()){
				// send message to turn the player 180º
				this.SendMessage("TurnPlayer", 180, SendMessageOptions.DontRequireReceiver);
				currentAnimation = "TurnPlayer(180)";
			}
			// if is jumping up
			else if(isJumpingUp()){
				// send message jumping up
				this.SendMessage("JumpingUp", SendMessageOptions.DontRequireReceiver);
				currentAnimation = "JumpingUp";
			}
			// if is normal jumping forward
			else if (isNormalJumpingForward()){
				this.SendMessage("NormalJumpingForward", SendMessageOptions.DontRequireReceiver);
				currentAnimation = "NormalJumpingForward";	
			}
			// if is rolling
			else if(isRolling()){
				// send message to rolling down
				this.SendMessage("RollingDown", SendMessageOptions.DontRequireReceiver);
				currentAnimation = "RollingDown";
			}


		}


	} // end of GestureRecognition

	/**
	 * 
	 */
	private bool isRotate180Gesture(){
		// if Y distance is not greater than a threshold and if X distance is greater than a threshold
		if((Mathf.Abs(yDistance) < yPixelDistanceThreshold) && (Mathf.Abs(xDistance) > xPixelDistanceThreshold)){
			return true;
		}
		return false;		
	} // end of isRotate180Gesture


	/**
	 * 
	 */
	private bool isJumpingUp(){
		// if Y distance is greater than a threshold and has positive value, and X distance is not greater than a threshold
		if( ((Mathf.Abs(yDistance) > yPixelDistanceThreshold) && (yDistance > 0)) && (Mathf.Abs(xDistance) < xPixelDistanceThreshold) ){
			return true;
		}

		return false;
	}// end of isJumpingUp

	/**
	 * 
	 */
	private bool isNormalJumpingForward(){
		// if X and Y distances are greater than a threshold and Y distance is positive
		if( ((Mathf.Abs(yDistance) > yPixelDistanceThreshold) && (Mathf.Abs(xDistance) > xPixelDistanceThreshold)) && (yDistance > 0) ){
			// then it was * North-West	NW	315° (45°×7)	Normal Jumping Forward
			// or          * North-East	NE	 45° (45°×1)		Normal Jumping Forward
			return true;
		}
		return false;
	} // end of isNormalJumpingForward

	/**
	 * 
	 */
	private bool isRolling(){
		// if Y distance is greater than a threshold and has negative value, and X distance is not greater than a threshold
		if( ((Mathf.Abs(yDistance) > yPixelDistanceThreshold) && (yDistance < 0)) && (Mathf.Abs(xDistance) < xPixelDistanceThreshold) ){
			return true;
		}
		
		return false;
	}
}
