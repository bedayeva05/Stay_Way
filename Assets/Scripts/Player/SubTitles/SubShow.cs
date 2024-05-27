using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubShow : MonoBehaviour
{
	public bool wholeMap;
	public bool emptyBook;
	public bool wholeBook;
	public bool roomExamine;

	public GameObject subs;
    public GameObject subs1;
    private bool subShown = false;
    public float timer;
    public float timer1;

	public bool condition;
	public bool startTimer = false;
	public bool startTimer1 = false;
	public PlayerProgress progress;

    private void Start()
	{
		subs.SetActive(false);
        subs1.SetActive(false);
	}
	void Update()
    {
		ConditionUpdate();

		if (Input.GetKeyDown(KeyCode.R) && condition)
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

	public void ConditionUpdate()
	{
		if (wholeMap)
		{
			condition = progress.WholeMap;
		}
		if (emptyBook)
		{
			condition = progress.EmptyBook;
		}
		if (wholeBook)
		{
			condition = progress.WholeBook;
		}
		if (roomExamine)
		{
			condition = progress.RoomExamine;
		}
	}
}
