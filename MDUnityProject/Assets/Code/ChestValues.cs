using UnityEngine;
using System.Collections;

public class ChestValues : MonoBehaviour {

	public float myMoneyValue;
	
	[SerializeField] 
	private float[] possibleMoneyValues;

	// Use this for initialization
	void Start () 
	{
		myMoneyValue = possibleMoneyValues [Random.Range (0, possibleMoneyValues.Length)];
	}
}
