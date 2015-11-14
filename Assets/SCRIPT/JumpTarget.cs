using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JumpTarget : MonoBehaviour {

	protected GameObject player;
	[SerializeField]
	protected GameObject foundEffect;
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

		Vector3 dist =  player.transform.position - this.transform.position;
		bool playerIsOnThis = Mathf.Abs( dist.x ) < Vector3.one.x * 0.1f &&  Mathf.Abs( dist.y ) <  Vector3.one.y * 0.1f &&  Mathf.Abs( dist.z ) < Vector3.one.z * 0.1f;

		if(!explored){
			if(playerIsOnThis){
				explored = true;
				SetAsFound();
			}
		}

		for(int i=0 ; i < transform.childCount ; i++){
			transform.GetChild(i).gameObject.SetActive(!playerIsOnThis);
		}

	}
	
	protected virtual void SetAsFound(){
		GameObject g = Instantiate(foundEffect) as GameObject;
		g.transform.SetParent(transform);
		g.transform.localPosition = Vector3.zero;
	}
}
