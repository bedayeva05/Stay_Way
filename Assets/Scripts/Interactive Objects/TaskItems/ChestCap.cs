using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestCap : MonoBehaviour
{
    public void OpenChest()
    {
        gameObject.transform.rotation = Quaternion.Euler(-180f, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
        //gameObject.transform.eulerAngles = new Vector3(-180f, 0f, 0f);

    }
}
