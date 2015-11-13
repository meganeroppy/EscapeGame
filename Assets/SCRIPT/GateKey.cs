using UnityEngine;
using System.Collections;

public class GateKey : MonoBehaviour {

	public bool unlocked{get;private set;}
	private SpriteRenderer img;
	[SerializeField]
	private Sprite locked_img;
	[SerializeField]
	private Sprite unlocked_img;

	private void Awake(){
		unlocked = false;
		img = transform.GetChild(0).GetComponent<SpriteRenderer>();
	}
	
	void Update(){
		img.sprite = unlocked ? unlocked_img : locked_img;
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
