using UnityEngine;
using System.Collections;

public class FadeAfterTime : MonoBehaviour {

	public float timeUntilFade;

	void Update () {
		if (timeUntilFade > 0) {
			timeUntilFade = timeUntilFade - Time.deltaTime;
		} 
		else 
		{
			this.gameObject.SetActive (false);
		}

	}
}
