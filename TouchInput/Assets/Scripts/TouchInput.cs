using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TouchInput : MonoBehaviour {

	void Update(){


		if(Input.touchCount > 0){


			foreach (Touch touch in Input.touches){

				//Ray ray = camera.ScreenPointToRay(touch.position);
				//RaycastHit hit;

				//if(Physics.Raycast(ray, out hit, touchInputMask)){
				if(this.guiTexture.HitTest(touch.position)){
					//GameObject recipient = hit.transform.gameObject;

					switch(touch.phase){

					case TouchPhase.Began:
						this.SendMessage("OnTouchDown", touch.position, SendMessageOptions.DontRequireReceiver);
						break;
					case TouchPhase.Ended:
						this.SendMessage("OnTouchUp", touch.position, SendMessageOptions.DontRequireReceiver);
						break;
					case TouchPhase.Stationary:
						this.SendMessage("OnTouchStay", touch.position, SendMessageOptions.DontRequireReceiver);
						break;
					case TouchPhase.Moved:
						this.SendMessage("OnTouchMove", touch.position, SendMessageOptions.DontRequireReceiver);
						break;
					case TouchPhase.Canceled:
						this.SendMessage("OnTouchExit", touch.position, SendMessageOptions.DontRequireReceiver);
						break;
					default:
						break;

					} // end of switch
				} // end of if


			} // end of foreach


		} // end of if

	} // end of Update
} // end of class
