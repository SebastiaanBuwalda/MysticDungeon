using UnityEngine;
using System.Collections;

public class OpenPathGenerator : MonoBehaviour {

	public bool amITheStartTile = false;

	private bool spawnedPlayer;

	[SerializeField]
	private GameObject mainChara;

	public static bool dungeonFinished = false;

	private bool amIAPath;

	public static int tileCount;

	public static int nextPath = -1;

	private SpriteRenderer spriteRenderer; 

	[SerializeField]
	private int tileIdentifier;

	[SerializeField]
	private Sprite winTileSprite;
	[SerializeField]
	private Sprite pathTileSprite;

	private int tileToTheLeft;
	private int tileToTheRight;
	private int tileToTheNorth;
	private int tileToTheSouth;

	public static Vector2 targetTilePosition;
	public static bool winPositionFound = false;
	public static bool startPositionFound = false;
	public static bool endReached = false;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();

		tileIdentifier = tileCount;
		tileToTheLeft = tileIdentifier - 1;
		tileToTheRight = tileIdentifier + 1;
		tileToTheNorth = tileIdentifier + DungeonGenerator.xTileModifier;
		tileToTheSouth = tileIdentifier - DungeonGenerator.xTileModifier;
		tileCount++;

		if (tileIdentifier == DungeonGenerator.startTile) {
			amITheStartTile = true;
			nextPath = DungeonGenerator.startTile;
			startPositionFound = true;
		}
		if (tileIdentifier == DungeonGenerator.winTile) {
			spriteRenderer.sprite = winTileSprite;
			this.gameObject.tag = "Win";
			winPositionFound = true;
		}
	}	

	void FixedUpdate ()
	{
		if (dungeonFinished == false) {
			if (winPositionFound && startPositionFound) {
				if (DungeonGenerator.compCounter == DungeonGenerator.complicationTiles.Count) {
					if (tileIdentifier == DungeonGenerator.winTile) {
						DungeonGenerator.complicationTiles.Add (tileIdentifier);
					}
				}
				//Debug.Log (DungeonGenerator.complicationTiles [DungeonGenerator.compCounter]);
				if (DungeonGenerator.complicationTiles.Count > DungeonGenerator.compCounter) {
					if (tileIdentifier == DungeonGenerator.complicationTiles [DungeonGenerator.compCounter]) {
						targetTilePosition = this.transform.position;
					}
				}
			}
			if (DungeonGenerator.complicationTiles.Count > DungeonGenerator.compCounter) {
				if (nextPath == DungeonGenerator.complicationTiles [DungeonGenerator.compCounter]) {
					DungeonGenerator.compCounter++;
				}
			}

			if (tileIdentifier == nextPath && nextPath != DungeonGenerator.winTile) {
				spriteRenderer.sprite = pathTileSprite;
				this.gameObject.tag = "Passable";
				if (this.transform.position.y < targetTilePosition.y) {
					nextPath = tileToTheNorth;
				}
				if (this.transform.position.y > targetTilePosition.y) {
					nextPath = tileToTheSouth;
				}
				if (this.transform.position.x > targetTilePosition.x) {
					nextPath = tileToTheLeft;
				}
				if (this.transform.position.x < targetTilePosition.x) {
					nextPath = tileToTheRight;
				}
			}
			if (nextPath == DungeonGenerator.winTile) {
				Debug.Log ("DUNGEON FINISHED!");
				dungeonFinished = true;
			}
		} 
		else 
		{
			if (tileIdentifier == DungeonGenerator.startTile&&spawnedPlayer==false) 
			{
				Instantiate (mainChara,this.transform.position,Quaternion.identity);
				spawnedPlayer = true;
			}
		}
	}
}