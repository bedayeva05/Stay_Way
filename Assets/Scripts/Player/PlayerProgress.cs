using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    public bool FirstCrack = false;
    //public bool FirstMapPiece = false;
    public bool WholeMap = false;
    public bool EmptyBook = false;
    //public bool BookPapers = false;
    public bool WholeBook = false;
    public bool StatuesRiddle = false;
    public bool KeyIsTaken = false;
    public bool DoorIsOpened = false;
    public bool Candles = false;
    public bool Mirror = false;
    public bool Cross = false;
    public bool Chalk = false;
    public bool RitualIsReady = false;

    public GameObject EscapeUI;
    public GameObject FindEmptyBookUI;
    public GameObject FindWholeBookUI;
    public GameObject GardenUI;
    public GameObject OpenDoorUI;
    public GameObject RoomExamineUI;
    public GameObject FindRitualObjectsUI;
    public GameObject MakeRitualUI;


    public void ResetAllPlayerPrefs()
    {
        FirstCrack = false;
        WholeMap = false;
        EmptyBook = false;
        WholeBook = false;
        StatuesRiddle = false;
        KeyIsTaken = false;
        DoorIsOpened = false;
        Candles = false;
        Mirror = false;
        Cross = false;
        Chalk = false;
        RitualIsReady = false;
        EscapeUI.SetActive(true);
        FindEmptyBookUI.SetActive(false);
        FindWholeBookUI.SetActive(false);
        GardenUI.SetActive(false);
        OpenDoorUI.SetActive(false);
        RoomExamineUI.SetActive(false);
        FindRitualObjectsUI.SetActive(false);
        MakeRitualUI.SetActive(false);
        SaveProgress();
    }
    private void Start()
    {
        SetCross();
        SetCandles();
        SetChalk();
        SetMirror();
        LoadProgress();
    }
    public void ResetUI()
    {
        EscapeUI.SetActive(false);
        FindEmptyBookUI.SetActive(false);
        FindWholeBookUI.SetActive(false);
        GardenUI.SetActive(false);
        OpenDoorUI.SetActive(false);
        RoomExamineUI.SetActive(false);
        FindRitualObjectsUI.SetActive(false);
        MakeRitualUI.SetActive(false);
    }
    public void SaveProgress()
    {
        PlayerPrefs.SetInt("FirstCrack", FirstCrack ? 1 : 0);
        //PlayerPrefs.SetInt("FirstMapPiece", FirstMapPiece ? 1 : 0);
        PlayerPrefs.SetInt("WholeMap", WholeMap ? 1 : 0);
        PlayerPrefs.SetInt("EmptyBook", EmptyBook ? 1 : 0);
        //PlayerPrefs.SetInt("BookPapers", BookPapers ? 1 : 0);
        PlayerPrefs.SetInt("WholeBook", WholeBook ? 1 : 0);
        PlayerPrefs.SetInt("StatuesRiddle", StatuesRiddle ? 1 : 0);
        PlayerPrefs.SetInt("KeyIsTaken", KeyIsTaken ? 1 : 0);
        PlayerPrefs.SetInt("DoorIsOpened", DoorIsOpened ? 1 : 0);
        PlayerPrefs.SetInt("Candles", Candles ? 1 : 0);
        PlayerPrefs.SetInt("Mirror", Mirror ? 1 : 0);
        PlayerPrefs.SetInt("Cross", Cross ? 1 : 0);
        PlayerPrefs.SetInt("Chalk", Chalk ? 1 : 0);
        PlayerPrefs.SetInt("RitualIsReady", RitualIsReady ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void LoadProgress()
    {
        FirstCrack = PlayerPrefs.GetInt("FirstCrack", 0) == 1;
        //FirstMapPiece = PlayerPrefs.GetInt("FirstMapPiece", 0) == 1;
        WholeMap = PlayerPrefs.GetInt("WholeMap", 0) == 1;
        EmptyBook = PlayerPrefs.GetInt("EmptyBook", 0) == 1;
        //BookPapers = PlayerPrefs.GetInt("BookPapers", 0) == 1;
        WholeBook = PlayerPrefs.GetInt("WholeBook", 0) == 1;
        StatuesRiddle = PlayerPrefs.GetInt("StatuesRiddle", 0) == 1;
        KeyIsTaken = PlayerPrefs.GetInt("KeyIsTaken", 0) == 1;
        DoorIsOpened = PlayerPrefs.GetInt("DoorIsOpened", 0) == 1;
        Candles = PlayerPrefs.GetInt("Candles", 0) == 1;
        Mirror = PlayerPrefs.GetInt("Mirror", 0) == 1;
        Cross = PlayerPrefs.GetInt("Cross", 0) == 1;
        Chalk = PlayerPrefs.GetInt("Chalk", 0) == 1;
        RitualIsReady = PlayerPrefs.GetInt("RitualIsReady", 0) == 1;
    }
    public void SetFirstCrack()
    {
        ResetUI();
        FindEmptyBookUI.SetActive(true);
        FirstCrack = true;
        SaveProgress();
    }
    public void SetWholeMap()
    {
        WholeMap = true;
        SaveProgress();
    }

    public void SetEmptyBook()
    {
        ResetUI();
        FindWholeBookUI.SetActive(true);
        EmptyBook = true;
        SaveProgress();
    }
    public void SetWholeBook()
    {
        ResetUI();
        GardenUI.SetActive(true);
        WholeBook = true;
        SaveProgress();
    }

    public void SetStatuesRiddle()
    {
        StatuesRiddle = true;
        SaveProgress();
    }

    public void SetKeyIsTaken()
    {
        ResetUI();
        OpenDoorUI.SetActive(true);
        KeyIsTaken = true;
        SaveProgress();
    }

    public void SetDoorIsOpened()
    {
        ResetUI();
        RoomExamineUI.SetActive(true);
        DoorIsOpened = true;
        SaveProgress();
    }
    public void SetRoomDiscovered()
    {
        ResetUI();
        FindRitualObjectsUI.SetActive(true);
        SaveProgress();

    }
    public void SetCandles()
    {
        Candles = true;
        RitualIsReady = Candles && Mirror && Cross && Chalk;
        if(RitualIsReady)
        {
            ResetUI();
            MakeRitualUI.SetActive(true);
        }
        SaveProgress();
    }

    public void SetMirror()
    {
        Mirror = true;
        RitualIsReady = Candles && Mirror && Cross && Chalk;
        if (RitualIsReady)
        {
            ResetUI();
            MakeRitualUI.SetActive(true);
        }
        SaveProgress();
    }

    public void SetCross()
    {
        Cross = true;
        RitualIsReady = Candles && Mirror && Cross && Chalk;
        if (RitualIsReady)
        {
            ResetUI();
            MakeRitualUI.SetActive(true);
        }
        SaveProgress();
    }

    public void SetChalk()
    {
        Chalk = true;
        RitualIsReady = Candles && Mirror && Cross && Chalk;
        if (RitualIsReady)
        {
            ResetUI();
            MakeRitualUI.SetActive(true);
        }
        SaveProgress();
    }

    /*public void SetRitualIsReady(bool value)
    {
        RitualIsReady = value;
        SaveProgress();
    }*/

}
