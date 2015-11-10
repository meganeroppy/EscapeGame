using UnityEngine;
using System.Collections;
using DG.Tweening;

public class BeaconMaker : MonoBehaviour {

	[SerializeField]
	private GameObject beaconPrefab;
	private GameObject beacon;
	
	private Vector3 targetPos = Vector3.forward * 10;
	private Vector3 originPos = Vector3.zero;
	
	public Ease ease = Ease.Linear;
	
	public float duration = 0.75f;
	
	private float wait = 0f;	

	// Update is called once per frame
	void Update () {
	//	beacon.transform.localScale =  Vector3.one * ((resetTime - timer) /resetTime);
	}
	
	private void Restart(){
	
	//Debug.Log("Restart");
		beacon.transform.position = originPos;
		
		beacon.transform.DOMove(targetPos, duration).SetEase(ease).SetDelay(wait).OnComplete(delegate{
			Restart();
		});
	}
	
	public void UpdatePos(Vector3 originPos, Vector3 targetPos){
		if(beacon == null){
			beacon = Instantiate(beaconPrefab);
		}
		this.originPos = originPos;
		this.targetPos = targetPos;
		DOTween.Clear();
		Restart();
		
	}
}
