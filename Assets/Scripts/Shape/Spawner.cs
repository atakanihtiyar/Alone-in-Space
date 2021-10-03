using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : UpgradedMonoBehaviour
{
    [SerializeField] private Vector2 objectPoolPosition;
    [SerializeField] private GameObject[] patternPrefabs;

    private List<Pattern> patterns;
    private int currentPattern = 0;

    public bool isCreatingContinue;

    private void Start()
    {
        StartCoroutine(CreateObjectPool());
    }

    private void Update()
    {
        if (isCreatingContinue) return;
        if (patterns[currentPattern].IsShowing()) return;

        // Select a new pattern and repeat if this pattern is the same as the previous one.
        // Otherwise, if the same pattern appears, the pattern is repositioned without leaving the screen completely.
        // This is an undesirable situation. 
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
        patterns = new List<Pattern>();
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

        for (int i = 0; i < patterns.Count; i++)
        {
            cumulativePossibility += patterns[i].possibility;
            if (cumulativePossibility > randomPossibility)
                return i;
        }

        return -2;
    }
}
