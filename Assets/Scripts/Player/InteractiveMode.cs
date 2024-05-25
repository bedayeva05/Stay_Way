using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveMode : MonoBehaviour
{
    public GameObject chooseMenuUI;

    public GameObject itemGetUI;
    public GameObject taskUI;
    public GameObject toolUI;


    public GameObject crossUI;
    public GameObject bookUI;
    public GameObject sheetsUI;
    public GameObject candlesUI;
    public GameObject chalkUI;
    public GameObject mirrorUI;
    public GameObject keyUI;
    public GameObject mapUI;
    public void PlayerControlFreeze()
    {
        toolUI.SetActive(!toolUI.activeSelf);
        taskUI.SetActive(!taskUI.activeSelf);
        GetComponent<PlayerController>().enabled = !GetComponent<PlayerController>().enabled;
        GetComponent<CameraRotation>().enabled = !GetComponent<CameraRotation>().enabled;
    }
    public void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void CrossCollected()
    {
        ItemGetUI();
        crossUI.SetActive(true);
    }
    public void BookCollected()
    {
        ItemGetUI();
        bookUI.SetActive(true);
    }
    public void SheetsCollected()
    {
        ItemGetUI();
        sheetsUI.SetActive(true);
    }
    public void CandlesCollected()
    {
        ItemGetUI();
        candlesUI.SetActive(true);
    }
    public void ChalkCollected()
    {
        ItemGetUI();
        chalkUI.SetActive(true);
    }
    public void MirrorCollected()
    {
        ItemGetUI();
        mirrorUI.SetActive(true);
    }
    public void KeyCollected()
    {
        ItemGetUI();
        keyUI.SetActive(true);
    }
    public void MapCollected()
    {
        ItemGetUI();
        mapUI.SetActive(true);
    }
    public void ItemGetUI()
    {
        PlayerControlFreeze();
        itemGetUI.SetActive(true);
        crossUI.SetActive(false);
        bookUI.SetActive(false);
        sheetsUI.SetActive(false);
        candlesUI.SetActive(false);
        chalkUI.SetActive(false);
        mirrorUI.SetActive(false);
        keyUI.SetActive(false);
        mapUI.SetActive(false);
}
    public void EnableChooseMenuUI()
    {
        chooseMenuUI.SetActive(true);
    }
    public void DisableChooseMenuUI()
    {
        chooseMenuUI.SetActive(false);
    }
}
