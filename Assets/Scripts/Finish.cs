using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] GameObject levelComplete;

    private void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0;
        levelComplete.SetActive(true);
    }
}
