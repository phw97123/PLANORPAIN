using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject plannerUI;
    // Start is called before the first frame update
    void Start()
    {
        plannerUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnLoadBtnClick()
    {
        SceneManager.LoadScene("YCYTestScene");
    }
}
