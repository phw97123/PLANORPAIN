using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCell : MonoBehaviour
{
    public GameObject DustFloor;
    public GameObject CleanFloor;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Invoke("ChangeCellForPlayer", 0.8f);
        }

        if (collision.gameObject.CompareTag("Cat"))
        {
            Debug.Log("Cat");
            Invoke("ChangeCellForCat", 0.8f);
        }
    }

    private void ChangeCellForPlayer()
    {
        DustFloor.SetActive(false);
        CleanFloor.SetActive(true);

        CleaningGameManager.Instance.IncreaseScore();
    }

    private void ChangeCellForCat()
    {
        DustFloor.SetActive(true);
        CleanFloor.SetActive(false);

        CleaningGameManager.Instance.DecreaseScore();
    }
}
