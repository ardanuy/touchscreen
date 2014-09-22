/*
 * 
 * 8-point Compass Rose system for swipe direction recognition
 * North		N	  0°				
 * North-East	NE	 45° (45°×1)		
 * East			E	 90° (45°×2)		
 * South-East	SE	135° (45°×3)	
 * South		S	180° (45°×4)	
 * South-West	SW	225° (45°×5)	
 * West			W	270° (45°×6)	
 * North-West	NW	315° (45°×7)	
 * 
 * 
 * 
 */ 
using UnityEngine;
using System.Collections;

public class SwipeControl : TouchInput {
	
	// show information about the touch
	public GUIText textCurrentPoint;
	public GUIText textPointDown;
	public GUIText textPointUp;
	public GUIText textXDistance;
	public GUIText textYDistance;
	public GUIText textDistance;	
	public GUIText textSwipeDirection;
	private string swipeDirection;
	
	// stores point down and up
	private Vector2 pointDownPosition, pointUpPosition;
	
	// calculates distances from the hit down and up points
	private float xDistance = 0f;
	private float yDistance = 0f;
	private float distance = 0f;
	
	// tweaks 
	public float xPixelDistanceThreshold = 30f;
	public float yPixelDistanceThreshold = 30f;
	public float distanceThreshold = 25f;
	
	
	/**
	 * @param touch 
	 */
	void OnTouchUp(Touch touch){
		pointUpPosition = touch.position;
		
		// update distances
		UpdateDistances (pointUpPosition);
		
		// recognizes the swipe direction based on the 8 point compass rose
		SwipeDirectionRecognition ();
		
		// debuging
		ShowInformation (pointUpPosition);
	} // end of OnTouchUp
	
	/**
	 * 
	 */
	void OnTouchDown(Touch touch){
		pointDownPosition = touch.position;
	} // end of OnTouchDown
	
	/**
	 * 
	 */
	void OnTouchStay(Touch touch){
		// debuging
		ShowInformation (touch.position);
	} // end of OnToucStay
	
	
	/**
	 * 
	 */
	void OnTouchMove(Touch touch){
		// update distances
		//UpdateDistances (hitPoint);
		
		// debuging
		ShowInformation (touch.position);
	} // end of OnTouchMove
	
	
	/**
	 * 
	 */
	void OnTouchExit(Touch touch){
		pointDownPosition = new Vector2 (0, 0);
		pointUpPosition = new Vector2 (0, 0);
	} // end of OnTouchExit
	
	
	
	/**
	 * 
	 */
	// ------------------------ Debuging ---------------------------------
	void ShowInformation(Vector2 hitPoint){
		textPointDown.text = "Down Point (" + pointDownPosition.x + "," + pointDownPosition.y + ")";
		textPointUp.text = "Up Point (" + pointUpPosition.x + "," + pointUpPosition.y + ")";
		textCurrentPoint.text = "Current Point (" + hitPoint.x + "," + hitPoint.y + ")";	
		textXDistance.text = "X swipe distance = " + xDistance + " pixels";
		textYDistance.text = "Y swipe distance = " + yDistance + " pixels";
		textDistance.text = "Swipe Distance = " + distance;
		textSwipeDirection.text = "Swipe Direction: " + swipeDirection;
		
	}
	
	
	// ------------------------ Gesture Recognizer ----------------------------
	
	/**
	 * 
	 */
	private void UpdateDistances(Vector2 hitPoint){
		// update distances
		xDistance = hitPoint.x - pointDownPosition.x;
		yDistance = hitPoint.y - pointDownPosition.y;
		distance = Vector2.Distance(pointDownPosition, hitPoint);
	} // end of UpdateDistances
	
	/**
	 * 
	 */
	private void SwipeDirectionRecognition(){
		
		// if distance is greater than a threshold
		if(distance > distanceThreshold){
			// there was a swipe on the touch screen
			
			if(isNorthMove()){
				// send message 
				this.SendMessage("NorthMove", SendMessageOptions.DontRequireReceiver);
				swipeDirection = "North";
			}
			else if(isNorthEastMove()){
				// send message 
				this.SendMessage("NorthEastMove", SendMessageOptions.DontRequireReceiver);
				swipeDirection = "NorthEast";
			}
			else if(isEastMove()){
				// send message 
				this.SendMessage("EastMove", SendMessageOptions.DontRequireReceiver);
				swipeDirection = "East";
			}
			else if(isSouthEastMove()){
				// send message 
				this.SendMessage("SouthEastMove", SendMessageOptions.DontRequireReceiver);
				swipeDirection = "SouthEast";
			}
			else if(isSouthMove()){
				// send message 
				this.SendMessage("SouthMove", SendMessageOptions.DontRequireReceiver);
				swipeDirection = "South";
			}
			else if(isSouthWestMove()){
				// send message 
				this.SendMessage("SouthWestMove", SendMessageOptions.DontRequireReceiver);
				swipeDirection = "SouthWest";
			}
			else if(isWestMove()){
				// send message 
				this.SendMessage("WestMove", SendMessageOptions.DontRequireReceiver);
				swipeDirection = "West";
			}
			else if(isNorthWestMove()){
				// send message 
				this.SendMessage("NorthWestMove", SendMessageOptions.DontRequireReceiver);
				swipeDirection = "NorthWest";
			}
			else{
				// send message 
				this.SendMessage("UnknownMove", SendMessageOptions.DontRequireReceiver);
				swipeDirection = "Unknown";
				
			}
		}
		
		
	} // end of SwipeDirectionRecognition
	
	/**
	 * 
	 */
	private bool isNorthMove(){
		// if Y distance is greater than a threshold and has positive value, and X distance is not greater than a threshold
		if( ((Mathf.Abs(yDistance) > yPixelDistanceThreshold) && (yDistance > 0)) && (Mathf.Abs(xDistance) < xPixelDistanceThreshold) ){
			return true;
		}
		return false;		
	} // end of isNorthMove
	
	/**
	 * 
	 */
	private bool isNorthEastMove(){
		// if X and Y distances are greater than a threshold and Y and X distances are positive values
		if ( ((Mathf.Abs (yDistance) > yPixelDistanceThreshold) && (Mathf.Abs (xDistance) > xPixelDistanceThreshold)) && 
		    ((yDistance > 0) && (xDistance > 0)) ){
			return true;
		}
		return false;
	} // end of isNorthEastMove
	
	/**
	 * 
	 */
	private bool isEastMove(){
		// if Y distance is not greater than a threshold and if X distance is greater than a threshold and has positive value
		if((Mathf.Abs(yDistance) < yPixelDistanceThreshold) && ((Mathf.Abs(xDistance) > xPixelDistanceThreshold) && (xDistance > 0)) ){
			return true;
		}
		return false;
	} // end of isEastMove
	
	/**
	 * 
	 */
	private bool isSouthEastMove(){
		// // if Y distance is greater than a threshold and has negative value, and X distance is greater than a threshold and has positive value
		if( ((Mathf.Abs(yDistance) > yPixelDistanceThreshold) && (yDistance < 0)) && 
		   ((Mathf.Abs(xDistance) > xPixelDistanceThreshold) && (xDistance > 0)) ){
			return true;
		}
		return false;
	} // end of isSouthEastMove
	
	/**
	 * 
	 */
	private bool isSouthMove(){
		// if Y distance is greater than a threshold and has negative value, and X distance is not greater than a threshold
		if( ((Mathf.Abs(yDistance) > yPixelDistanceThreshold) && (yDistance < 0)) && (Mathf.Abs(xDistance) < xPixelDistanceThreshold) ){
			return true;
		}
		
		return false;
	} // end of isSouthMove
	
	/**
	 * 
	 */
	private bool isSouthWestMove(){
		// // if Y distance is greater than a threshold and has negative value, and X distance is greater than a threshold and has negative value
		if( ((Mathf.Abs(yDistance) > yPixelDistanceThreshold) && (yDistance < 0)) && 
		   ((Mathf.Abs(xDistance) > xPixelDistanceThreshold) && (xDistance < 0)) ){
			return true;
		}
		
		return false;
	} // end of isSouthWestMove
	
	/**
	 * 
	 */
	private bool isWestMove(){
		// if Y distance is not greater than a threshold and if X distance is greater than a threshold and has negative value
		if((Mathf.Abs(yDistance) < yPixelDistanceThreshold) && ((Mathf.Abs(xDistance) > xPixelDistanceThreshold) && (xDistance < 0)) ){
			return true;
		}
		
		return false;
	} // end of isWestMove
	
	/**
	 * 
	 */
	private bool isNorthWestMove(){
		// if X and Y distances are greater than a threshold and Y is positive and x is negative
		if ( ((Mathf.Abs (yDistance) > yPixelDistanceThreshold) && (Mathf.Abs (xDistance) > xPixelDistanceThreshold)) && 
		    ((yDistance > 0) && (xDistance < 0)) ){
			return true;
		}
		return false;
	} // end of isNorthWestMove
	
} // end of SwipeControl class
