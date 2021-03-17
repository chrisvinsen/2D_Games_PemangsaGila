using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneController : MonoBehaviour
{
	public static bool resetGame;
	public static float start;
	public static int playerIQ;

	public void ChangeToChooseCharacterScene()
	{
		SceneManager.LoadScene("ChooseCharacterScene");
	}

	public void ChangeToMainMenuScene()
	{
		SceneManager.LoadScene("MainMenuScene");
	}

	public void ChangeToStoryScene()
	{
		SceneManager.LoadScene("StoryScene");
		start = Time.realtimeSinceStartup;
	}

	public void ChangeToGameScene()
	{
		GameManager.Instance.reset = true;
		SceneManager.LoadScene("Stages");
	}

	public void BackToGameScene()
	{
		GameManager.Instance.reset = false;
		SceneManager.LoadScene("Stages");
	}

	public void ChangeToWinScene(int iq)
	{
		SceneManager.LoadScene("WinScene");
		playerIQ = iq;
	}

	public void ChangeToLoseScene()
	{
		SceneManager.LoadScene("LoseScene");
	}

	public void PauseGame() 
	{
		Time.timeScale = 0;
	}

	public void ResumeGame()
	{
		Time.timeScale = 1;
	}

	public void QuitGame()
	{
		Debug.Log("QUIT");
		Application.Quit();
	}
}
