using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TouchInput : MonoBehaviour {

	public LayerMask touchInputMask;

	void Update(){


		if(Input.touchCount > 0){


			foreach (Touch touch in Input.touches){

				Ray ray = camera.ScreenPointToRay(touch.position);
				RaycastHit hit;

				if(Physics.Raycast(ray, out hit, touchInputMask)){
					GameObject recipient = hit.transform.gameObject;

					switch(touch.phase){

					case TouchPhase.Began:
						recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
						break;
					case TouchPhase.Ended:
						recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
						break;
					case TouchPhase.Stationary:
						recipient.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
						break;
					case TouchPhase.Moved:
						recipient.SendMessage("OnTouchMove", hit.point, SendMessageOptions.DontRequireReceiver);
						break;
					case TouchPhase.Canceled:
						recipient.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
						break;
					default:
						break;

					} // end of switch
				}


			} // end of foreach


		} // end of if

	} // end of Update
} // end of class
