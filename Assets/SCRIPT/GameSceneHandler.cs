using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class GameSceneHandler : MonoBehaviour {

	public static bool isVR = VRSettings.enabled;
	public GameObject canvas;
	public GameObject player;
	public GameObject cameraForVr;

	public enum GAME_STATUS
	{
		PLAYING,
		GAME_OVER
	};
	
	public static GAME_STATUS gameFlag = GAME_STATUS.PLAYING;

	public bool isDemo = true;

	public CameraScript currentCamera;

	public GameObject winPanel;

	// Use this for initialization
	void Start () {
		//Debug.Log ("vr setting is "+isVR);
	
		if (isVR) {
			this.canvas.SetActive(false);
			this.player.SetActive(false);
			this.cameraForVr.SetActive(true);
		} 
		else {
			this.canvas.SetActive(true);
			this.player.SetActive(true);
			if(this.cameraForVr != null){
				this.cameraForVr.SetActive(false);
			}
		}

		ResetLevel ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameFlag == GAME_STATUS.PLAYING) {
			if (isDemo) {
				if (Input.GetKey (KeyCode.UpArrow)) {
					this.currentCamera.MoveUp(ConstantScript.CAMERA_SPEED);
				}
				else if (Input.GetKey (KeyCode.DownArrow)) {
					this.currentCamera.MoveDown(ConstantScript.CAMERA_SPEED);
				}
				else if (Input.GetKey (KeyCode.RightArrow)) {
					this.currentCamera.MoveRight(ConstantScript.CAMERA_SPEED);
				}
				else if (Input.GetKey (KeyCode.LeftArrow)) {
					this.currentCamera.MoveLeft(ConstantScript.CAMERA_SPEED);
				}

			}
		} 
		else if (gameFlag == GAME_STATUS.GAME_OVER) {
			this.winPanel.SetActive(true);
			if (Input.GetKey (KeyCode.Space)) {
				ResetLevel();
				Application.LoadLevel (ConstantScript.SCENE_INGAME);
			}
		}

	}

	public void ResetLevel(){
		gameFlag = GAME_STATUS.PLAYING;
		winPanel.SetActive (false);

	}
}
