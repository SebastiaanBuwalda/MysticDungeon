using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DungeonGenerator : MonoBehaviour {


	//These 2 variables decide how many tiles wide and long the dungeon will be.
	[SerializeField]
	private int xGridSize = 5;
	[SerializeField]
	private int yGridSize = 5;


	//These decide how large an individual tile is.
	[SerializeField]
	private float xTileLength = 10;
	[SerializeField]
	private float yTileLength = 10;

	//I use this variable to keep track of the number of tiles.

	public static int startTile;
	public static int winTile;

	public static List<int> complicationTiles = new List<int>();

	[SerializeField]
	private int complicationFactor;

	[SerializeField]
	private GameObject Tile;

	public static int xTileModifier;
	public static int yTileModifier;

	private int numberOfTiles;

	public static int compCounter = 0;

	void Start () {
		xTileModifier = xGridSize;
		yTileModifier = yGridSize;
		numberOfTiles = xGridSize * yGridSize;
        OpenPathGenerator.startPositionFound = false;
        OpenPathGenerator.winPositionFound = false;
        OpenPathGenerator.tileCount = 0;
        OpenPathGenerator.dungeonFinished = false;

		recallTiles ();


		for(int counterY = 0; counterY<yGridSize; counterY++)
		{
			for(int counterX = 0; counterX<xGridSize; counterX++)
			{
				Instantiate(Tile ,new Vector2(counterX*xTileLength,counterY*yTileLength), Quaternion.identity);
			}
		}
	}

	void recallTiles()
	{
		startTile = Random.Range (0, numberOfTiles);
		winTile = Random.Range (0, numberOfTiles);

		for (int counter = 0; counter<complicationFactor; counter++)
		{
			complicationTiles.Add (Random.Range (0, numberOfTiles));
		}
		if (startTile == winTile) {
			recallTiles ();
		}
	}
}
