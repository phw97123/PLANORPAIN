using UnityEngine;

public class UIBase : MonoBehaviour
{
    public virtual void OpenUI()
    {
        gameObject.SetActive(true);
    }

    public virtual void CloseUI()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
