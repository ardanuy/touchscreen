using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class leftButton : TouchInput {

	public GUIText textScreenSpecs;

	public GUIText textCurrentPoint;
	public GUIText textPointDown;
	public GUIText textPointUp;

	public GUIText textSpeed;

	private float speed;

	void Awake(){
		textCurrentPoint.text = "Current (x,y)";
		textPointDown.text = "Down (x,y)";
		textPointUp.text = "Up (x,y)";

		textSpeed.text = "Speed:";
		textScreenSpecs.text = "Screen Height: " + Screen.height + "   Screen Width: " + Screen.width;
	}

	void OnTouchDown(Vector2 hitPoint){
		speed = (hitPoint.y / Screen.height);
		textSpeed.text = "Speed: " + speed;
		textPointDown.text = "Down (" + hitPoint.x + "," + hitPoint.y + ")";

	} // end of OnTouchDown



	void OnTouchUp(Vector2 hitPoint){
		speed = 0f;
		textSpeed.text = "Speed: " + speed;
		textPointUp.text = "Up (" + hitPoint.x + "," + hitPoint.y + ")";
	} // end of OnTouchUp



	void OnTouchStay(Vector2 hitPoint){
		speed = (hitPoint.y / Screen.height);
		textSpeed.text = "Speed: " + speed;
		textCurrentPoint.text = "Current (" + hitPoint.x + "," + hitPoint.y + ")";
	} // end of OnToucStay



	void OnTouchMove(Vector2 hitPoint){
		speed = (hitPoint.y / Screen.height);
		textSpeed.text = "Speed: " + speed;
		textCurrentPoint.text = "Current (" + hitPoint.x + "," + hitPoint.y + ")";

	} // end of OnTouchMove



	void OnTouchExit(Vector2 hitPoint){
	} // end of OnTouchExit




	// ------------------------ GET FUNCTIONS ----------------------------
	public float getSpeed(){ return speed; }

}

