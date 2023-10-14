using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class testbtn : MonoBehaviour
{
    public void click()
    {
        GameProgressManager.Instance.LoadPlannerScene();
    }
}