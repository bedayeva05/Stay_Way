using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleDoor : MonoBehaviour
{
    public List<Vector3> positions = new List<Vector3>();
    public List<GameObject> gameObjects = new List<GameObject>();
    private Dictionary<Vector3, GameObject> positionGameObjectMap = new Dictionary<Vector3, GameObject>();

    void Start()
    {
        for (int i = 0; i < positions.Count; i++)
        {
            positionGameObjectMap.Add(positions[i], gameObjects[i]);
        }
    }

    private bool CheckAllPositions()
    {
        bool allPositionsCorrect = true;

        foreach (Vector3 position in positions)
        {
            if (positionGameObjectMap.ContainsKey(position))
            {
                GameObject gameObjectAtPosition = positionGameObjectMap[position];
                if (gameObjectAtPosition.transform.position != position)
                {
                    allPositionsCorrect = false;
                    break;
                }
            }
        }

        return allPositionsCorrect;
    }

    public void RiddleIsSolved()
    {
        if(CheckAllPositions())
        {
            gameObject.SetActive(false);
        }
    }
}
