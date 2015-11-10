using UnityEngine;
using System.Collections;

public class GateKey : MonoBehaviour {

	public bool unlocked{get;private set;}
	private GameObject check;

	private void Awake(){
		unlocked = false;
		check = transform.FindChild("Check").gameObject;
	}
	
	void Update(){
		if(check != null){
			check.SetActive(unlocked);
		}
	}

	private void OnCollisionEnter(Collision col){
		if(col.gameObject.tag.Equals("PlayerHands")){
			if(!unlocked){
				Debug.Log("GateKey Unlocked");
				unlocked = true;
			}
		}
	}
	
	private void OnTriggerEnter(Collider col){
		if(col.gameObject.tag.Equals("PlayerHands")){
			if(!unlocked){
				Debug.Log("GateKey Unlocked");
				unlocked = true;
			}
		}
	}
}
