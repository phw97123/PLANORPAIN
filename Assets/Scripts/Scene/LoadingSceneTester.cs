using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingSceneTester : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManagerEx.Instance.LoadScene(Scenes.LoadingScene, Scenes.CreateDevelopGameScene_kjm);
        }
    }
}
