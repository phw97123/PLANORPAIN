using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCell : MonoBehaviour
{
    public GameObject DustFloor;
    public GameObject CleanFloor;

    private void OnCollisionEnter(Collision collision)
    {
        Invoke("Change", 1.0f); 
    }

    private void Change()
    {
        DustFloor.SetActive(false);
        CleanFloor.SetActive(true);

        CleaningGameManager.Instance.IncreaseScore(); 
    } 
}
