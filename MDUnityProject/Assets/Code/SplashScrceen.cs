using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SplashScrceen : MonoBehaviour {

    public static int floorNumber = 0;

	private GameObject playerObject;

    [SerializeField]
    private Text floorText;

    [SerializeField]
    private bool useGroundFloors = false;

    [SerializeField]
    private string dungeonName;

    [SerializeField]
    private int numberOfDungeonFloors = 5;

    private GameObject dungeonGenerator;



    void Start()
    {
        dungeonGenerator = GameObject.FindGameObjectWithTag("DungeonGenerator");
        if (floorNumber < numberOfDungeonFloors)
        {
            floorNumber++;
            if (useGroundFloors)
            {
                floorText.text = dungeonName + " B" + floorNumber + "F";
            }
            else
            {
                floorText.text = dungeonName + " " + floorNumber + "F";
            }
        }
        else
        {
            floorText.text = PlayerStatistics.playerName + " made it to the end of " + dungeonName + "!";
            dungeonGenerator.SetActive(false);
        }
    }

    void Update()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            gameObject.SetActive(false);

        }
    }
}
