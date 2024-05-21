using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleDoor : MonoBehaviour
{
    public List<Column> columns = new List<Column>();
    public List<float> angles = new List<float>();
    private Dictionary<Column, float> columnAngles = new Dictionary<Column, float>();

    void Update()
    {
        bool allColumnsCorrect = true;

        foreach (var pair in columnAngles)
        {
            Column column = pair.Key;
            float targetAngle = pair.Value;

            if (!IsColumnAtCorrectAngle(column, targetAngle))
            {
                allColumnsCorrect = false;
                break;
            }
        }

        if (allColumnsCorrect)
        {
            FindObjectOfType<PlayerProgress>().SetStatuesRiddle(true);
            gameObject.SetActive(false);
        }
    }

    bool IsColumnAtCorrectAngle(Column column, float targetAngle)
    {
        float angleThreshold = 1f;

        return Mathf.Abs(column.transform.eulerAngles.z - targetAngle) < angleThreshold;
    }
}
