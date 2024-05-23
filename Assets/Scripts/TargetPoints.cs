using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPoints : MonoBehaviour
{
    public List<Transform> targetPoints = new List<Transform>();
    public List<Transform> GetTargetPoints()
    {
        return targetPoints;
    }
}
