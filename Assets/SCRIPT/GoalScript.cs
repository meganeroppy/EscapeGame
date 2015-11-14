using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {
	
	public GameObject feet;
	
	public GameObject wall1;
	public GameObject wall2;
	public GameObject walltomei;

	private SpriteRenderer img;

	[SerializeField]
	private Sprite locked_img;
	[SerializeField]
	private Sprite unlocked_img;

	private bool unlocked = false;
	
	private AudioSource audioSource;
	
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		img = transform.GetChild(0).GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		img.sprite = unlocked ? unlocked_img : locked_img;
	}
	
	private void OnTriggerEnter(Collider col){
		if(col.gameObject.tag.Equals("PlayerHands")){
			Debug.Log("pressed goal");
			this.feet.GetComponent<Rigidbody>().useGravity = true;
			this.wall1.SetActive(false);
			this.wall2.SetActive(false);
			//this.walltomei.SetActive(false);

			if(!unlocked){
				unlocked = true;
				audioSource.Play();
			}
		}
	}
	
	private void OnCollisionEnter(Collision col){
		if(col.gameObject.tag.Equals("PlayerHands")){
			Debug.Log("pressed goal");
			this.feet.GetComponent<Rigidbody>().useGravity = true;
			this.wall1.SetActive(false);
			this.wall2.SetActive(false);
			//this.walltomei.SetActive(false);
			if(!unlocked){
				unlocked = true;
				audioSource.Play();
			}
		}
	}
}
