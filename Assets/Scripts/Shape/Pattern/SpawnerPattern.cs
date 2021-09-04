using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPattern : MonoBehaviour
{
    private bool isFirstTime = true;

    public GameObject[] shapePrefabs; //prefabs
    private GameObject[] shapes; //spawned objects
    
    [HideInInspector] public float pureTotalPossibility = 0f; //total of all pattern possibilities 

    private int currentPattern = 0; //current active pattern
    private int lastPattern = 0; //current active pattern
    public float spawnYPosition; //spawning pos y //pos x = 0
    public float deactivePositionY; // where active pattern to deactive pattern

    public static Vector2 objectPoolPosition = new Vector2(-100, -150); //position of shapes which unshown

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.currentGameState == GameState.PlayPattern)
        {
            if (isFirstTime)
            {
                shapes = new GameObject[shapePrefabs.Length];

                //create one each pattern
                for (int i = 0; i < shapes.Length; i++)
                {
                    shapes[i] = (GameObject)Instantiate(shapePrefabs[i], objectPoolPosition, Quaternion.identity);
                    pureTotalPossibility += shapes[i].GetComponent<Pattern>().possibility;
                }
                currentPattern = PickPattern();
                //shapes[currentPattern].GetComponent<Pattern>().isShow = true;
                isFirstTime = false;
            }
            else
            {
                Pattern cPattern = shapes[currentPattern].GetComponent<Pattern>();
                //current pattern out of the camera
                if (shapes[currentPattern].transform.position.y + cPattern.maxPosY < deactivePositionY)
                {
                    //set last pattern and new current pattern
                    shapes[lastPattern].GetComponent<Pattern>().isShow = false;
                    lastPattern = currentPattern;
                    do
                    {
                        currentPattern = PickPattern();
                    } while (lastPattern == currentPattern);

                    //set current pattern possition
                    shapes[currentPattern].transform.position = new Vector3(0, spawnYPosition - cPattern.minPosY, 0);
                    shapes[currentPattern].GetComponent<Pattern>().ReActivateObjects();
                    shapes[currentPattern].GetComponent<Pattern>().isShow = true;
                }
            }
        }     
    }

    private int PickPattern()
    {
        if (shapes.Length > 1)
        {
            //set random possibility
            float currentRandomPossibility = Random.Range(0f, pureTotalPossibility);
            //cumulative pattern possibility
            float cumulativePossibility = 0f;
            //finding which pattern
            for (int i = 0; i < shapes.Length; i++)
            {
                Pattern pattern = shapes[i].GetComponent<Pattern>();
                cumulativePossibility += pattern.possibility;
                if (cumulativePossibility > currentRandomPossibility)
                {
                    return i;
                }
            }
        }
        else
        {
            Debug.LogError("Not enough pattern");
        }

        return 0;
    }
}
