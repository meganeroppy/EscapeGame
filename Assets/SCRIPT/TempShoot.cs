using UnityEngine;
using System.Collections;

public class TempShoot : MonoBehaviour {

	[SerializeField]
	private GameObject bullet;
	private float force = 1500f;

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			GameObject o = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
			o.GetComponent<Rigidbody>().AddForce(transform.forward * force);
		}
	}
}
