using UnityEngine;
using System.Collections;

public class TempBullet : MonoBehaviour {

	float lifeTime = 3f;
	float timer = 0f;

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer >= lifeTime){
			Destroy (this.gameObject);
		}
	}
}
