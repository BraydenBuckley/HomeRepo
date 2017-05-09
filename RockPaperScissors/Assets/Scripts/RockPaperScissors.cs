using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockPaperScissors : MonoBehaviour {

	private int playerLives;
	private int enemyLives;
	private int randomNumber;

	public Text gameOutputText;
	public Text playerLifeCounter;
	public Text enemyLifeCounter;
	public Button rockButton;
	public Button paperButton;
	public Button scissorButton;
	public Button restartButton;

	// Use this for initialization
	void Start () {
		playerLives = 3;
		enemyLives = 3;
		SetUpGame ();

	}

	private void SetUpGame(){
		//Change the text of the textbox
		gameOutputText.text = "Choose a move to make: Rock, Paper, Scissors";
		playerLifeCounter.text = playerLives.ToString ();
		enemyLifeCounter.text = enemyLives.ToString ();
		restartButton.gameObject.SetActive (false);
	}
	private void NewGame(){
		playerLives = 3;
		enemyLives = 3;
		SetUpGame ();
		rockButton.gameObject.SetActive (true);
		paperButton.gameObject.SetActive (true);
		scissorButton.gameObject.SetActive (true);

	}

	public void ClickButton(int buttonClicked){

		randomNumber = Random.Range (1, 4);

		if (buttonClicked == 1) {
			gameOutputText.text = "You chose Rock";

		} else if (buttonClicked == 2) {
			gameOutputText.text = "You chose Paper";

		} else if (buttonClicked == 3) {
			gameOutputText.text = "You chose Scissors";

		} else if (buttonClicked == 4) {
			NewGame ();

		}
		DoBattle (buttonClicked, randomNumber);
	}

	private void DoBattle(int playerChoice, int enemyChoice){

		if (playerChoice == enemyChoice) {
			gameOutputText.text += "\nThe enemy chose the same and you have drawn!";

		} else if (playerChoice == 2 && enemyChoice == 1) {
			gameOutputText.text += "\nThe enemy chose Rock and you have won!";
			enemyLives--;

		} else if (playerChoice == 2 && enemyChoice == 3) {
			gameOutputText.text += "\nThe enemy chose Scissors and you have lost!";
			playerLives--;

		} else if (playerChoice == 1 && enemyChoice == 2) {
			gameOutputText.text += "\nThe enemy chose Paper and you have lost!";
			playerLives--;

		} else if (playerChoice == 1 && enemyChoice == 3) {
			gameOutputText.text += "\nThe enemy chose Scissors and you have won!";
			enemyLives--;

		} else if (playerChoice == 3 && enemyChoice == 1) {
			gameOutputText.text += "\nThe enemy chose Rock and you have lost!";
			playerLives--;

		} else if (playerChoice == 3 && enemyChoice == 2) {
			gameOutputText.text += "\nThe enemy chose Paper and you have won!";
			enemyLives--;

		}

		//Update the UI to reflect the new values.
		//gameOutputText.text +="\n\nChoose a move to make: Rock, Paper, Scissors";
		playerLifeCounter.text = playerLives.ToString ();
		enemyLifeCounter.text = enemyLives.ToString ();

		if (playerLives == 0) {
			gameOutputText.text = "You have lost!";

			rockButton.gameObject.SetActive (false);
			paperButton.gameObject.SetActive (false);
			scissorButton.gameObject.SetActive (false);
			restartButton.gameObject.SetActive (true);

		} else if (enemyLives == 0) {
			gameOutputText.text = "You have won";

			rockButton.gameObject.SetActive (false);
			paperButton.gameObject.SetActive (false);
			scissorButton.gameObject.SetActive (false);
			restartButton.gameObject.SetActive (true);

		}
	}
}
