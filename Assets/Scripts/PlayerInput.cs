using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] LevelMovement levelMovement;

    private void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            levelMovement.GetPlayerInput(touch);
        }
    }
}
