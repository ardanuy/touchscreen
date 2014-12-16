using UnityEngine;
using System.Collections;

public class DinamicResize : MonoBehaviour {

	private GUITexture leftGuiTexture;
	private GUITexture rightGuiTexture;
	
	// Use this for initialization
	void Start () {

		leftGuiTexture = GameObject.FindGameObjectWithTag ("GuiTextureTouchLeft").GetComponent<GUITexture> ();
		rightGuiTexture = GameObject.FindGameObjectWithTag ("GuiTextureTouchRight").GetComponent<GUITexture> ();

		// Rect (X, Y, W, H);
		float H = Screen.height;
		float W = Screen.width / 2;
		float Y = (Screen.height / 2) * -1;

		float xLeft = (Screen.width / 2) * -1;
		float xRight = 0;

		// Rect (X, Y, W, H);
		leftGuiTexture.pixelInset = new Rect (xLeft, Y, W, H);
		rightGuiTexture.pixelInset = new Rect (xRight, Y, W, H);
	}

}
