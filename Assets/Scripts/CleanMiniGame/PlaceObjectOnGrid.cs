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
    private Node[,] nodes;

    void Start()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        nodes = new Node[width, height];
        var name = 0;
        Vector3 cellSize = gridCellPrefab.transform.localScale; 

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector3 worldPosition = new Vector3(i *cellSize.x*2f, 0, j*cellSize.z * 2f);
                Transform obj = Instantiate(gridCellPrefab, worldPosition*2, Quaternion.identity);

                obj.name = "Cell" + name;
                nodes[i, j] = new Node(true, worldPosition, obj);
                name++;
            }
        }
    }
}

public class Node
{
    public bool isPlaceable;
    public Vector3 cellPosition;
    public Transform obj;

    public Node(bool isPlaceable, Vector3 cellPosition, Transform obj)
    {
        this.isPlaceable = isPlaceable;
        this.cellPosition = cellPosition;
        this.obj = obj;
    }
}

