using UnityEngine;
using System.Collections;

public class rightButton : TouchInput {

	// show information about the touch
	public GUIText textCurrentPoint;
	public GUIText textPointDown;
	public GUIText textPointUp;

	public GUIText textAnimationName;


	// recognize gestures
	private Vector2 pointDown, pointUp;

	private bool isMoving = false;
	
	void Awake(){
		textCurrentPoint.text = "Current (x,y)";
		textPointDown.text = "Down (x,y)";
		textPointUp.text = "Up (x,y)";
		textAnimationName.text = "Animation Name";

		pointDown = new Vector2 (0, 0);
		pointUp = new Vector2 (0, 0);
	}

	void OnTouchUp(Vector2 hitPoint){
		pointUp = hitPoint;
		textPointUp.text = "Up (" + hitPoint.x + "," + hitPoint.y + ")";
		
		
	} // end of OnTouchUp
	

	void OnTouchDown(Vector2 hitPoint){
		pointDown = hitPoint;
		textPointDown.text = "Down (" + pointDown.x + "," + pointDown.y + ")";


		
	} // end of OnTouchDown
	
	
	void OnTouchStay(Vector2 hitPoint){
		isMoving = false;
	} // end of OnToucStay
	
	
	
	void OnTouchMove(Vector2 hitPoint){
		textCurrentPoint.text = "Current (" + hitPoint.x + "," + hitPoint.y + ")";	


		isMoving = true;

	} // end of OnTouchMove
	
	
	
	void OnTouchExit(Vector2 hitPoint){

		isMoving = false;

		pointDown = null;
		pointUp = null;
	} // end of OnTouchExit
	
	
	
	
	// ------------------------ GET FUNCTIONS ---------------------------------
	// ------------------------ Gesture Recognizer ----------------------------
	private Gesture GestureRecognition(){
	}
	private void GestureManagement(){

	}
}
