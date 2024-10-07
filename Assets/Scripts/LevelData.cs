using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObject/LevelData", order = 1)]
public class LevelData : ScriptableObject
{
    public int level;
    public int rows;
    public int columns;
    public int fruitCount;
    public TileType[] spawnableTileType;
}
