using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCleaner : MonoBehaviour
{
    void Start()
    {
        DestroyAllBadObjects();
    }

    private void DestroyAllBadObjects()
    {
        BadObject[] badObjects = FindObjectsOfType<BadObject>();
        foreach (BadObject badObject in badObjects)
        {
            Destroy(badObject.gameObject);
        }
    }
}
