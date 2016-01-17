using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Vector3 positionToGoTo; 

	[SerializeField]
	private float gridTileSize = 0.32f;

	[SerializeField]
	private float movementSpeed = 2.0f;

	void Start () {
		positionToGoTo = transform.position;          
	}

	void FixedUpdate () {
		if(Input.GetKey(KeyCode.A) && transform.position == positionToGoTo) 
		{        
			positionToGoTo.x -= gridTileSize;
		}
		if(Input.GetKey(KeyCode.D) && transform.position == positionToGoTo) 
		{       
			positionToGoTo.x += gridTileSize;
		}
		if(Input.GetKey(KeyCode.W) && transform.position == positionToGoTo) 
		{        
			positionToGoTo.y += gridTileSize;
		}
		if(Input.GetKey(KeyCode.S) && transform.position == positionToGoTo) 
		{
			positionToGoTo.y -= gridTileSize;
		}
		RaycastHit2D rayHit = Physics2D.Raycast(positionToGoTo, Vector3.down);
		if (rayHit) 
		{
			if (rayHit.transform.tag != "Solid") 
			{
				transform.position = Vector2.MoveTowards (transform.position, positionToGoTo, Time.deltaTime * movementSpeed);   
			} 
			else 
			{
				positionToGoTo = this.transform.position;
			}
		}
		if(!rayHit)
		{
			positionToGoTo = this.transform.position;
		}
	}
}
