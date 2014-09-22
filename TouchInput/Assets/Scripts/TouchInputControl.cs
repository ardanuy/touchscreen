using UnityEngine;
using System.Collections;

public class TouchInputControl : TouchInput {

	// show information about the touch
	public GUIText textScreenSpecs;	
	public GUIText textCurrentPoint;
	public GUIText textPointDown;
	public GUIText textPointUp;	
	public GUIText textSpeed;
	public GUIText textTapCount;
	private string currentTapCount = "";
	
	// speed of the player
	private float speed;
	// touch postition on the screen
	private Vector2 pointDownPosition, pointUpPosition;


	/**
	 * 
	 */
	void OnTouchUp(Touch touch){
		pointUpPosition = touch.position;
		speed = 0f;

		// debuging
		ShowInformation (pointUpPosition);
	} // end of OnTouchUp

	/**
	 * 
	 */
	void OnTouchDown(Touch touch){
		pointDownPosition = touch.position;
		speed = (pointDownPosition.y / Screen.height);

		// look for an action
		ActionRecognition (touch);

		// debuging
		ShowInformation (pointDownPosition);
	} // end of OnTouchDown
	
	/**
	 * 
	 */
	void OnTouchStay(Touch touch){
		speed = (touch.position.y / Screen.height);

		// debuging
		ShowInformation (touch.position);
	} // end of OnToucStay
	
	
	/**
	 * 
	 */
	void OnTouchMove(Touch touch){
		speed = (touch.position.y / Screen.height);

		// debuging
		ShowInformation (touch.position);
		
	} // end of OnTouchMove
	
	
	/**
	 * 
	 */
	void OnTouchExit(Vector2 hitPoint){
		pointDownPosition = new Vector2 (0, 0);
		pointUpPosition = new Vector2 (0, 0);
	} // end of OnTouchExit
	



	/**
	 * 
	 */
	// ------------------------ Debuging ---------------------------------
	void ShowInformation(Vector2 hitPoint){
		textSpeed.text = "Speed: " + speed;
		textPointDown.text = "Down Point (" + pointDownPosition.x + "," + pointDownPosition.y + ")";
		textPointUp.text = "Up Point (" + pointUpPosition.x + "," + pointUpPosition.y + ")";
		textCurrentPoint.text = "Current Point (" + hitPoint.x + "," + hitPoint.y + ")";
		textScreenSpecs.text = "Screen Height: " + Screen.height + "   Screen Width: " + Screen.width;
		textTapCount.text = "Tap Count: " + currentTapCount;
		
	}
	
	
	// ------------------------ GET FUNCTIONS ----------------------------
	/**
	 * 
	 */
	public float getSpeed(){ return speed; }

	// ------------------------ Action Recognizer ----------------------------
	/**
	 * 
	 */
	private void ActionRecognition(Touch touch){
		// if tap count is equal to 2
		if(touch.tapCount == 2){
			// send message 
			this.SendMessage("DoubleTap", SendMessageOptions.DontRequireReceiver);
			currentTapCount = "Tap Count = " + touch.tapCount;
		}
		else{
			currentTapCount = "Tap Count = " + touch.tapCount;		
		}

	}

} // end of TouchInputControl class

