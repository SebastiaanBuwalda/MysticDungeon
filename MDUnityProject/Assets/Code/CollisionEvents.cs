﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollisionEvents : MonoBehaviour {

	[SerializeField]
	private GameObject dialogueBox;

	[SerializeField]
	private Text dialogueText;

	private FadeAfterTime dialogueBoxFader;

	// Use this for initialization
	void Start () {
		dialogueBox.SetActive (false);
		dialogueBoxFader = dialogueBox.GetComponent<FadeAfterTime> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "TreasureChest") 
		{
			ChestValues otherChestValue = other.GetComponent<ChestValues>();
			float moneyRecieved = otherChestValue.myMoneyValue;
			dialogueBox.SetActive (true);
			dialogueText.text = "The treasure chest contains "+moneyRecieved+" gold.";
			dialogueBoxFader.timeUntilFade = 2;
			Destroy (other.gameObject);
		}
	}
}
