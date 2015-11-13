using UnityEngine;
using System.Collections;

public class FeetScript : MonoBehaviour {

	public GameObject currentBody;

	public GameObject perfectBody;

	public GameObject pipe;

	public AudioClip gattaiSound;

	// Use this for initialization
	void Start () {
	
	}

	private void OnTriggerEnter(Collider col){
		if (col.gameObject.layer == ConstantScript.FLOOR_LAYER) {
			Debug.Log ("jatuhhhcoi");
			this.pipe.SetActive (false);
			this.gameObject.SetActive (false);
			if(this.GetComponent<AudioSource>().enabled){
				this.GetComponent<AudioSource>().Play();
			}
			
			this.currentBody.SetActive (false);
			this.perfectBody.SetActive (true);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
