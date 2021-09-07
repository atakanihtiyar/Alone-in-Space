using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShapeType
{
    none,
    armored,
    doubleScore,
    score
};

public class Shape : MonoBehaviour
{
    public ShapeType myShapeType;

    public void ReactivateShape()
    {

    }
}
