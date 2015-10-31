using UnityEngine;
using System.Collections;

public class GateKey : MonoBehaviour {

	public bool unlocked{get;private set;}

	private void Awake(){
		unlocked = false;
	}

	private void OnCollisionEnter(Collision col){
		if(col.gameObject.tag.Equals("PlayerHands")){
			if(!unlocked){
				Debug.Log("GateKey Unlocked");
				unlocked = true;
			}
		}
	}
}
