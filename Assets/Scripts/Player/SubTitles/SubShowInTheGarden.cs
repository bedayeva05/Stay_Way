using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubShowInTheGarden : MonoBehaviour
{
	public bool inTheGarden;
	public GameObject subs;
    public GameObject subs1;
    private bool subShown = false;
    public float timer;
    public float timer1;
	public bool startTimer = false;
	public bool startTimer1 = false;

    private void Start()
	{
		subs.SetActive(false);
        subs1.SetActive(false);
	}
	void Update()
    {
		if (inTheGarden && !subShown)
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
				startTimer1 = true;
			}
			if (subShown && subs1 != null)
			{
				if (timer1 > 0)
				{
					subs1.SetActive(true);
					timer1 -= Time.deltaTime;
				}
				else
				{
					subs1.SetActive(false);
				}
			}
		}
	}
}
