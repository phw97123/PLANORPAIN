using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    private GameObject _plannerUI;
    void Start()
    {
        _plannerUI = Instantiate(Resources.Load<GameObject>($"Prefabs/Planner/PlannerUI"));
        _plannerUI.SetActive(false);
    }

    public void OpenUI()
    {
        _plannerUI.SetActive(true);
    }
}
