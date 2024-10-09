using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class LevelManager : MonoBehaviour
{
    public LevelData currentLevel;
    public TileObj item;
    public GameObject grid;
    private Dictionary<TileType, string> tileTypeSpriteNameMap;
    [SerializeField] private SpriteAtlas spriteAtlas;
    [SerializeField] Transform content;
    private void Start()
    {
        InitalizeTileType();
    }
    public void CreateGrid()
    {
        for(int k = 0; k < currentLevel.grids.Count; k++)
        {
            currentLevel.grids[k].matrix = new GameObject[currentLevel.grids[k].rows, currentLevel.grids[k].cols];
            GameObject gridSpawn = Instantiate(grid, content);
            for (int i = 0; i < currentLevel.grids[k].rows; i++)
            {
                for(int j = 0; j < currentLevel.grids[k].cols; j++)
                {
                    TileObj tileObj = Instantiate(item,gridSpawn.transform);
                    currentLevel.grids[k].matrix[i, j] = tileObj.gameObject;
                    if (!currentLevel.grids[k].shapeSO.IsBlocked(i, j))
                    {
                        AssignType(tileObj,currentLevel);
                    }
                    else
                    {
                        tileObj.SetBlocked();
                    }
                }
            }
        }
    }
    public void AssignType(TileObj tile, LevelData levelData)
    {
        TileType tileType = levelData.spawnableTileType[Random.Range(0, levelData.spawnableTileType.Length)];
        string spriteName;
        if (tileTypeSpriteNameMap.TryGetValue(tileType, out spriteName))
        {
            Sprite tileSprite = spriteAtlas.GetSprite(spriteName);
            tile.tileImg.sprite = tileSprite;
        }
    }
    private void InitalizeTileType()
    {
        tileTypeSpriteNameMap = new Dictionary<TileType, string>
        {
            {TileType.Apple,"Apple"},
            {TileType.Banana,"Banana"},
            {TileType.BlueBerry,"BlueBerry" },
            {TileType.Coconuit,"Coconut"},
            {TileType.DragonFruit,"DragonFruit"},
            {TileType.Grape,"Grape" },
            {TileType.GreenPepper,"GreenPepper" },
            {TileType.Lemon,"Lemon" },
            {TileType.Melon,"Melon" },
            {TileType.Orange,"Orange" },
            {TileType.Peach,"Peach" },
            {TileType.Pearl,"Pearl" },
            {TileType.Pepper,"Pepper" },
            {TileType.PupGrape,"PupGrape" },
            {TileType.Tomato,"Tomato" },
        };
    }
}
