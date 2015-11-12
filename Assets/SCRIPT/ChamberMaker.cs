using UnityEngine;
using System.Collections;

public class ChamberMaker : MonoBehaviour {

	private int line = 10; // test
	private int raw = 10;
	private int floor = 10;

	[SerializeField]
	GameObject chamber;
	
	private float offset = 50f;

	// Use this for initialization
	void Start () {
		for(int l = 0 ; l < line ; l++){
			for(int r = 0 ; r < raw ; r++){
				for(int f=0 ; f < floor ; f++){
					GameObject g = Instantiate(chamber);
					g.transform.position = new Vector3(l * offset, r * offset, f * offset);
					g.transform.SetParent(transform);
				}
			}
		}
	}

}
