using UnityEngine;
using System.Collections;

public class ObjectsGenerator : MonoBehaviour {

	[SerializeField]
	private GameObject[] possibleSpawnList;

	[SerializeField]
	private float[] spawnChancePercentage;

	private bool haveISpawned = false;

	private int counter = 0;

	private int tileIdentifier;

	private OpenPathGenerator pathMakerScript;

	void Start()
	{
		pathMakerScript = GetComponent<OpenPathGenerator> ();
	}

	void Update () 
	{
		//Debug.Log (counter);
		if (this.gameObject.tag == "Passable"&&haveISpawned == false&&pathMakerScript.amITheStartTile==false) 
		{
			if (counter < possibleSpawnList.Length) 
			{
				foreach (GameObject possibleSpawnedObject in possibleSpawnList) 
				{
					if (Random.value > (1 - spawnChancePercentage [counter] / 100)) 
					{
						Instantiate (possibleSpawnedObject, this.transform.position, Quaternion.identity);
						haveISpawned = true;
					} 
					else 
					{
						counter++;
					}
				}
			}
		}
	}
}
