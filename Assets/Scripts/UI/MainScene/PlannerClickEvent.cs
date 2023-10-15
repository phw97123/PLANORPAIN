using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlannerClickEvent : MonoBehaviour
{
    // 추후 UI Manager에게 요청하는 방식으로 리팩토링 예정
    [SerializeField] private GameObject _plannerUI;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == gameObject.name)
                {
                    _plannerUI.SetActive(true);
                }
            }
        }
    }
}
