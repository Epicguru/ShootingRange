
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementAdaptor : MonoBehaviour
{
    // Adaptor means that it works by taking external input, which could be form the player or from AI.
    [Header("Gravity")]
    public float GravityScale = 1f;
    [Header("Jumping")]
    public float JumpVelocity = 0.5f;
    [Header("Controls")]
    public bool Jump;
    public Vector3 HorizontalMovement;

    [ReadOnly]
    public Vector3 Velocity;

    [HideInInspector]
    public CharacterController CharacterController;

    public void Awake()
    {
        CharacterController = GetComponent<CharacterController>();
        Assert.IsNotNull(CharacterController, "Null Character Controller on PlayerMovementAdaptor.");
    }

    public void Update()
    {
        ApplyGravity();
        UpdateJumping();

        CharacterController.Move((Velocity * Time.deltaTime) + (GetHorizontalMovement() * Time.deltaTime));
    }

    private void ApplyGravity()
    {
        // Change downwards velocity over time if we are not on the ground.
        // Gravity = ~9.8 m/s/s
        if (!CharacterController.isGrounded)
        {
            Vector3 gravity = Physics.gravity * GravityScale * Time.deltaTime;
            Velocity += gravity;
        }
        else
        {
            // When on ground, reset gravity offset;
            Velocity.y = -0.01f;
        }
    }

    private void UpdateJumping()
    {
        // Jump when required.
        if (CanJump() && Jump)
        {
            Jump = false;
            Velocity += Vector3.up * JumpVelocity;
        }
    }

    public virtual Vector3 GetHorizontalMovement()
    {
        return HorizontalMovement;
    }

    public virtual bool CanJump()
    {
        return CharacterController.isGrounded;
    }
}