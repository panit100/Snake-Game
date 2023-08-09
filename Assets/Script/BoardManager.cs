using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance { get; private set;}

    public int width;
    public int height;

    public GameObject gridPrefab;
    public GameObject boarderPrefab;

    public Color gridColor1;
    public Color gridColor2;

    private void Awake() 
    {
        Instance = this;    
    }

    void Start()
    {   
        CrateBoard();
        CraeteBoarder();
    }

    void CrateBoard()
    {
        Color gridColor = gridColor1;

        for(int i = 0; i < width; i++)
        {
            for(int j = 0;j<height; j++)
            {
                if(gridColor == gridColor2)
                    gridColor = gridColor1;
                else
                    gridColor = gridColor2;

                var position = new Vector2(i, j);
                
                GameObject grid = Instantiate(gridPrefab, position, Quaternion.identity);
                grid.GetComponent<SpriteRenderer>().color = gridColor;;
                grid.transform.parent = this.transform;;
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
}
