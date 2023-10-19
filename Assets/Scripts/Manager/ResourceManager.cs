using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : Singleton<ResourceManager>
{
    // Resources/Sprites 폴더 안의 이미지 소스들을 저장하는 딕셔너리
    public Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();

    public Sprite LoadSprite(string name)
    {
        if (!sprites.ContainsKey(name))
        {
            // 이미지 소스가 요청 시점에 딕셔너리에 존재하지 않는다면 Load
            Sprite sprite = Resources.Load<Sprite>($"Sprites/{name}");
            sprites.Add(name, sprite);
        }
        return sprites[name];
    }
}
