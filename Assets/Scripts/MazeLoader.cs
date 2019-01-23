using UnityEngine;
using System.Collections;

public class MazeLoader : MonoBehaviour
{
    public int mazeRows;
    public int mazeColumns;
    public GameObject wall;
    public GameObject Sponza;
    // original size
    public float size = 2f;

    private MazeCell[,] mazeCells;

    // Use this for initialization
    void Start()
    {
        mazeRows = PlayerPrefs.GetInt("mazeRows");
        mazeColumns = PlayerPrefs.GetInt("mazeColumns");
        InitializeMaze();

        MazeAlgorithm ma = new HuntAndKillMazeAlgorithm(mazeCells);
        ma.CreateMaze();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void InitializeMaze()
    {

        mazeCells = new MazeCell[mazeRows, mazeColumns];

        for (int r = 0; r < mazeRows; r++)
        {
            for (int c = 0; c < mazeColumns; c++)
            {
                mazeCells[r, c] = new MazeCell();

                // For now, use the same wall object for the floor!
                mazeCells[r, c].floor = Instantiate(wall, new Vector3(r * size, -(size / 2f) - (float)1.2, c * size), Quaternion.identity);
                mazeCells[r, c].floor.transform.parent = Sponza.transform;
                mazeCells[r, c].floor.name = "Floor " + r + "," + c;
                mazeCells[r, c].floor.transform.Rotate(Vector3.right, 90f);

                mazeCells[r, c].roof = Instantiate(wall, new Vector3(r * size, -(size / 2f) + (float)4.9, c * size), Quaternion.identity);
                mazeCells[r, c].roof.transform.parent = Sponza.transform;
                mazeCells[r, c].roof.name = "Roof " + r + "," + c;
                mazeCells[r, c].roof.transform.Rotate(Vector3.right, 90f);

                if (c == 0)
                {
                    if (!(r == 0 && c == 0))
                    {
                        mazeCells[r, c].westWall = Instantiate(wall, new Vector3(r * size, 0, (c * size) - (size / 2f)), Quaternion.identity);
                        mazeCells[r, c].westWall.transform.parent = Sponza.transform;
                        mazeCells[r, c].westWall.name = "West Wall " + r + "," + c;
                    }
                }

                if (!(r == mazeRows - 1 && c == mazeColumns - 1))
                {
                    mazeCells[r, c].eastWall = Instantiate(wall, new Vector3(r * size, 0, (c * size) + (size / 2f)), Quaternion.identity);
                    mazeCells[r, c].eastWall.transform.parent = Sponza.transform;
                    mazeCells[r, c].eastWall.name = "East Wall " + r + "," + c;
                }

                if (r == 0)
                {
                    mazeCells[r, c].northWall = Instantiate(wall, new Vector3((r * size) - (size / 2f), 0, c * size), Quaternion.identity);
                    mazeCells[r, c].northWall.transform.parent = Sponza.transform;
                    mazeCells[r, c].northWall.name = "North Wall " + r + "," + c;
                    mazeCells[r, c].northWall.transform.Rotate(Vector3.up * 90f);
                }

                mazeCells[r, c].southWall = Instantiate(wall, new Vector3((r * size) + (size / 2f), 0, c * size), Quaternion.identity);
                mazeCells[r, c].southWall.transform.parent = Sponza.transform;
                mazeCells[r, c].southWall.name = "South Wall " + r + "," + c;
                mazeCells[r, c].southWall.transform.Rotate(Vector3.up * 90f);
            }
        }
    }
}