using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Gate : MonoBehaviour {
	
	[SerializeField]
	private Vector3 unlockedOffset;
	
	private bool unlockd = false;
	
	[SerializeField]
	private GateKey keyObject;
	
	private AudioSource audioSource;
	
	private void Awake(){
		audioSource = GetComponent<AudioSource>();
		transform.localPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if(keyObject == null){
			Debug.Log( "A keyObject has to be assigned!");
			return;
		}
		
		if(!unlockd && keyObject.unlocked){
			unlockd = true;
			Unlock();
		}
	}
	
	private void Unlock(){
		Debug.Log("Gate Unlocked");
		transform.DOLocalMove(transform.localPosition + unlockedOffset, 1f);
		audioSource.Play();
	}
}
