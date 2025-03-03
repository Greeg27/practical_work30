using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] GameObject levelComplete;
    [SerializeField] GameObject timer;
    [SerializeField] GameObject pause;

    private void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0;

        timer.SetActive(false);
        pause.SetActive(false);
        levelComplete.SetActive(true);
    }
}
