using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStatistics : MonoBehaviour {

    [SerializeField]
    private Text healthIndicator;
    [SerializeField]
    private Text walletIndicator;

    private float maxHealth;
	
	public static float playerHealth = 100;
	public static float playerWallet = 0;

    public static string playerName = "WIZARD";

    void Start()
    {
        maxHealth = playerHealth;
        UIUpdate();
    }

    public void UIUpdate()
    {
        healthIndicator.text = ("HP:" + maxHealth + "/" + playerHealth);
        walletIndicator.text = ("Gold: "+playerWallet);
    }
}
