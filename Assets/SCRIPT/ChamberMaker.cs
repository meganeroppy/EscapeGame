using UnityEngine;
using System.Collections;

public class ChamberMaker : MonoBehaviour {

	private int line = 10; // test
	private int raw = 10;
	private int floor = 10;

	Vector3 c01 = new Vector3(0, 0, 0);
	Vector3 c02;
	Vector3 c03;
	Vector3 c04;
	Vector3 c05;

	
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
	
	private float offset = 50f;

	void Awake(){
		c02 = c01 + new Vector3(1f, 0, 0);
		c03 = c01 + new Vector3(1f, 1f, 0);
		c04 = c01 + new Vector3(1f, 1f, 1f);
		c05 = c01 + new Vector3(0f, 1f, 1f);
	}

	// Use this for initialization
	void Start () {
		for(int l = 0 ; l < line ; l++){
			for(int r = 0 ; r < raw ; r++){
				for(int f=0 ; f < floor ; f++){
					GameObject g;
				
					if(new Vector3(l, r, f) == c01){
						g =	Instantiate(chamber01);
					}else if(new Vector3(l, r, f) == c02){
						g =	Instantiate(chamber02);
					}else if(new Vector3(l, r, f) == c03){
						g =	Instantiate(chamber03);
					}else if(new Vector3(l, r, f) == c04){
						g =	Instantiate(chamber04);
					}else if(new Vector3(l, r, f) == c05){
						g =	Instantiate(chamber05);
					}else{
						g =Instantiate(dummyChamber);
					}
				
					g.transform.position = new Vector3(l * offset, r * offset, f * offset);
					g.transform.SetParent(transform);
				}
			}
		}
	}


	
	

	
	

	



}
