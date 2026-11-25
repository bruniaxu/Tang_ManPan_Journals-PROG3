using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public enum FacingDirection
    {
        left, right
    }
    //task1
    public float moveSpeed = 2f;
    private Rigidbody2D body;
    //task2
    private FacingDirection facingDirection = FacingDirection.left;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        Vector2 playerInput = new Vector2();

        // The input from the player needs to be determined and
        // then passed in the to the MovementUpdate which should
        // manage the actual movement of the character.

        if(Keyboard.current != null)
        {
            if(Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            {
                playerInput.x -= 1f;
            }

            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            {
                playerInput.x += 1f;
            }

        }

        MovementUpdate(playerInput);
    }

    public void MovementUpdate(Vector2 playerInput)
    {
        float horizontalSpeed = playerInput.x * moveSpeed;
        body.linearVelocity = new Vector2(horizontalSpeed, body.linearVelocity.y);
    }

    public bool IsWalking()
    {
        if(body.linearVelocity.x < -0.01f || body.linearVelocity.x >0.01f)
        {
            return true;
        }
        return false;
    }
    public bool IsGrounded()
    {
        return false;
    }

    public FacingDirection GetFacingDirection()
    {
        if(body.linearVelocity.x < -0.01f)
        {
            facingDirection = FacingDirection.left;
        }
        else if(body.linearVelocity.x > 0.01f)
        {
            facingDirection = FacingDirection.right;
        }
        return facingDirection;
    }
}
