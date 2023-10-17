using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ChangeCell : MonoBehaviour
{
    public GameObject DustFloor;
    public GameObject CleanFloor;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ChangeCellCoroutine(DustFloor, CleanFloor,1));
        }

        if (collision.gameObject.CompareTag("Cat"))
        {
            StartCoroutine(ChangeCellCoroutine(CleanFloor, DustFloor,-1));
        }
    }

    private IEnumerator ChangeCellCoroutine(GameObject fromCell, GameObject toCell, int amount)
    {
        yield return new WaitForSeconds(0.3f);

        if (fromCell.activeSelf)
        {
            fromCell.SetActive(false);
            toCell.SetActive(true);

            CleaningGameManager.Instance.ChangeScore(amount);
        }
    }
}
