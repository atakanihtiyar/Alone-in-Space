using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAbsoluteRandom : MonoBehaviour
{
    public GameObject[] shapesPre;
    public Vector3 offset;
    public float startWait;
    public float spawnWait;
    public float spawnMaxWait;
    public float spawnMinWait;
    private float maxPossibility;

    int randShape;
    public bool isSpawning = false;
    public Coroutine spawnerCo;

    // Start is called before the first frame update
    void Start()
    {
        maxPossibility = 0f;
        for (int i = 0; i < shapesPre.Length; i++)
        {
            maxPossibility += shapesPre[i].GetComponent<Pattern>().possibility;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.currentGameState == GameState.PlayAbsoluteRandom)
        {
            if (isSpawning == false)
            {
                isSpawning = true;
                spawnerCo = StartCoroutine(SpawnerCoFonc());
            }
        }
        else
        {
            if (isSpawning == true)
            {
                isSpawning = false;
                StopCoroutine(spawnerCo);
            }
        }
    }

    private int PickRandomShape()
    {
        float pos = Random.Range(0, maxPossibility);
        float totalPossibility = 0;
        for (int i = 0; i < shapesPre.Length; i++)
        {
            totalPossibility += shapesPre[i].GetComponent<Pattern>().possibility;
            if (totalPossibility > pos)
            {
                return i;
            }
        }

        return -1;
    }

    IEnumerator SpawnerCoFonc()
    {
        yield return new WaitForSeconds(startWait);

        while (GameManager.instance.currentGameState == GameState.PlayAbsoluteRandom)
        {
            randShape = PickRandomShape();
            if (randShape == -1)
            {
                yield break;
            }
            Vector3 spawnPos = new Vector3(Random.Range(-offset.x, offset.x), Random.Range(-offset.y, offset.y), Random.Range(-offset.z, offset.z));
            Instantiate(shapesPre[randShape], spawnPos + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            spawnWait = Random.Range(spawnMinWait, spawnMaxWait);
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
