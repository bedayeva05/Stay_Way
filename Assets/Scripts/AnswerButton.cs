using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnswerButton : MonoBehaviour
{
    public UnityEvent action;
    public void MustDo()
    {
        Debug.Log(33333);
        action?.Invoke();
        Debug.Log(4444444);
    }
    /*private void Update()
    {
        UpdatePressButton();
    }
    private void UpdatePressButton()
    {
        if (!_playerIsNearby) return;
        if (!Input.GetKeyDown(ButtonToPress)) return;
        action?.Invoke();
    }*/
   
    
}
