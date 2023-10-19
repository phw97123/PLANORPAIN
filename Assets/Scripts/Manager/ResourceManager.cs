using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : Singleton<ResourceManager>
{
    // Resources/Sprites ���� ���� �̹��� �ҽ����� �����ϴ� ��ųʸ�
    public Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();

    public Sprite LoadSprite(string name)
    {
        if (!sprites.ContainsKey(name))
        {
            // �̹��� �ҽ��� ��û ������ ��ųʸ��� �������� �ʴ´ٸ� Load
            Sprite sprite = Resources.Load<Sprite>($"Sprites/{name}");
            sprites.Add(name, sprite);
        }
        return sprites[name];
    }
}
