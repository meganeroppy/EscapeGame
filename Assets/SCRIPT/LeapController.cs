using UnityEngine;
using System.Collections;
using Leap;
public class LeapController : MonoBehaviour {
	public Camera mainCamera;
	Leap.Controller controller;
	#region delegates
	#endregion
	
	#region events
	#endregion
	
	// Use this for initialization
	void Start () 
	{
		
		controller = new Controller();
		controller.EnableGesture(Gesture.GestureType.TYPECIRCLE);
		controller.EnableGesture(Gesture.GestureType.TYPEINVALID);
		controller.EnableGesture(Gesture.GestureType.TYPEKEYTAP);
		controller.EnableGesture(Gesture.GestureType.TYPESCREENTAP);
		controller.EnableGesture(Gesture.GestureType.TYPESWIPE);
	}
	
	// Update is called once per frame
	void Update () {
		Frame frame = controller.Frame();
		foreach (Gesture gesture in frame.Gestures())
		{
			switch(gesture.Type)
			{
				case(Gesture.GestureType.TYPECIRCLE):
				{
					Debug.Log("Circle gesture recognized.");
					break;
				}
				case(Gesture.GestureType.TYPEINVALID):
				{
					Debug.Log("Invalid gesture recognized.");
					break;
				}
				case(Gesture.GestureType.TYPEKEYTAP):
				{
					Debug.Log("Key Tap gesture recognized.");
					break;
				}
				case(Gesture.GestureType.TYPESCREENTAP):
				{
					Debug.Log("Screen tap gesture recognized.");
					break;
				}
				case(Gesture.GestureType.TYPESWIPE):
				{
					if(mainCamera.clearFlags == CameraClearFlags.Skybox){
						mainCamera.clearFlags = CameraClearFlags.SolidColor;
					}
					else{
						mainCamera.clearFlags = CameraClearFlags.Skybox;
					}


					Debug.Log("Swipe gesture recognized.");
					break;
				}
				default:
				{
					break;
				}
			}
		}
	}
}
