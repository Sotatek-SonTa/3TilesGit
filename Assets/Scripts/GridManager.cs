using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public TileObj item;
    public int rows = 6, cols = 6;
    private GameObject[,] matrix;
    public Transform gridHolder;



   [Header("LevelData")]
    public LevelData levelData;
    [Header("TileData")]
    [SerializeField]private SpriteAtlas spriteAtlas;
    private Dictionary<TileType, string> tileTypeSpriteNameMap;
    void Start()
    {
        InitalizeTileType();
        rows = levelData.rows;
        cols = levelData.columns;
        matrix = new GameObject[rows, cols];

        List<Vector2Int> emptyPositions = new List<Vector2Int>();
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                emptyPositions.Add(new Vector2Int(i, j));
                //TileObj tile = Instantiate(item, transform); 
                //matrix[i, j] = tile.gameObject;
                //AssignTileType(tile);
            }
        }
    
        while (emptyPositions.Count >= 3)
        {
           
            TileType tileType = levelData.spawnableTileType[Random.Range(0, levelData.spawnableTileType.Length)];

         
            List<TileObj> tileGroup = new List<TileObj>();
            for (int k = 0; k < 3; k++)
            {
                TileObj tile = Instantiate(item, gridHolder); 
                AssignTileType(tile, tileType); 
                tileGroup.Add(tile); 
            }

            for (int k = 0; k < 3; k++)
            {
               
                int randomIndex = Random.Range(0, emptyPositions.Count);
                Vector2Int position = emptyPositions[randomIndex];
                emptyPositions.RemoveAt(randomIndex); 

            
                TileObj tile = tileGroup[k];
                matrix[position.x, position.y] = tile.gameObject;
                tile.transform.position = new Vector3(position.x, position.y, 0);
            }
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
    private void AssignTileType(TileObj tile,TileType tileType)
    {
        tile.tileType = tileType;
        string spriteName;
        if(tileTypeSpriteNameMap.TryGetValue(tileType,out spriteName))
        {
            Sprite tileSprite = spriteAtlas.GetSprite(spriteName);
            tile.tileImg.sprite = tileSprite;
        }
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
