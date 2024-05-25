using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OutlineController : MonoBehaviour
{  
    public Outline outline;
	public bool lightSwitch;

	private void Start()
	{
		outline = GetComponent<Outline>();
	}

	public void SetBool(bool value)
	{
		lightSwitch = value;
	}

	private void OnMouseOver()
	{
		outline.enabled = lightSwitch ? true : false;
	}
	private void OnMouseExit()
	{
		outline.enabled = false;
	}

}
