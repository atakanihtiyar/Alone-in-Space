using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : UpgradedMonoBehaviour
{
    public GameObject[] patternPrefabs;
    public List<Pattern> patterns;
    public bool isCreatingContinue;

    private int currentPattern = 0;

    public static Vector2 objectPoolPosition = new Vector2(-100, -150);

    private void Start()
    {
        StartCoroutine(CreateObjectPool());
    }

    void Update()
    {
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

        patterns[currentPattern].Reactivate();
    }

    private IEnumerator CreateObjectPool()
    {
        isCreatingContinue = true;
        for (int i = 0; i < patternPrefabs.Length; i++)
        {
            patterns.Add(Instantiate(patternPrefabs[i], objectPoolPosition, Quaternion.identity).GetComponent<Pattern>());
        }
        isCreatingContinue = false;
        yield return null;
    }

    private int PickRandomPattern()
    {
        if (patterns.Count <= 1)
        {
            return -1;
        }

        float randomPossibility = Random.Range(0f, Pattern.TotalPossibility);
        float cumulativePossibility = 0f;

        int i;
        for (i = 0; i < patterns.Count; i++)
        {
            cumulativePossibility += patterns[i].possibility;
            if (cumulativePossibility > randomPossibility)
                return i;
        }

        return -2;
    }
}
