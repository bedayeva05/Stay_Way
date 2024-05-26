using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroyer : MonoBehaviour
{
    public int activeScene;
    public int[] destroyScene;
    void Update()
    {
        activeScene = SceneManager.GetActiveScene().buildIndex;
        foreach (int i in destroyScene)
        {
            if (i == activeScene)
            {
				Destroy(this.gameObject); return;
			}
        }
    }
}
