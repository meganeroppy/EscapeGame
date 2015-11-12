using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {

	public GameObject feet;
	public GameObject wall1;
	public GameObject wall2;
	public GameObject walltomei;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnCollisionEnter(Collision col){
		if(col.gameObject.tag.Equals("PlayerHands")){
			Debug.Log("pressed goal");
			this.feet.GetComponent<Rigidbody>().useGravity = true;
			this.wall1.SetActive(false);
			this.wall2.SetActive(false);
			//this.walltomei.SetActive(false);
		}
	}
}
