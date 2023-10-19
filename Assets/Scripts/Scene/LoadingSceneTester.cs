using UnityEngine;

// 로딩씬 테스트용 코드
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
