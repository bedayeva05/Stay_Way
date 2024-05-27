using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenTrigger : MonoBehaviour
{
	public PlayerProgress player;
	public SubShowInTheGarden sub;

	private void Start()
	{
		player = FindObjectOfType<PlayerProgress>();
		sub = FindObjectOfType<SubShowInTheGarden>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == player.tag)
		{
			if(player.WholeBook) sub.inTheGarden = true;
		}
	}

}
