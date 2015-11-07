using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	private Rigidbody r;
	
	private void Start(){
	r = GetComponent<Rigidbody>();
		r.constraints = RigidbodyConstraints.FreezeAll;
	}

	private void OnCollisionEnter(Collision col){
		if(col.gameObject.tag.Equals("PlayerHands")){
			Debug.Log("Break!");
			r.constraints = RigidbodyConstraints.None;
		}
	}
}
