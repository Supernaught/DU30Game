using UnityEngine;
using System.Collections;

public class Attackable : MonoBehaviour {

	public int hp;

	private Color origColor;

	public void Hit(int damage){
		hp -= damage;

		SpriteRenderer sp = GetComponent<SpriteRenderer> ();

		if (sp) {
			origColor = sp.color;
			sp.color = Color.white;
			Invoke ("ReturnToOriginalColor", 0.03f);
		}

		if (hp <= 0) {
			Die ();
		}
	}

	public void Die(){
		Destroy (this.gameObject);
	}

	void ReturnToOriginalColor(){
		
		GetComponent<SpriteRenderer>().color = origColor;
	}
}
