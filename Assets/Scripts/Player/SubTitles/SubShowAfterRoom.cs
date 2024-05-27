using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubShowAfterRoom : MonoBehaviour
{
	public bool roomExamine;

	public GameObject subs;
    private bool subShown = false;
    public float timer;

	public bool condition;
	public bool startTimer = false;
	public PlayerProgress progress;

    private void Start()
	{
		subs.SetActive(false);
	}
	void Update()
    {
		condition = progress.RoomExamine;
		if (!subShown && condition)
        {
			startTimer = true;
        }
		if(startTimer)
		{
			if (timer > 0)
			{
				subs.SetActive(true);
				timer -= Time.deltaTime;
			}
			else
			{
				subs.SetActive(false);
				subShown = true;
			}
		}
	}
}
