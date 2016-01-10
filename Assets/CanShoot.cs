using UnityEngine;
using System.Collections;

public class CanShoot : MonoBehaviour {

	public GameObject bullet;

	public bool canAtk;
	public float atkDelay;

	// Use this for initialization
	void Start () {
		canAtk = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Shoot(Vector3 pos, Quaternion rot){
		if (canAtk) {
			SimplePool.Spawn (bullet, pos, rot);
			
			canAtk = false;
			Invoke ("EnableCanAtk", atkDelay);
		}
	}

	void EnableCanAtk(){
		canAtk = true;
	}
}
