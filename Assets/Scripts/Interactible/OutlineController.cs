using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OutlineController : MonoBehaviour
{
    private Outline outline;
	public float timer;
	private float timerPref;
	private void Start()
	{
		outline = GetComponent<Outline>();
		timerPref = timer;
	}

	private void OnMouseOver()
	{
		outline.enabled = true;
	}
	private void OnMouseExit()
	{
		outline.enabled = false;
	}

}
