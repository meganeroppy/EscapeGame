using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	private Rigidbody r;
	[SerializeField]
	private bool grouped = false;
	
	private void Start(){
	r = GetComponent<Rigidbody>();
		r.constraints = RigidbodyConstraints.FreezeAll;
	}

	private void OnCollisionEnter(Collision col){
		if(col.gameObject.tag.Equals("PlayerHands")){
		//	Debug.Log("Break!");
			if(!grouped){
				r.constraints = RigidbodyConstraints.None;
				Destroy(r.gameObject, 3.0f);
			}else{
				Rigidbody[] rigidBodies = transform.parent.GetComponentsInChildren<Rigidbody>();
				foreach(Rigidbody rs in rigidBodies){
				rs.constraints = RigidbodyConstraints.None;
				Destroy(rs.gameObject, 3.0f);
				}
			}
		}
	}
	
	private void OnTriggerEnter(Collider col){
		if(col.gameObject.tag.Equals("PlayerHands")){
			//	Debug.Log("Break!");
			if(!grouped){
				r.constraints = RigidbodyConstraints.None;
				Destroy(r.gameObject, 3.0f);
			}else{
				Rigidbody[] rigidBodies = transform.parent.GetComponentsInChildren<Rigidbody>();
				foreach(Rigidbody rs in rigidBodies){
					rs.constraints = RigidbodyConstraints.None;
					Destroy(rs.gameObject, 3.0f);
				}
			}
		}
	}
}
