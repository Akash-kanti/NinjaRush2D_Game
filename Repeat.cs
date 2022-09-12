using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Repeat : MonoBehaviour
{
	public void RepeatGame()
	{
		Invoke("RestartGame",2f);
	}
	
	private void RestartGame()
	{
		SceneManager.LoadScene("Start");
	}

}
