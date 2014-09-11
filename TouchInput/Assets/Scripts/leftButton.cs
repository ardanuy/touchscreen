using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class leftButton : TouchInput {


	//private Vector3 onTouchDownHitPoint;
	//private Vector3 onTouchUpHitPoint;
	//private Vector3 onTouchStayHitPoint;

	//private List<Vector3> onTouchMoveHitPoints;

	public GUIText text;
	public GUIText textScreenSpecs;
	public GUIText textTouchHitPoint;

	private float speed;

	void Awake(){
		text.text = "Speed: ";
		textScreenSpecs.text = "Screen Height: " + Screen.height + "   Screen Width: " + Screen.width;
		textTouchHitPoint.text = "(x,y)";
	}

	void OnTouchDown(Vector2 hitPoint){
		//onTouchDownHitPoint = hitPoint;	

		speed = (hitPoint.y / Screen.height);

		text.text = "Speed: " + speed;
		textTouchHitPoint.text = "(" + hitPoint.x + "," + hitPoint.y + ")";

	} // end of OnTouchDown



	void OnTouchUp(Vector2 hitPoint){
		//onTouchUpHitPoint = hitPoint;
		text.text = "Speed: " + speed;
		textTouchHitPoint.text = "(" + hitPoint.x + "," + hitPoint.y + ")";
	} // end of OnTouchUp



	void OnTouchStay(Vector2 hitPoint){
		//onTouchStayHitPoint = hitPoint;
		text.text = "Speed: " + speed;
		textTouchHitPoint.text = "(" + hitPoint.x + "," + hitPoint.y + ")";
	} // end of OnToucStay



	void OnTouchMove(Vector2 hitPoint){
		//onTouchMoveHitPoints.Add (hitPoint);

		text.text = "Speed: " + speed;
		textTouchHitPoint.text = "(" + hitPoint.x + "," + hitPoint.y + ")";

	} // end of OnTouchMove



	void OnTouchExit(Vector2 hitPoint){
		//Debug.Log ("Touch canceled!!!");
	} // end of OnTouchExit




	// ------------------------ GET FUNCTIONS ----------------------------
	public float getSpeed(){ return speed; }

}

