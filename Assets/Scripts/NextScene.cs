using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public void ChangeScene(int i)
    {
        TimeScale(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + i);
    }

    public void TimeScale(int i)
    {
        Time.timeScale = i;
    }
}
