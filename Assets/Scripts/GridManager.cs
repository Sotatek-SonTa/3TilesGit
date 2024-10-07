using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public TileObj tileObjPrefab;
    public LevelData levelData;
    public int width = 9;
    public int height = 4;
    public int imgCount = 3;
    public SpriteSO sprites;
    public GridLayoutGroup parentGroup;
    public Transform Content;
    [Header("List")]
    public List<TileObj> listTiles;
    public List<TileObj> tileObjsTiles;
    public List<Sprite> contentImg;
    public List<Sprite> tilesContentImg;
    private void Start()
    {
        loadLevelData();
        LoadBLockImg();
        InitGridSystem();
        CreatListImg();
        SpawnTtleObject();
        SetImgTileSpawn();
    }
    void Update()
    {
        
    }
    public void loadLevelData()
    {
        width = levelData.width;
        height = levelData.height;
        imgCount = levelData.fruitCount;
    }
    public void LoadBLockImg()
    {
        foreach(var item in sprites.sprites)
        {
            contentImg.Add(item);
        }
    }
    public List<TileObj> tileActive = new();
    public void CreatListImg()
    {
        int fruitCount = 0;
        Sprite img = ImgSelected();
        for(int i = 0; i < tileActive.Count; i++)
        {
            fruitCount++;
            tilesContentImg.Add(img);
            if (fruitCount == imgCount)
            {
                img = ImgSelected();
                fruitCount = 0;
            }
        }

    }
    public Sprite ImgSelected()
    {
        int index = Random.Range(0, contentImg.Count - 1);
        Sprite img = contentImg[index];
        contentImg.RemoveAt(index);
        return img;
    }
    public void InitGridSystem()
    {
        if (this.listTiles.Count > 0) return;


        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width ; x++)
            {
                TileObj tileObj = new TileObj()
                {
                    x = x,
                    y = y,
                };
                listTiles.Add(tileObj);
            }
        }
    }
    public void SpawnTtleObject()
    {
        int index = Random.Range(0, contentImg.Count);
        foreach(TileObj tile in listTiles)
        {
            TileObj tileObj;
            parentGroup.constraintCount = width;
            tileObj = Instantiate(tileObjPrefab, Content);
            tileObj.x = tile.x;
            tileObj.y = tile.y;
            tileObjsTiles.Add(tileObj);
        }
    }
    public void SetImgTileSpawn()
    {
        foreach(TileObj tile in tileObjsTiles)
        {
            Sprite img = SetImg();
            tile.SetData(img);
        }
    }
    public Sprite SetImg()
    {
        int index = Random.Range(0, contentImg.Count - 1);
        Sprite img = contentImg[index];
        contentImg.RemoveAt(index);
        return img;
    }
}
