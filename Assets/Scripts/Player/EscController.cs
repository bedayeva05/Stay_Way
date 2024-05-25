using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscController : MonoBehaviour
{
	private bool pressed = false;
	private void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			pressed = !pressed;
		}

		Time.timeScale = pressed ? 0 : 1;

		
	}
}
