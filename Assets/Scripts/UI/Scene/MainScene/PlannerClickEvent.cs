using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlannerClickEvent : MonoBehaviour
{
    // ���� UI Manager���� ��û�ϴ� ������� �����丵 ����
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
