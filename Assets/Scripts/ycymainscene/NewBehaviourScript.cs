using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    void Start()
    {
        Instantiate(Resources.Load<GameObject>($"Prefabs/Planner/PlannerUI"));
    }
}
