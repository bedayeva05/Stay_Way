using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    public int currentLevelIndex;
    public string[] levelNames = {
        "StartingLevel", //0
        "FirstCrackIsFound", //1
        "FirstMapPieceIsFound", //2
        "TwoMapPiecesAreFound", //3
        "EmptyBookIsFound", //4
        "BookPapersAreFound", //5
        "BookIsCompleted", //6
        "StatuesRiddleIsSolved", //7
        "KeyIsTaken", //8
        "DoorIsOpened", //9
        "RitualIsReady", //10
        "GameCompleted" //11
    };

    public GameObject[] levelsUI;
    void Start()
    {
        //int currentLevelIndex = PlayerPrefs.GetInt("currentLevel")
    }
    public void SetLevel(int neededLevelIndex)
    {
        SendMessage(levelNames[neededLevelIndex]);
        UpdateUI();
    }
    public void FirstCrackIsFound()
    {
        if (currentLevelIndex == 0)
        {
            currentLevelIndex = 1;
        }
    }
    public void UpdateUI()
    {
        if (currentLevelIndex > 0)
        {
            levelsUI[currentLevelIndex - 1].SetActive(false);
        }
        levelsUI[currentLevelIndex].SetActive(true);
    }

}
