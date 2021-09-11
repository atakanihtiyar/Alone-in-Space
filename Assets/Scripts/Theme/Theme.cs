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
    
    public List<ThemePart> themeParts;

    public ThemePart GetThemePart(string key)
    {
        return themeParts.Find(x => x.name.Equals(key));
    }
}
