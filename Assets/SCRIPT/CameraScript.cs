using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour {

	public Image circularTarget;
	
	public Material chosenObject;
	private Material prevMaterial;
	private GameObject prevGobj;

	public GameObject handController;

	private float timerTemp;
	public Text countDown;
	public Camera m_camera;

	private GameObject target;
	// Use this for initialization

	private AudioSource audioSource;
	[SerializeField]
	private AudioClip se_jumpComplete;
	[SerializeField]
	private AudioClip se_jumpSatrt;


	void Awake(){
		audioSource = transform.GetComponent<AudioSource>();
		this.handController.SetActive (false);
	}
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray ray = m_camera.ViewportPointToRay (new Vector3 (0.5f,0.5f,0.0f));
		
		if (Physics.Raycast (ray, out hit)) {
			Transform objectHit = hit.transform;
			this.target = hit.transform.gameObject;
			if (hit.transform.gameObject.layer == ConstantScript.CAMERA_LAYER || 
			    hit.transform.gameObject.layer == ConstantScript.ROBOT_LAYER || 
			    hit.transform.gameObject.layer == ConstantScript.GOAL_LAYER) {
				//Debug.Log ("CAMERA HIT");
				if (prevGobj && prevMaterial) {
					this.prevGobj.GetComponent<Renderer> ().material = this.prevMaterial;
				}
				this.prevMaterial = hit.transform.gameObject.GetComponent<Renderer> ().material;

				hit.transform.gameObject.GetComponent<Renderer> ().material = chosenObject;
				this.prevGobj = hit.transform.gameObject;

				this.timerTemp += Time.deltaTime;

				this.circularTarget.fillAmount += Time.deltaTime/ (ConstantScript.LOOK_LENGTH);

				if(this.timerTemp >= ConstantScript.LOOK_DELAY){
					countDown.gameObject.SetActive(true);
					countDown.text = ""+(this.timerTemp - ConstantScript.LOOK_DELAY);
				}

				if(this.timerTemp >= (ConstantScript.LOOK_LENGTH + ConstantScript.LOOK_DELAY)){

					audioSource.PlayOneShot(se_jumpSatrt);


					this.timerTemp = 0.0f;
					this.circularTarget.fillAmount = 0.0f;
					countDown.gameObject.SetActive(false);
					countDown.text = "0.0";
					if(GameSceneHandler.isVR){
						this.gameObject.GetComponent<GlitchFx>().startGlitch = true;
					}
					else{
						this.transform.GetChild(2).gameObject.GetComponent<GlitchFx>().startGlitch = true;
					}

					//this.gameObject.GetComponent<GlitchFx>().startGlitch = true;
//					this.Jump(hit.transform.gameObject);
				}
			}else{ 
			// watch something not a camera
				this.timerTemp = 0.0f;
				countDown.gameObject.SetActive(false);
				countDown.text = "0.0";
				this.circularTarget.fillAmount = 0.0f;
				//this.Jump(hit.transform.gameObject);
			}

			
			//Debug.Log("test "+hit.transform.gameObject.layer);

			// Do something with the object that was hit by the raycast.
		} 
		else {
			//this.target = null;
			if(this.prevGobj){
				if(this.prevGobj.layer == ConstantScript.CAMERA_LAYER || 
				   this.prevGobj.layer == ConstantScript.ROBOT_LAYER || 
				   this.prevGobj.layer == ConstantScript.GOAL_LAYER){
					if (prevGobj && prevMaterial) {
						this.prevGobj.GetComponent<Renderer> ().material = this.prevMaterial;
					}
					this.prevGobj = null;
					this.prevMaterial = null;
					this.timerTemp = 0.0f;
					countDown.gameObject.SetActive(false);
					countDown.text = "0.0";
					this.circularTarget.fillAmount = 0.0f;
				}
			}

		}

	}

	public void Jump(){
		//Debug.Log ("jumping");
		if (this.target) {
			//Debug.Log("ciat");

			if(this.target.layer == ConstantScript.CAMERA_LAYER ||
			   this.target.layer == ConstantScript.ROBOT_LAYER){

				if(this.target.layer == ConstantScript.CAMERA_LAYER){
					this.handController.SetActive (false);
				}
				else if(this.target.layer == ConstantScript.ROBOT_LAYER){
					this.handController.SetActive (true);
				}

				audioSource.PlayOneShot(se_jumpComplete);
				if(GameSceneHandler.isVR){
					Transform temp = this.target.transform.GetChild(0);
					this.transform.parent.gameObject.transform.position = this.target.transform.position;
					this.transform.parent.rotation = temp.rotation;
				}
				else{
					Transform temp = this.target.transform.GetChild(0);
					//Debug.Log("temp rotation x "+temp.rotation.eulerAngles.x+" y = "+temp.rotation.eulerAngles.y);
					this.transform.parent.rotation = temp.rotation;
					this.transform.position = this.target.transform.position;
				}
				//	Transform temp = target.transform.GetChild(0);
				//this.transform.parent.gameObject.transform.position = this.target.transform.position;

			}
			else if(this.target.layer == ConstantScript.GOAL_LAYER){
				audioSource.PlayOneShot(se_jumpComplete);
				if(GameSceneHandler.isVR){
					this.transform.parent.gameObject.transform.position = this.target.transform.position;
				}
				else{
					this.transform.position = this.target.transform.position;
				}
				//Transform temp = target.transform.GetChild(0);

				//this.transform.rotation = temp.rotation;
				GameSceneHandler.gameFlag = GameSceneHandler.GAME_STATUS.GAME_OVER;
			}

		}
	}

	public void MoveUp(float speed){
		this.transform.Rotate(Vector3.left * speed * Time.deltaTime);
	}

	public void MoveDown(float speed){
		this.transform.Rotate(Vector3.right * speed * Time.deltaTime);
	}

	public void MoveLeft(float speed){
		this.transform.Rotate(Vector3.down * speed * Time.deltaTime);
	}

	public void MoveRight(float speed){
		this.transform.Rotate(Vector3.up * speed * Time.deltaTime);
	}
}
