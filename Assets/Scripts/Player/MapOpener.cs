using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapOpener : MonoBehaviour
{
    public GameObject mapUI;
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
        mapUI.SetActive(!mapUI.activeSelf);
        firstMap.SetActive(!firstMap.activeSelf);
    }
    public void ShowingWholeMap()
    {
        mapUI.SetActive(!mapUI.activeSelf);
        wholeMap.SetActive(!wholeMap.activeSelf);
    }
}
