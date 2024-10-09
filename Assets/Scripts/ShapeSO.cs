using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ShapSO",menuName = "ScriptableObject/Shap Data")]
public class ShapeSO : ScriptableObject
{
    public int rows = 5;
    public int columns = 5;
    public Color gridColor = Color.white;
    public List<bool> blockedCells = new List<bool>();

   
    public void InitializeGrid()
    {
        blockedCells.Clear();
        for (int i = 0; i < rows * columns; i++)
        {
            blockedCells.Add(false);
        }
    }
    public bool IsBlocked(int row, int column)
    {
        int index = row * columns + column;
        return blockedCells[index];
    }
    public void SetBlocked(int row, int column, bool value)
    {
        int index = row * columns + column;
        blockedCells[index] = value;
    }
}

