using System.Collections;
using System.Collections.Generic;
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

    void Update()
    {

    }

    private void CreateGrid()
    {
        nodes = new Node[width, height];
        var name = 0; 

        for(int i = 0; i<width; i++)
        {
            for(int j = 0;j<height; j++)
            {
                Vector3 worldPostion = new Vector3(i, 0, j); 
                Transform obj = Instantiate(gridCellPrefab, worldPostion*2, Quaternion.identity);
                obj.name = "Cell" + name;
                nodes[i,j] = new Node(true, worldPostion, obj);
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

