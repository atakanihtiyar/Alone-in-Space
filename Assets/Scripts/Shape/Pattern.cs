using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pattern : UpgradedMonoBehaviour
{
    private Rigidbody2D myRigidbody2D;

    private static float totalPossibility = 0f;
    public static float TotalPossibility { get => totalPossibility; private set => totalPossibility = value; }

    public float possibility;

    [HideInInspector] public List<Shape> deactivatedShapes = new List<Shape>();
    private float maxPosY;
    private float minPosY;

    [SerializeField] private float spawnYPosition;
    [SerializeField] private float deactivePositionY;

    private void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();

        TotalPossibility += possibility;

        minPosY = transform.Cast<Transform>().OrderBy(t => t.localPosition.y).First().localPosition.y;
        maxPosY = transform.Cast<Transform>().OrderBy(t => t.localPosition.y).Last().localPosition.y;

        spawnYPosition = 14;
        deactivePositionY = -13;
    }

    private void Update()
    {
        if (IsShowing())
            myRigidbody2D.velocity = movementManager.GetVelocity();
        else
            myRigidbody2D.velocity = Vector3.zero;
    }

    public bool IsShowing()
    {
        if (transform.position.y + maxPosY < deactivePositionY)
            return false;

        return true;
    }

    public void Reactivate()
    {
        transform.position = new Vector3(0, spawnYPosition - minPosY, 0);

        for (int i = 0; i < deactivatedShapes.Count; i++)
        {
            deactivatedShapes[i].gameObject.SetActive(true);
        }
        deactivatedShapes.Clear();
    }
}
