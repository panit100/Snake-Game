using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance { get; private set;}

    public int width = 0;
    public int height = 0;

    public GameObject gridPrefab;
    public GameObject boarderPrefab;

    public Color gridColor1;
    public Color gridColor2;

    public GameObject[,] grids;
    public List<GameObject> notEmptyGridList = new List<GameObject>();

    private void Awake() 
    {
        Instance = this;    
    }

    void Start()
    {   
        grids = new GameObject[width,height];

        CrateBoard();
        CraeteBoarder();
    }

    void CrateBoard()
    {
        Color gridColor = gridColor1;

        for(int i = 0; i < grids.GetLength(0); i++)
        {
            for(int j = 0;j < grids.GetLength(1); j++)
            {
                if(gridColor == gridColor2)
                    gridColor = gridColor1;
                else
                    gridColor = gridColor2;

                var position = new Vector2(i, j);
                
                GameObject grid = Instantiate(gridPrefab, position, Quaternion.identity);
                grid.GetComponent<SpriteRenderer>().color = gridColor;;
                grid.transform.parent = this.transform;;

                grids[i,j] = grid;
            }
        }
    }

    void CraeteBoarder()
    {
        Vector2 position;
        GameObject boarder;

        for(int i = 0; i < width;i++)
        {
            position = new Vector2(i, -1);
            boarder = Instantiate(boarderPrefab, position, Quaternion.identity);
            boarder.transform.parent = this.transform;;

            position = new Vector2(i, height);
            boarder = Instantiate(boarderPrefab, position, Quaternion.identity);
            boarder.transform.parent = this.transform;;
        }

        for(int j = 0; j < height;j++)
        {
            position = new Vector2(-1, j);
            boarder = Instantiate(boarderPrefab, position, Quaternion.identity);
            boarder.transform.parent = this.transform;;

            position = new Vector2(width, j);
            boarder = Instantiate(boarderPrefab, position, Quaternion.identity);
            boarder.transform.parent = this.transform;;
        }
    }

    public void AddEmptyGrid(int x,int y)
    {
        if(!notEmptyGridList.Find(n => n == grids[x,y]))
            notEmptyGridList.Add(grids[x,y]);
    }

    public void RemoveEmptyGrid(int x,int y)
    {
        if(notEmptyGridList.Find(n => n == grids[x,y]))
            notEmptyGridList.Remove(grids[x,y]);
    }
}
