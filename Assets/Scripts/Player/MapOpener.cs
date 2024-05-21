using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapOpener : MonoBehaviour
{
    public GameObject firstMap;
    public GameObject wholeMap;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            gameObject.GetComponent<InteractiveMode>().PlayerControlFreeze();
            if (gameObject.GetComponent<PlayerProgress>().WholeMap)
            {
                ShowingWholeMap();
            }
            else
            {
                ShowingFirstMap();
            }
        }
    }
    public void ShowingFirstMap()
    {
        firstMap.SetActive(!firstMap.activeSelf);
    }
    public void ShowingWholeMap()
    {
        wholeMap.SetActive(!wholeMap.activeSelf);
    }
}
