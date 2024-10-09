using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Grid", menuName = "ScriptableObject/Grid", order = 1)]
public class Grid : ScriptableObject
{
    [SerializeField] public int rows;
    [SerializeField] public int cols;
    [SerializeField] public ShapeSO shapeSO;
    [SerializeField] public GameObject[,] matrix;
    
}
