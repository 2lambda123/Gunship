using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {

public float Health = 10f;

	public void ApplyDamage (float d) {
		Health -= d;
		//print("ApplyDamage "+d);
		if (Health <= 0)
			Destroy (this.gameObject);
	}
}
