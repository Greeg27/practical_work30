using UnityEngine;

public class LevelMovement : MonoBehaviour
{
    [SerializeField] float force;
    [SerializeField] Transform basePosition;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void GetPlayerInput(Touch touch)
    {
        TableTint(touch.deltaPosition.y, touch.deltaPosition.x);
    }

    private void TableTint(float x, float z)
    {
        _rb.AddTorque(x * force, 0, z * force * -1);
    }

    
}
