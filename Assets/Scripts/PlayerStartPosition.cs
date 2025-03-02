using UnityEngine;

public class PlayerStartPosition : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float xPosition;
    [SerializeField] float yPosition;
    [SerializeField] float zPosition;

    private void Awake()
    {
        StartPosition();
    }

    public void StartPosition()
    {
        player.position = new Vector3(xPosition, yPosition, zPosition);
    }
}
