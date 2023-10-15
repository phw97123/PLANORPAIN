using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCell : MonoBehaviour
{
    public GameObject DustFloor;
    public GameObject CleanFloor;

    private void OnCollisionEnter(Collision collision)
    {
        DustFloor.SetActive(false);
        CleanFloor.SetActive(true);
    }
}
