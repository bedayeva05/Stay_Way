using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleDoor : MonoBehaviour
{
    [System.Serializable]
    public class Column
    {
        public Transform columnTransform;
        public float correctAngle;
    }
    public Column[] columns;
    public float angleTolerance = 1.0f; // Tolerance for angle comparison

    void Update()
    {
        if (CheckAllColumns())
        {
            PlayerProgress playerProgress = FindObjectOfType<PlayerProgress>();
            playerProgress.SetStatuesRiddle();
            gameObject.SetActive(false);
        }
    }

    bool CheckAllColumns()
    {
        foreach (Column col in columns)
        {
            float currentAngle = col.columnTransform.localEulerAngles.y;
            float deltaAngle = Mathf.DeltaAngle(currentAngle, col.correctAngle);

            //Debug.Log($"Column: {col.columnTransform.name}, Current Angle: {currentAngle}, Correct Angle: {col.correctAngle}, Delta Angle: {deltaAngle}");

            if (Mathf.Abs(deltaAngle) > angleTolerance)
            {
                return false;
            }
        }
        return true;
    }

}
