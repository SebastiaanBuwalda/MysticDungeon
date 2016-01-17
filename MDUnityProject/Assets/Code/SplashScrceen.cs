using UnityEngine;
using System.Collections;

public class SplashScrceen : MonoBehaviour {

	private GameObject playerObject;

	void Update () {
		playerObject = GameObject.FindGameObjectWithTag ("Player");
		if (playerObject != null) 
		{
			Debug.Log ("!!!!!");
			gameObject.SetActive(false);
		}
	}
}
