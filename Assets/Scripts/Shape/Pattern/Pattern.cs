using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;
    public float possibility;

    [Header("For Pattern")]
    public List<GameObject> deactivatedShapes = new List<GameObject>();
    public bool isShow;
    [HideInInspector] public float maxPosY;
    [HideInInspector] public float minPosY;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();

        //finding currentPattern's size y
        maxPosY = transform.GetChild(0).localPosition.y;
        minPosY = transform.GetChild(0).localPosition.y;


        for (int i = 0; i < transform.childCount; i++)
        {
            Transform childTransform = transform.GetChild(i);
            if (maxPosY < childTransform.localPosition.y)
                maxPosY = childTransform.localPosition.y;
            if (minPosY > childTransform.localPosition.y)
                minPosY = childTransform.localPosition.y;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isShow)
            myRigidbody2D.velocity = GameStateController.Instance.Velocity;
        else
            myRigidbody2D.velocity = Vector3.zero;
    }

    public void ReActivateObjects()
    {
        for (int i = 0; i < deactivatedShapes.Count; i++)
        {
            deactivatedShapes[i].SetActive(true);
            deactivatedShapes[i].GetComponent<Shape>().ReactivateShape();
        }
        deactivatedShapes.Clear();
    }
}
