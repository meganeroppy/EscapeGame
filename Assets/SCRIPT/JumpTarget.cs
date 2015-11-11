using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JumpTarget : MonoBehaviour {

	private GameObject player;
	[SerializeField]
	private GameObject foundEffect;
	bool explored = false;

	// Use this for initialization
	void Awake () {


	}

	void Start(){
		if (GameSceneHandler.isVR) {
			player = GameObject.Find("CameraForOculus");
		} 
		else {
			player = GameObject.Find("Player");
		}
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 offset =  player.transform.position - this.transform.position;
		bool playerIsOnThis = Mathf.Abs( offset.x ) < Vector3.one.x * 0.1f &&  Mathf.Abs( offset.y ) <  Vector3.one.y * 0.1f &&  Mathf.Abs( offset.z ) < Vector3.one.z * 0.1f;

		if(!explored){
			if(playerIsOnThis){
				explored = true;
				GameObject g = Instantiate(foundEffect) as GameObject;
				g.transform.SetParent(transform);
				g.transform.localPosition = Vector3.zero;
			}
		}

		for(int i=0 ; i < transform.childCount ; i++){
			transform.GetChild(i).gameObject.SetActive(!playerIsOnThis);
		}

	}
}
