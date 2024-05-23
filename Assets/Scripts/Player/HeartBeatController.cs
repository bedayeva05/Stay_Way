using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeatController : MonoBehaviour
{
    public AudioSource audio;
	public GameObject prefab;
	public float maxDistanceToPrefab;

	private void Update()
	{
		float distanceToPrefab = Vector3.Distance(this.transform.position, prefab.transform.position);

		audio.mute = distanceToPrefab <= maxDistanceToPrefab ? false : true;
	}
}
