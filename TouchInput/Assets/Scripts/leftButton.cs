using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class leftButton : MonoBehaviour {


	private Vector3 onTouchDownHitPoint;
	private Vector3 onTouchUpHitPoint;
	private Vector3 onTouchStayHitPoint;
	private List<Vector3> onTouchMoveHitPoints;

	public GUIText text;

	private float speed;

	void OnTouchDown(Vector3 hitPoint){
		onTouchDownHitPoint = hitPoint;	

		speed = (hitPoint.y / Screen.height);

		text.text = ToString (speed);
		//Debug.Log ("Speed: " + speed);

	} // end of OnTouchDown



	void OnTouchUp(Vector3 hitPoint){
		onTouchUpHitPoint = hitPoint;
	} // end of OnTouchUp



	void OnTouchStay(Vector3 hitPoint){
		onTouchStayHitPoint = hitPoint;
	} // end of OnToucStay



	void OnTouchMove(Vector3 hitPoint){
		onTouchMoveHitPoints.Add (hitPoint);

	} // end of OnTouchMove



	void OnTouchExit(Vector3 hitPoint){
		Debug.Log ("Touch canceled!!!");
	} // end of OnTouchExit




	// ------------------------ GET FUNCTIONS ----------------------------
	public float getSpeed(){ return speed; }

}
