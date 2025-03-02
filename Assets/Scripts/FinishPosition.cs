using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPosition : MonoBehaviour
{
    [SerializeField] Transform finish;
    [SerializeField] int stepsCount;

    private int _currentSteps, _currentI, _currentJ;

    private bool[,] _wallsHorizontal;
    private bool[,] _wallsVertical;

    public void FinishPositionSet(bool[,] wallsHorizontal, bool[,] wallsVertical)
    {
        _wallsHorizontal = wallsHorizontal;
        _wallsVertical = wallsVertical;

        _currentI = _wallsHorizontal.GetLength(0) / 2;
        _currentJ = _wallsVertical.GetLength(1) / 2;

        CheckingHorizontal(_currentI, _currentJ, 1);
        CheckingHorizontal(_currentI - 1, _currentJ, -1);
        CheckingVertical(_currentI, _currentJ, 1);
        CheckingVertical(_currentI, _currentJ - 1, -1);

        if (_currentSteps < stepsCount)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void CheckingHorizontal(int i, int j, int offset)
    {
        if (_currentSteps < stepsCount && !_wallsHorizontal[i, j])
        {
            _currentSteps++;
            CheckingSteps(i, j, "h");

            if (i > 0 && i < _currentI * 2 - 1)
            {
                CheckingHorizontal(i + offset, j, offset);
            }

            if (j < _currentJ * 2 - 1)
            {
                if (offset > 0)
                {
                    CheckingVertical(i + 1, j, 1);
                }
                else CheckingVertical(i, j, 1);
            }

            if (j > 0)
            {
                if (offset > 0)
                {
                    CheckingVertical(i + 1, j - 1, -1);
                }
                else CheckingVertical(i, j - 1, -1);
            }
        }
    }

    private void CheckingVertical(int i, int j, int offset)
    {
        if (_currentSteps < stepsCount && !_wallsVertical[i, j])
        {
            _currentSteps++;
            CheckingSteps(i, j, "v");

            if (j > 0 && j < _currentJ * 2 - 1)
            {
                CheckingVertical(i, j + offset, offset);
            }

            if (i < _currentJ * 2 - 1)
            {
                if(offset > 0)
                {
                    CheckingHorizontal(i, j + 1, 1);
                }
                else CheckingHorizontal(i, j, 1);
            }

            if (i > 0)
            {
                if (offset > 0)
                {
                    CheckingHorizontal(i - 1, j + 1, -1);
                }
                else CheckingHorizontal(i - 1, j, -1);

            }
        }
    }

    private void CheckingSteps(int i, int j, string t)
    {
        if (_currentSteps == stepsCount)
        {
            finish.position = new Vector3((i - _currentI) * 0.1f, 0.1f, (j - _currentJ) * 0.1f);
        }
    }
    
}
