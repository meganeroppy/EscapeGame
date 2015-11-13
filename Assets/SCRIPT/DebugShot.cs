using UnityEngine;
using System.Collections;

public class DebugShot : MonoBehaviour {

	float lifeLength = 5f;
	float timer = 0f;
	Vector3 originPos;

	void Start(){
		originPos = transform.position;
	}

	// Update is called once per frame
	void Update () {
		if( Mathf.Abs((transform.position - originPos).magnitude) >= lifeLength){
			Destroy(this.gameObject);
		}
			/* 
		timer += Time.deltaTime;
		if(timer >= lifeTime){
			Destroy (this.gameObject);
		}
		*/
	}
}
