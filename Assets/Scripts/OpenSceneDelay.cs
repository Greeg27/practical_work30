using System.Collections;
using UnityEngine;

public class OpenSceneDelay : MonoBehaviour
{
    [SerializeField] NextScene nextScene;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(3);

        nextScene.ChangeScene(1);
    }
}
