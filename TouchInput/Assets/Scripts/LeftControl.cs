using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LeftControl : TouchInput {
	
	public GUIText textScreenSpecs;
	
	public GUIText textCurrentPoint;
	public GUIText textPointDown;
	public GUIText textPointUp;
	
	public GUIText textSpeed;
	
	private float speed;

	private Vector2 pointDown, pointUp;

	/**
	 * 
	 */
	void Awake(){
		textCurrentPoint.text = "Current (x,y)";
		textPointDown.text = "Down (x,y)";
		textPointUp.text = "Up (x,y)";
		
		textSpeed.text = "Speed:";
		textScreenSpecs.text = "Screen Height: " + Screen.height + "   Screen Width: " + Screen.width;
	}

	/**
	 * 
	 */
	void OnTouchDown(Vector2 hitPoint){
		pointDown = hitPoint;
		speed = (hitPoint.y / Screen.height);

		// debuging
		ShowInformation (hitPoint);
	} // end of OnTouchDown
	
	
	/**
	 * 
	 */
	void OnTouchUp(Vector2 hitPoint){
		pointUp = hitPoint;
		speed = 0f;

		// debuging
		ShowInformation (hitPoint);
	} // end of OnTouchUp
	
	
	
	void OnTouchStay(Vector2 hitPoint){
		speed = (hitPoint.y / Screen.height);

		// debuging
		ShowInformation (hitPoint);
	} // end of OnToucStay
	
	
	/**
	 * 
	 */
	void OnTouchMove(Vector2 hitPoint){
		speed = (hitPoint.y / Screen.height);

		// debuging
		ShowInformation (hitPoint);
		
	} // end of OnTouchMove
	
	
	/**
	 * 
	 */
	void OnTouchExit(Vector2 hitPoint){
	} // end of OnTouchExit
	



	/**
	 * 
	 */
	// ------------------------ Debuging ---------------------------------
	void ShowInformation(Vector2 hitPoint){
		textSpeed.text = "Speed: " + speed;
		textPointDown.text = "Down (" + pointDown.x + "," + pointDown.y + ")";
		textPointUp.text = "Up (" + pointUp.x + "," + pointUp.y + ")";
		textCurrentPoint.text = "Current (" + hitPoint.x + "," + hitPoint.y + ")";
		
	}
	
	
	// ------------------------ GET FUNCTIONS ----------------------------
	/**
	 * 
	 */
	public float getSpeed(){ return speed; }
	
}

