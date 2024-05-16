using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    public bool FirstCrack = false;
    public bool FirstMapPiece = false;
    public bool WholeMap = false;
    public bool EmptyBook = false;
    public bool BookPapers = false;
    public bool WholeBook = false;
    public bool StatuesRiddle = false;
    public bool KeyIsTaken = false;
    public bool DoorIsOpened = false;
    public bool Candles = false;
    public bool Mirror = false;
    public bool Cross = false;
    public bool Chalk = false;
    public bool RitualIsReady = false;

    private void Start()
    {
        LoadProgress();
    }

    public void SaveProgress()
    {
        PlayerPrefs.SetInt("FirstCrack", FirstCrack ? 1 : 0);
        PlayerPrefs.SetInt("FirstMapPiece", FirstMapPiece ? 1 : 0);
        PlayerPrefs.SetInt("WholeMap", WholeMap ? 1 : 0);
        PlayerPrefs.SetInt("EmptyBook", EmptyBook ? 1 : 0);
        PlayerPrefs.SetInt("BookPapers", BookPapers ? 1 : 0);
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
        FirstMapPiece = PlayerPrefs.GetInt("FirstMapPiece", 0) == 1;
        WholeMap = PlayerPrefs.GetInt("WholeMap", 0) == 1;
        EmptyBook = PlayerPrefs.GetInt("EmptyBook", 0) == 1;
        BookPapers = PlayerPrefs.GetInt("BookPapers", 0) == 1;
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

    public void SetFirstCrack(bool value)
    {
        FirstCrack = value;
        SaveProgress();
    }

    public void SetFirstMapPiece(bool value)
    {
        FirstMapPiece = value;
        SaveProgress();
    }

    public void SetWholeMap(bool value)
    {
        WholeMap = value;
        SaveProgress();
    }

    // Add similar methods for other boolean values as needed
    public void SetEmptyBook(bool value)
    {
        EmptyBook = value;
        SaveProgress();
    }

    public void SetBookPapers(bool value)
    {
        BookPapers = value;
        SaveProgress();
    }

    public void SetWholeBook(bool value)
    {
        WholeBook = value;
        SaveProgress();
    }

    public void SetStatuesRiddle(bool value)
    {
        StatuesRiddle = value;
        SaveProgress();
    }

    public void SetKeyIsTaken(bool value)
    {
        KeyIsTaken = value;
        SaveProgress();
    }

    public void SetDoorIsOpened(bool value)
    {
        DoorIsOpened = value;
        SaveProgress();
    }

    public void SetCandles(bool value)
    {
        Candles = value;
        SaveProgress();
    }

    public void SetMirror(bool value)
    {
        Mirror = value;
        SaveProgress();
    }

    public void SetCross(bool value)
    {
        Cross = value;
        SaveProgress();
    }

    public void SetChalk(bool value)
    {
        Chalk = value;
        SaveProgress();
    }

    public void SetRitualIsReady(bool value)
    {
        RitualIsReady = value;
        SaveProgress();
    }
}
