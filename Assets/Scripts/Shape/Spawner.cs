using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : UpgradedMonoBehaviour
{
    public GameObject[] patternPrefabs;
    public List<Pattern> patterns;
    public bool isCreatingContinue;

    private int currentPattern = 0;
    public float spawnYPosition;
    public float deactivePositionY;

    public static Vector2 objectPoolPosition = new Vector2(-100, -150);

    private void Start()
    {
        StartCoroutine(CreateObjectPool());
    }

    void Update()
    {
        if (gameStateController.CurrentState != gameStateController.PlayState) return;
        if (isCreatingContinue) return;
        if (patterns[currentPattern].IsShowing()) return;

        int newPattern;
        do
        {
            newPattern = PickRandomPattern();
            if (newPattern < 0)
                return;
        } while (newPattern == currentPattern);
        currentPattern = newPattern;

        patterns[currentPattern].Reactivate(spawnYPosition);
    }

    private IEnumerator CreateObjectPool()
    {
        isCreatingContinue = true;
        for (int i = 0; i < patternPrefabs.Length; i++)
        {
            patterns.Add(Instantiate(patternPrefabs[i], objectPoolPosition, Quaternion.identity).GetComponent<Pattern>());
            patterns[i].Init(deactivePositionY);
        }
        isCreatingContinue = false;
        yield return null;
    }

    private int PickRandomPattern()
    {
        if (patterns.Count <= 1)
        {
            Debug.LogError("Pattern count not enough to the loop");
            return -1;
        }

        float randomPossibility = Random.Range(0f, Pattern.TotalPossibility);
        float cumulativePossibility = 0f;

        for (int i = 0; i < patterns.Count; i++)
        {
            cumulativePossibility += patterns[i].possibility;
            if (cumulativePossibility > randomPossibility)
                return i;
        }

        Debug.LogError("Patterns cumulative possibilities less than random possibility");
        return -2;
    }
}
