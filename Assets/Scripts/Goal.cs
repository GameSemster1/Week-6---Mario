using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
	public string playerTag;

	// Start is called before the first frame update
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag(playerTag))
			LoadNextLevel();
	}

	private void LoadNextLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}