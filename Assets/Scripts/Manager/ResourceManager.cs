using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResourceManager : Singleton<ResourceManager>
{
    public Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();

    public Sprite LoadSprite(string name)
    {
        if (!sprites.ContainsKey(name))
        {
            var obj = Instantiate(Resources.Load($"Prefabs/Sprites/{name}"));
            sprites.Add(name, obj.GetComponent<Sprite>());
        }
        return sprites[name];
    }
}
