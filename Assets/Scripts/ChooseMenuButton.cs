using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseMenuButton : MonoBehaviour
{
    public int targetSceneIndex;
    public void Teleport(int targetTeleportPointIndex)
    {
        InteractiveMode playerUI = GetComponentInParent<InteractiveMode>();
        //InteractiveMode playerUI = GetComponent<InteractiveMode>();
        playerUI.PlayerControlFreeze();
        playerUI.DisableChooseMenuUI();
        TeleportManager.Instance.TeleportPlayer(targetSceneIndex, targetTeleportPointIndex);
    }
}
