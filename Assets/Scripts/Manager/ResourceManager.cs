using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
            var obj = Instantiate(Resources.Load($"Sprites/{name}"));
            sprites.Add(name, obj.GetComponent<Sprite>());
        }
        return sprites[name];
    }
}
