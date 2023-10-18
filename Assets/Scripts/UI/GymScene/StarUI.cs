using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarUI : MonoBehaviour
{
    public IntVariable starAmount;

    [SerializeField] private GameObject[] _filledStars;

    private void Update()
    {
        for (int i = 0; i < _filledStars.Length; i++)
        {
            if (i < starAmount.value)
                _filledStars[i].SetActive(true);
            else
                _filledStars[i].SetActive(false);
        }
    }
}
