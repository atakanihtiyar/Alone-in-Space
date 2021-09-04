using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AiS/Theme")]
[SerializeField]
public class Theme : ScriptableObject
{
    public string description;
    public int cost;
    public bool buyed;

    [Header("None")]
    public Sprite none;

    [Header("General")]
    public Sprite background;
    public Sprite ship;

    [Header("Shapes")]
    public Sprite armored;
    public Sprite doubleScore;
    public Sprite score;
}
