using UnityEngine;
using System.Collections;

public class rightButton : TouchInput {

	public GUIText textCurrentPoint;
	public GUIText textPointDown;
	public GUIText textPointUp;

	public GUIText textAnimationName;
	
	void Awake(){
		textCurrentPoint.text = "Current (x,y)";
		textPointDown.text = "Down (x,y)";
		textPointUp.text = "Up (x,y)";
		textAnimationName.text = "Animation Name";
	}
	
	void OnTouchDown(Vector2 hitPoint){
		textPointDown.text = "Down (" + hitPoint.x + "," + hitPoint.y + ")";
		
	} // end of OnTouchDown
	
	
	
	void OnTouchUp(Vector2 hitPoint){
		textPointUp.text = "Up (" + hitPoint.x + "," + hitPoint.y + ")";
	} // end of OnTouchUp
	
	
	
	void OnTouchStay(Vector2 hitPoint){

	} // end of OnToucStay
	
	
	
	void OnTouchMove(Vector2 hitPoint){
		textCurrentPoint.text = "Current (" + hitPoint.x + "," + hitPoint.y + ")";		
	} // end of OnTouchMove
	
	
	
	void OnTouchExit(Vector2 hitPoint){
	} // end of OnTouchExit
	
	
	
	
	// ------------------------ GET FUNCTIONS ----------------------------
}
