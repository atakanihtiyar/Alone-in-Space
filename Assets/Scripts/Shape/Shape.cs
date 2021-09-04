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
    private GameManager gameManager;

    public ShapeType myShapeType;

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    void Update()
    {

    }

    public void ReactivateShape()
    {

    }
}
