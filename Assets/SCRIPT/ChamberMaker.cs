using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class ChamberMaker : MonoBehaviour {

	
	[SerializeField]
	private int line = 10; // test
	[SerializeField]
	private int raw = 10;
	[SerializeField]
	private int floor = 10;

	[SerializeField]
	Vector3 c01 = new Vector3(0, 0, 0);
	Vector3 c02;
	Vector3 c03;
	Vector3 c04;
	Vector3 c05;
	
	[SerializeField]
	private GameObject player;
	[SerializeField]
	private GameObject playerVR;
	
	[SerializeField]
	private GameObject chamber01;
	[SerializeField]
	private GameObject chamber02;
	[SerializeField]
	private GameObject chamber03;
	[SerializeField]
	private GameObject chamber04;
	[SerializeField]
	private GameObject chamber05;
	[SerializeField]
	GameObject dummyChamber;
	
	private List<GameObject> chambers = new List<GameObject>();
	[SerializeField]
	private float fallInterval = 7f;
	private float fallFromY = 600f;
	private bool falled = false;
	
	[SerializeField]
	float duration = 300f;
	
	private float offset = 50f;
	
	[SerializeField]
	AudioClip se_executing;
	[SerializeField]
	AudioClip se_complete;
	AudioSource audioSource;

	void Awake(){
		audioSource = GetComponent<AudioSource>();
		c02 = c01 + new Vector3(1f, 0, 0);
		c03 = c01 + new Vector3(1f, 0, 1f);
		c04 = c01 + new Vector3(1f, 1f, 1f);
		c05 = c01 + new Vector3(0f, 1f, 1f);
	}

	// Use this for initialization
	void Start () {
		for(int f = 0 ; f < floor ; f++){
			for(int r = 0 ; r < raw ; r++){
				for(int l=0 ; l < line ; l++){
					GameObject g;
					bool preset = false;
					if(new Vector3(l, f, r) == c01){
						g =	Instantiate(chamber01);
						player.transform.position += new Vector3(l * offset, f * offset, r * offset);
						playerVR.transform.position += new Vector3(l * offset, f * offset, r * offset);
						preset = true;
					}else if(new Vector3(l, f, r) == c02){
						g =	Instantiate(chamber02);
						preset = true;
					}else if(new Vector3(l, f, r) == c03){
						preset = true;
						g =	Instantiate(chamber03);
					}else if(new Vector3(l, f, r) == c04){
						g =	Instantiate(chamber04);
					}else if(new Vector3(l, f, r) == c05){
						g =	Instantiate(chamber05);
					}else{
						g =Instantiate(dummyChamber);
					}
				
					g.transform.position = new Vector3(l * offset, f * offset, r * offset);
					g.transform.SetParent(transform);
					
					if(!preset){
					g.gameObject.SetActive(false);
					chambers.Add(g);
					}
				}
			}
		}
		
	}

	void Update(){
		audioSource.enabled = chambers.Count > 0;
	}


	public void FallChambers(){
		audioSource.Play();
		for(int i = 0 ; i < chambers.Count ; i++){
			GameObject g = chambers[i];
			Vector3 targetPos = g.transform.localPosition;
			g.SetActive(true);
			g.transform.localPosition += Vector3.up * fallFromY;
		//	int floor = (int)(g.transform.position.z / offset);
			g.transform.DOLocalMove(targetPos, duration).SetDelay(fallInterval * i * Random.Range(0.75f, 1.25f)).OnComplete(delegate{
				chambers.Remove(g);
		//		audioSource.PlayOneShot(se_complete);
			});
		}
	}


	
	

	
	

	



}
