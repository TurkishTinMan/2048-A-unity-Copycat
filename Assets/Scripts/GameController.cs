using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Vector2 startPos;
    public Vector2 direction;
    private GameObject[,] mainMatrix = new GameObject[4, 4];
    public GameObject mainGrid;
    public GameObject barGrid;
    public GameObject newCell;
    public GameObject restartPanel;


    float IndexInCoordinate(int index)
    {
        switch (index)
        {
            case 0:
                return -780f;
                break;
            case 1:
                return -260f;
                break;
            case 2:
                return 260f;
                break;
            case 3:
                return 780f;
                break;
            default:
                return -780f;
                break;

        }
    }

    void newCellInstantiate()
    {
        int x = Random.Range(0, 4);
        int y = Random.Range(0, 4);
        while (mainMatrix[x, y] != null)
        {
            x = Random.Range(0, 4);
            y = Random.Range(0, 4);
        }
        GameObject currentNewCell = Instantiate(newCell, new Vector3(0, 0, 0), Quaternion.identity);
        currentNewCell.transform.SetParent(mainGrid.transform);
        currentNewCell.transform.localPosition = new Vector3(IndexInCoordinate(x), IndexInCoordinate(y), 0f);
        currentNewCell.transform.localScale = new Vector3(1f, 1f, 1f);
        mainMatrix[x, y] = currentNewCell;
        mainMatrix[x, y].GetComponent<CellController>().changeValue(2);

    }

    void Start()
    {
        float maxRatio = 1;
        if (Screen.height > Screen.width)
        {
            maxRatio = (Screen.width - 100) / 2060f;
        }
        else
        {
            maxRatio = (Screen.height - 100) / 2060f;
        }


        mainGrid.transform.localScale = new Vector3(maxRatio, maxRatio, 1f);
        barGrid.transform.localScale = new Vector3(maxRatio, maxRatio, 1f);

        for (int y = 0; y < 4; y++)
        {
            for (int x = 0; x < 4; x++)
            {
                mainMatrix[x, y] = null;
            }
        }
        newCellInstantiate();
    }
    public void restartGame()
    {
        for (int y = 0; y < 4; y++)
        {
            for (int x = 0; x < 4; x++)
            {
                if (mainMatrix[x, y] != null)
                {
                    Destroy(mainMatrix[x, y]);
                }
                mainMatrix[x, y] = null;
            }
        }
        restartPanel.transform.localScale = new Vector3(0f, 0f, 0f);
        newCellInstantiate();
    }
    bool canMove()
    {
        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                if (mainMatrix[x, y] == null)
                {
                    for (int y2 = y + 1; y2 < 4; y2++)
                    {
                        if (mainMatrix[x, y2] != null)
                        {
                            return true;
                        }
                    }
                }
                if (mainMatrix[x, y] != null)
                {
                    for (int y2 = y + 1; y2 < 4; y2++)
                    {
                        if (mainMatrix[x, y2] != null)
                        {
                            if (mainMatrix[x, y2].GetComponent<CellController>().value == mainMatrix[x, y].GetComponent<CellController>().value)
                            {
                                return true;
                            }
                            break;
                        }
                    }
                }
            }
        }
        for (int x = 0; x < 4; x++)
        {
            for (int y = 3; y >= 0; y--)
            {
                if (mainMatrix[x, y] == null)
                {
                    for (int y2 = y - 1; y2 >= 0; y2--)
                    {
                        if (mainMatrix[x, y2] != null)
                        {
                            return true;
                        }
                    }
                }
                if (mainMatrix[x, y] != null)
                {
                    for (int y2 = y - 1; y2 >= 0; y2--)
                    {
                        if (mainMatrix[x, y2] != null)
                        {
                            if (mainMatrix[x, y2].GetComponent<CellController>().value == mainMatrix[x, y].GetComponent<CellController>().value)
                            {
                                return true;
                            }
                            break;
                        }
                    }
                }
            }
        }

        for (int y = 0; y < 4; y++)
        {
            for (int x = 0; x < 4; x++)
            {
                if (mainMatrix[x, y] == null)
                {
                    for (int x2 = x + 1; x2 < 4; x2++)
                    {
                        if (mainMatrix[x2, y] != null)
                        {
                            return true;
                        }
                    }
                }
                if (mainMatrix[x, y] != null)
                {
                    for (int x2 = x + 1; x2 < 4; x2++)
                    {
                        if (mainMatrix[x2, y] != null)
                        {
                            if (mainMatrix[x2, y].GetComponent<CellController>().value == mainMatrix[x, y].GetComponent<CellController>().value)
                            {
                                return true;
                            }
                            break;
                        }
                    }
                }
            }
        }
        for (int y = 0; y < 4; y++)
        {
            for (int x = 3; x >= 0; x--)
            {
                if (mainMatrix[x, y] == null)
                {
                    for (int x2 = x - 1; x2 >= 0; x2--)
                    {
                        if (mainMatrix[x2, y] != null)
                        {
                            return true;
                        }
                    }
                }
                if (mainMatrix[x, y] != null)
                {
                    for (int x2 = x - 1; x2 >= 0; x2--)
                    {
                        if (mainMatrix[x2, y] != null)
                        {
                            if (mainMatrix[x2, y].GetComponent<CellController>().value == mainMatrix[x, y].GetComponent<CellController>().value)
                            {
                                return true;
                            }
                            break;
                        }
                    }
                }
            }
        }
        return false;
    }
    void moveGrid(int direction)
    {
        bool free;
        bool moved;
        moved = false;
        switch (direction)
        {
            case 1:
                for (int x = 0; x < 4; x++)
                {
                    for (int y = 0; y < 4; y++)
                    {
                        if (mainMatrix[x, y] == null)
                        {
                            for (int y2 = y + 1; y2 < 4; y2++)
                            {
                                if (mainMatrix[x, y2] != null)
                                {
                                    mainMatrix[x, y] = mainMatrix[x, y2];
                                    mainMatrix[x, y].transform.localPosition = new Vector3(IndexInCoordinate(x), IndexInCoordinate(y), 0f);
                                    mainMatrix[x, y2] = null;
                                    moved = true;
                                    break;
                                }
                            }
                        }
                        if (mainMatrix[x, y] != null)
                        {
                            for (int y2 = y + 1; y2 < 4; y2++)
                            {
                                if (mainMatrix[x, y2] != null)
                                {
                                    if (mainMatrix[x, y2].GetComponent<CellController>().value == mainMatrix[x, y].GetComponent<CellController>().value)
                                    {
                                        Destroy(mainMatrix[x, y]);
                                        mainMatrix[x, y] = mainMatrix[x, y2];
                                        mainMatrix[x, y].transform.localPosition = new Vector3(IndexInCoordinate(x), IndexInCoordinate(y), 0f);
                                        mainMatrix[x, y].GetComponent<CellController>().changeValue(mainMatrix[x, y].GetComponent<CellController>().value * 2);
                                        mainMatrix[x, y2] = null;
                                        moved = true;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                break;

            case 2:
                for (int x = 0; x < 4; x++)
                {
                    for (int y = 3; y >= 0; y--)
                    {
                        if (mainMatrix[x, y] == null)
                        {
                            for (int y2 = y - 1; y2 >= 0; y2--)
                            {
                                if (mainMatrix[x, y2] != null)
                                {
                                    mainMatrix[x, y] = mainMatrix[x, y2];
                                    mainMatrix[x, y].transform.localPosition = new Vector3(IndexInCoordinate(x), IndexInCoordinate(y), 0f);
                                    mainMatrix[x, y2] = null;
                                    moved = true;
                                    break;
                                }
                            }
                        }
                        if (mainMatrix[x, y] != null)
                        {
                            for (int y2 = y - 1; y2 >= 0; y2--)
                            {
                                if (mainMatrix[x, y2] != null)
                                {
                                    if (mainMatrix[x, y2].GetComponent<CellController>().value == mainMatrix[x, y].GetComponent<CellController>().value)
                                    {
                                        Destroy(mainMatrix[x, y]);
                                        mainMatrix[x, y] = mainMatrix[x, y2];
                                        mainMatrix[x, y].transform.localPosition = new Vector3(IndexInCoordinate(x), IndexInCoordinate(y), 0f);
                                        mainMatrix[x, y].GetComponent<CellController>().changeValue(mainMatrix[x, y].GetComponent<CellController>().value * 2);
                                        mainMatrix[x, y2] = null;
                                        moved = true;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                break;

            case 3:
                for (int y = 0; y < 4; y++)
                {
                    for (int x = 0; x < 4; x++)
                    {
                        if (mainMatrix[x, y] == null)
                        {
                            for (int x2 = x + 1; x2 < 4; x2++)
                            {
                                if (mainMatrix[x2, y] != null)
                                {
                                    mainMatrix[x, y] = mainMatrix[x2, y];
                                    mainMatrix[x, y].transform.localPosition = new Vector3(IndexInCoordinate(x), IndexInCoordinate(y), 0f);
                                    mainMatrix[x2, y] = null;
                                    moved = true;
                                    break;
                                }
                            }
                        }
                        if (mainMatrix[x, y] != null)
                        {
                            for (int x2 = x + 1; x2 < 4; x2++)
                            {
                                if (mainMatrix[x2, y] != null)
                                {
                                    if (mainMatrix[x2, y].GetComponent<CellController>().value == mainMatrix[x, y].GetComponent<CellController>().value)
                                    {
                                        Destroy(mainMatrix[x, y]);
                                        mainMatrix[x, y] = mainMatrix[x2, y];
                                        mainMatrix[x, y].transform.localPosition = new Vector3(IndexInCoordinate(x), IndexInCoordinate(y), 0f);
                                        mainMatrix[x, y].GetComponent<CellController>().changeValue(mainMatrix[x, y].GetComponent<CellController>().value * 2);
                                        mainMatrix[x2, y] = null;
                                        moved = true;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                break;

            case 4:
                for (int y = 0; y < 4; y++)
                {
                    for (int x = 3; x >= 0; x--)
                    {
                        if (mainMatrix[x, y] == null)
                        {
                            for (int x2 = x - 1; x2 >= 0; x2--)
                            {
                                if (mainMatrix[x2, y] != null)
                                {
                                    mainMatrix[x, y] = mainMatrix[x2, y];
                                    mainMatrix[x, y].transform.localPosition = new Vector3(IndexInCoordinate(x), IndexInCoordinate(y), 0f);
                                    mainMatrix[x2, y] = null;
                                    moved = true;
                                    break;
                                }
                            }
                        }
                        if (mainMatrix[x, y] != null)
                        {
                            for (int x2 = x - 1; x2 >= 0; x2--)
                            {
                                if (mainMatrix[x2, y] != null)
                                {
                                    if (mainMatrix[x2, y].GetComponent<CellController>().value == mainMatrix[x, y].GetComponent<CellController>().value)
                                    {
                                        Destroy(mainMatrix[x, y]);
                                        mainMatrix[x, y] = mainMatrix[x2, y];
                                        mainMatrix[x, y].transform.localPosition = new Vector3(IndexInCoordinate(x), IndexInCoordinate(y), 0f);
                                        mainMatrix[x, y].GetComponent<CellController>().changeValue(mainMatrix[x, y].GetComponent<CellController>().value * 2);
                                        mainMatrix[x2, y] = null;
                                        moved = true;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                break;
        }
        free = false;
        for (int y = 0; y < 4; y++)
        {
            for (int x = 0; x < 4; x++)
            {
                if (mainMatrix[x, y] == null)
                {
                    free = true;
                }
            }
        }
        if (canMove())
        {
            if (free && moved)
            {
                newCellInstantiate();
            }
        }
        else
        {
            restartPanel.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown("down"))
        {
            moveGrid(1);
        }
        if (Input.GetKeyDown("up"))
        {
            moveGrid(2);
        }
        if (Input.GetKeyDown("left"))
        {
            moveGrid(3);
        }
        if (Input.GetKeyDown("right"))
        {
            moveGrid(4);
        }
        if (Input.GetMouseButtonDown(0))
        {
            startPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            direction = new Vector2(Input.mousePosition.x - startPos.x, Input.mousePosition.y - startPos.y);

            //normalize the 2d vector
            direction.Normalize();

            //swipe upwards
            if (direction.y > 0 && direction.x > -0.5f && direction.x < 0.5f)
            {
                moveGrid(2);
            }
            //swipe down
            if (direction.y < 0 && direction.x > -0.5f && direction.x < 0.5f)
            {
                moveGrid(1);
            }
            //swipe left
            if (direction.x < 0 && direction.y > -0.5f && direction.y < 0.5f)
            {
                moveGrid(3);
            }
            //swipe right
            if (direction.x > 0 && direction.y > -0.5f && direction.y < 0.5f)
            {
                moveGrid(4);
            }
        }

    }
}
