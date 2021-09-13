using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Pattern of shape collections 
/// </summary>
public class Pattern : UpgradedMonoBehaviour
{
    private Rigidbody2D myRigidbody2D;

    private static float totalPossibility = 0f;
    /// <summary>
    /// Sum of all pattern possibilities
    /// </summary>
    public static float TotalPossibility { get => totalPossibility; private set => totalPossibility = value; }
    /// <summary>
    /// Possibility of pattern
    /// </summary>
    public float possibility;

    /// <summary>
    /// Deactive shapes in the pattern
    /// </summary>
    [HideInInspector] public List<Shape> deactivatedShapes = new List<Shape>();
    private float maxPosY;
    private float minPosY;

    [SerializeField] private float spawnYPosition;
    [SerializeField] private float deactivePositionY;

    private void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();

        TotalPossibility += possibility;

        // Assigns the minimum and maximum y values of the children 
        minPosY = transform.Cast<Transform>().OrderBy(t => t.localPosition.y).First().localPosition.y;
        maxPosY = transform.Cast<Transform>().OrderBy(t => t.localPosition.y).Last().localPosition.y;
    }

    private void Update()
    {
        if (IsShowing())
            myRigidbody2D.velocity = movementManager.GetVelocity();
        else
            myRigidbody2D.velocity = Vector3.zero;
    }

    /// <summary>
    /// Visibility of the pattern
    /// </summary>
    /// <returns>Returns the "Is within camera bounds"</returns>
    public bool IsShowing()
    {
        if (transform.position.y + maxPosY < deactivePositionY)
            return false;

        return true;
    }

    /// <summary>
    /// Activates deactivated shapes
    /// </summary>
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
