using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public LevelManager levelManager;
    void Start()
    {
       levelManager.CreateGrid();
    }
    void Update()
    {
        
    }
}
