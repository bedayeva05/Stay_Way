using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	public GameObject gameOverScreen;
	public AudioSource scream;
	public int currentHealth = 0;
	private void Start()
	{
		PlayerPrefs.SetInt("Health", currentHealth);
	}
	public void MakeDamage()
	{
		currentHealth += 1;
		PlayerPrefs.SetInt("Health", currentHealth);
		PlayerPrefs.Save();
		if (currentHealth >= 5)
		{
			gameObject.GetComponent<PlayerProgress>().ResetAllPlayerPrefs();
			PlayerPrefs.SetInt("Health", 0);
			gameObject.GetComponent<InteractiveMode>().PlayerControlFreeze();
			gameOverScreen.SetActive(true);
			Invoke("LostGame", 3);
			scream.Play();
		}
	}
	public void LostGame()
	{
		gameOverScreen.SetActive(false);
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;
		SceneManager.LoadScene(0);
	}
}
