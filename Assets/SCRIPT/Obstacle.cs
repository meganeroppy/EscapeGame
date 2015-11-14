using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	private Rigidbody r;
	[SerializeField]
	private bool grouped = false;
	
	private AudioSource audioSource;
	
	private void Start(){
		r = GetComponent<Rigidbody>();
		r.constraints = RigidbodyConstraints.FreezeAll;
		audioSource = GetComponent<AudioSource>();
	}

	private void OnCollisionEnter(Collision col){
		if(col.gameObject.tag.Equals("PlayerHands")){
		//	Debug.Log("Break!");
			if(!grouped){
				audioSource.Play();
				r.constraints = RigidbodyConstraints.None;
				Destroy(r.gameObject, 3.0f);
			}else{
				audioSource.Play();
				
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
				audioSource.Play();
				r.constraints = RigidbodyConstraints.None;
				Destroy(r.gameObject, 3.0f);
			}else{
				audioSource.Play();
				Rigidbody[] rigidBodies = transform.parent.GetComponentsInChildren<Rigidbody>();
				foreach(Rigidbody rs in rigidBodies){
					rs.constraints = RigidbodyConstraints.None;
					Destroy(rs.gameObject, 3.0f);
				}
			}
		}
	}
}
