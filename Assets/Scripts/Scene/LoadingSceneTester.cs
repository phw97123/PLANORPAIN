using UnityEngine;

// �ε��� �׽�Ʈ�� �ڵ�
public class LoadingSceneTester : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManagerEx.Instance.LoadScene(Scenes.LoadingScene, Scenes.DevelopGameScene);
        }
    }
}
