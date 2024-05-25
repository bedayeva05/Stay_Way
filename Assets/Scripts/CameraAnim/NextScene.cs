using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
	public int scene;
	public void SwitchScene()
	{
		SceneManager.LoadScene(scene);
	}
}
