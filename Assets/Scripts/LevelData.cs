using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObject/LevelData", order = 1)]
public class LevelData : ScriptableObject
{
    public int level;
    public int width;
    public int height;
    public int fruitCount;
}
