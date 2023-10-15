using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlaceObjectOnGrid : MonoBehaviour
{
    public Transform gridCellPrefab;
    public Transform cube;

    [SerializeField] private int height;
    [SerializeField] private int width;


    void Start()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        var name = 0;
        Vector3 cellSize = gridCellPrefab.transform.localScale;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector3 worldPosition = new Vector3(i * cellSize.x * 2f, 0, j * cellSize.z * 2f);
                Transform obj = Instantiate(gridCellPrefab, worldPosition * 2, Quaternion.identity);

                obj.name = "Cell" + name;
                name++;
            }
        }
    }
}

