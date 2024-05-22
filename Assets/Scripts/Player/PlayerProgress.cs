﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    //public bool FirstCrack = false;
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

    public void ResetAllPlayerPrefs()
    {
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
        SaveProgress();
}

    private void Start()
    {
        LoadProgress();

        //SetWholeBook();
    }

    public void SaveProgress()
    {
        //PlayerPrefs.SetInt("FirstCrack", FirstCrack ? 1 : 0);
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
        //FirstCrack = PlayerPrefs.GetInt("FirstCrack", 0) == 1;
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

    /*public void SetFirstCrack()
    {
        FirstCrack = true;
        SaveProgress();
    }

    public void SetFirstMapPiece(bool value)
    {
        FirstMapPiece = value;
        SaveProgress();
    }*/

    public void SetWholeMap()
    {
        WholeMap = true;
        SaveProgress();
    }

    // Add similar methods for other boolean values as needed
    public void SetEmptyBook()
    {
        EmptyBook = true;
        SaveProgress();
    }

    /*public void SetBookPapers()
    {
        BookPapers = true;
        SaveProgress();
    }*/

    public void SetWholeBook()
    {
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
        KeyIsTaken = true;
        SaveProgress();
    }

    public void SetDoorIsOpened()
    {
        DoorIsOpened = true;
        SaveProgress();
    }

    public void SetCandles()
    {
        Candles = true;
        RitualIsReady = Candles && Mirror && Cross && Chalk;
        SaveProgress();
    }

    public void SetMirror()
    {
        Mirror = true;
        RitualIsReady = Candles && Mirror && Cross && Chalk;
        SaveProgress();
    }

    public void SetCross()
    {
        Cross = true;
        RitualIsReady = Candles && Mirror && Cross && Chalk;
        SaveProgress();
    }

    public void SetChalk()
    {
        Chalk = true;
        RitualIsReady = Candles && Mirror && Cross && Chalk;
        SaveProgress();
    }

    /*public void SetRitualIsReady(bool value)
    {
        RitualIsReady = value;
        SaveProgress();
    }*/
}
