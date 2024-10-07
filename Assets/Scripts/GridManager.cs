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
    [Header("List")]
    public List<TileObj> listTiles;
    public List<TileObj> tileObjsTiles;
    public List<Sprite> contentImg;
    public List<Sprite> blockContentImg;
    private void Start()
    {
        loadLevelData();
        LoadBLockImg();
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
}
