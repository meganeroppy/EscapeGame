using UnityEngine;
using System.Collections;

public class FallTrigger : JumpTarget {

	protected override void SetAsFound(){
		base.SetAsFound();
		GameObject o;
		if(o = GameObject.Find("ChamberMaker")){
			o.GetComponent<ChamberMaker>().FallChambers();
		}
	}
}
