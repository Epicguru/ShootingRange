using UnityEngine;

[RequireComponent(typeof(PlayerMovementAdaptor))]
public class PlayerMovementInput : MonoBehaviour
{
    public PlayerMovementAdaptor Movement;

    [Header("Settings")]
    public float Speed = 10f;
    public bool AllowAirControl;

    public void Update()
    {
        // Jump input...
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Movement.Jump = true;
        }

        // Horzontal input.
        Vector3 global = transform.TransformDirection(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        global *= Speed;
        if (!Movement.CharacterController.isGrounded)
        {
            if (!AllowAirControl)
            {
                return;
            }
        }
        Movement.HorizontalMovement = global;
    }
}