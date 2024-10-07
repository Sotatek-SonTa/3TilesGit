using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileObj : MonoBehaviour
{
    [Header("Atributter")]
    public Image tileImg;
    public bool isBlank;
    public TileType tileType;
    public int x;
    public int y;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public enum TileType
{
    Apple,
    Banana,
    BlueBerry,
    Coconuit,
    DragonFruit,
    Grape,
    GreenPepper,
    Lemon,
    Melon,
    Orange,
    Peach,
    Pearl,
    Pepper,
    PupGrape,
    Tomato,
}
