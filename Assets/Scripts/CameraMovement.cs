using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float distance;

    private void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y + distance, target.position.z);
    }
}
