using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionMenu : MonoBehaviour
{
	private GameManager gameManager;
	private Button interactButton, spawnButton;
	private Button scoreButton;
  
	private TMPro.TextMeshProUGUI turnIndicator;

	// Start is called before the first frame update
	void Start()
    {
		gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
		interactButton = GameObject.Find("Interact Button").GetComponent<Button>();

		spawnButton = GameObject.Find("Spawn Button").GetComponent<Button>();
		scoreButton = GameObject.Find("Score Button").GetComponent<Button>();

		turnIndicator = GameObject.Find("Turn Indicator").GetComponent<TMPro.TextMeshProUGUI>();
	}

	public void OnInteractClick()
	{
		gameManager.StartInteraction();
	}


	public void onSpawn()
	{
		gameManager.Spawn();
  }
  
	public void OnScoreClick()
	{
		gameManager.Score();
	}

	void Update()
	{
		interactButton.interactable = gameManager.CanInteract();
		turnIndicator.text = gameManager.GetPlayerOneScore().ToString() + " " + gameManager.GetCurrentPlayer().Name + "'s turn " + gameManager.GetPlayerTwoScore().ToString();
	}
}
