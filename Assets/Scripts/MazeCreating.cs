using UnityEngine;
using UnityEngine.UIElements;

public class MazeCreating : MonoBehaviour
{
    [Header("Parametrs")]
    [SerializeField] int width;
    [SerializeField] int height;
    [SerializeField] int passageCoef;
    //[SerializeField] float size;
    [Header("GameObjects")]
    [SerializeField] GameObject wall;
    [SerializeField] GameObject floor;
    [SerializeField] GameObject walls;
    [SerializeField] GameObject[] externalWalls;
    [SerializeField] FinishPosition finishPosition;
    //[SerializeField] GameObject Arena;

    private bool[,] _wallsHorizontal;
    private bool[,] _wallsVertical;

    private int _passageCount;
    //private float _wallYPos;

    private System.Random _rnd = new System.Random();

    private void Awake()
    {
        _passageCount = 1;

        LevelSizeSet();

        ExternalWallsSet();

        WallsArraysInitial();

        //_wallYPos = (floor.transform.localScale.y / 2) + (wall.transform.localScale.y / 2);

        WallsArraysCompletion();

        WallsPositionSet();

        finishPosition.FinishPositionSet(_wallsHorizontal, _wallsVertical);

        //Arena.transform.localScale *= size;
    }

    private void LevelSizeSet()
    {
        floor.transform.localScale = new Vector3(width * 0.1f, 0.1f, height * 0.1f);
    }

    private void WallsPositionSet()
    {
        walls.transform.position = new Vector3((float)width / -2, 0, (float)height / -2) * 0.1f;
    }

    private void WallsArraysInitial()
    {
        _wallsHorizontal = new bool[width - 1, height];
        _wallsVertical = new bool[width, height - 1];
    }

    private void WallsArraysCompletion()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (SetActiv())
                {
                    HorizontalSet(i, j);

                    if (_passageCount > 2 & !AdjacentPassagesChecking(i, j))
                    {
                        if (SetActiv())
                        {
                            VerticalSet(i, j);
                            _passageCount--;
                        }
                    }
                }
                else
                {
                    if (SetActiv())
                    {
                        VerticalSet(i, j);
                    }
                    else _passageCount++;
                }
            }
        }
    }

    private void HorizontalSet(int i, int j)
    {
        if (i < width - 1)
        {
            Instantiate(i + 1, j + 0.5f, Vector3.zero);
            _wallsHorizontal[i, j] = true;
        }
    }

    private void VerticalSet(int i, int j)
    {
        if (j < height - 1)
        {
            Instantiate(i + 0.5f, j + 1, new Vector3(0, 90, 0));
            _wallsVertical[i, j] = true;
        }
    }

    private bool AdjacentPassagesChecking(int i, int j)
    {
        bool flag = false;

        if (i > 0)
        {
            flag = _wallsHorizontal[i - 1, j];
        }
        else flag = true;

        if (j > 0 & flag)
        {
            flag = _wallsVertical[i, j - 1];
        }

        return flag;
    }

    public void Instantiate(float i, float j, Vector3 rotate)
    {
        Instantiate(wall, new Vector3(i * 0.1f, 0.1f, j * 0.1f), Quaternion.Euler(rotate), walls.transform);
    }

    private bool SetActiv()
    {
        return _rnd.Next(passageCoef + 2) > passageCoef ? false : true;
    }

    private void ExternalWallsSet()
    {
        externalWalls[0].transform.localScale = new Vector3(0.02f, 0.04f, height * 0.1f);
        externalWalls[0].transform.position = new Vector3(0, 0.1f, (float)height / 20);

        externalWalls[1].transform.localScale = new Vector3(0.02f, 0.04f, height * 0.1f);
        externalWalls[1].transform.position = new Vector3(width * 0.1f, 0.1f, (float)height / 20);

        externalWalls[2].transform.localScale = new Vector3(0.02f, 0.04f, width * 0.1f);
        externalWalls[2].transform.position = new Vector3((float)width / 20, 0.1f, height * 0.1f);

        externalWalls[3].transform.localScale = new Vector3(0.02f, 0.04f, width * 0.1f);
        externalWalls[3].transform.position = new Vector3((float)width / 20, 0.1f, 0);
    }
}
