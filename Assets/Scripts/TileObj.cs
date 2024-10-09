using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class TileObj : MonoBehaviour
{
    [Header("Atributter")]
    public Image tileImg;
    public Image background;
   
   
    public TileType tileType;
    public bool isBlocked;
    public int x;
    public int y;
   
    public void SetBlocked()
    {
        isBlocked = true;
        tileImg.enabled = false;
        background.enabled = false;
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
