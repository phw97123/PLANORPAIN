using UnityEngine;

public class PlannerClickEvent : MonoBehaviour
{
    private UI_Planner _uiPlanner;

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
                    if (_uiPlanner == null) _uiPlanner = UIManager.Instance.GetUIComponent<UI_Planner>();
                    _uiPlanner.OpenUI();
                    SoundManager.Instance.Play("MainScene/DiaryEffect");
                }
            }
        }
    }
}
