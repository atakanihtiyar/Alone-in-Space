using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pattern : MonoBehaviour
{
    private static float totalPossibility = 0f;
    public static float TotalPossibility { get => totalPossibility; private set => totalPossibility = value; }

    private Rigidbody2D myRigidbody2D;
    public float possibility;

    public List<Shape> deactivatedShapes = new List<Shape>();
    public float maxPosY;
    public float minPosY;
    private float _deactivePositionY;

    public void Init(float deactivePositionY)
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();

        TotalPossibility += possibility;
        //Debug.Log(TotalPossibility);

        minPosY = transform.Cast<Transform>().OrderBy(t => t.localPosition.y).First().localPosition.y;
        maxPosY = transform.Cast<Transform>().OrderBy(t => t.localPosition.y).Last().localPosition.y;

        _deactivePositionY = deactivePositionY;
    }

    void Update()
    {
        if (IsShowing())
            myRigidbody2D.velocity = MovementManager.Instance.GetVelocity();
        else
            myRigidbody2D.velocity = Vector3.zero;
    }

    public bool IsShowing()
    {
        if (transform.position.y + maxPosY < _deactivePositionY)
            return false;

        return true;
    }

    public void Reactivate(float spawnYPosition)
    {
        transform.position = new Vector3(0, spawnYPosition - minPosY, 0);

        for (int i = 0; i < deactivatedShapes.Count; i++)
        {
            deactivatedShapes[i].gameObject.SetActive(true);
            deactivatedShapes[i].ReactivateShape();
        }
        deactivatedShapes.Clear();
    }
}
