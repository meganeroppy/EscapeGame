using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JumpTarget : MonoBehaviour {

	private GameObject player;
	private List<GameObject> child = new List<GameObject>();

	// Use this for initialization
	void Awake () {
		player = GameObject.Find("Player");
		if( transform.childCount > 0){
			for(int i=0 ; i < transform.childCount ; i++){
				child.Add(transform.GetChild(i).gameObject);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject g in child){
			g.SetActive(player.transform.position != this.transform.position);
		}
	}
}
