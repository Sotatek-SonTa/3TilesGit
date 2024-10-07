using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpriteSO", menuName = "ScriptableObject/SpriteSO", order = 0)]
public class SpriteSO : ScriptableObject
{
    public List<Sprite> sprites = new List<Sprite>();
}
