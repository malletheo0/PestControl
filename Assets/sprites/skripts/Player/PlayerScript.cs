using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public PlayerInput playerInput;
    InputAction moveAction;
    InputAction jumpAction;
    public Vector3 velocity;
    public Transform topLeft;
    public Transform topRight;
    public Transform botLeft;
    public Transform botRight;
    public bool isGrounded;
    public bool isWalled;
    public LayerMask groundMask;
    void Start()
    {
        moveAction = playerInput.actions.FindAction("Move");
        jumpAction = playerInput.actions.FindAction("Jump");
        moveAction.Enable();
        jumpAction.Enable();

    }
    void Update()
    {
        Vector3 inputVector = moveAction.ReadValue<Vector2>();
        transform.Translate(inputVector * 3 * Time.deltaTime);

        if (jumpAction.WasPressedThisFrame() && isGrounded == true)
        {
            velocity.y = 6;
            isGrounded = false;
        }

        if (isWalled)
        {
            velocity.x = 0;
            transform.position += velocity * Time.deltaTime;

        }
        if (isGrounded == false)
        {
            velocity.y -= 8f * Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        if (isGrounded)
        {
            velocity.y = 0f;

            RaycastHit2D hit = Physics2D.Raycast(botLeft.position + Vector3.right * 0.001f, Vector2.down, 0.01f, groundMask);
            RaycastHit2D hit2 = Physics2D.Raycast(botRight.position + Vector3.left * 0.001f, Vector2.down, 0.01f, groundMask);
            if (!hit && !hit2)
            {
                isGrounded = false;
            }
        }

        if (velocity.x < 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(topRight.position + Vector3.down * 0.001f, Vector2.right, Mathf.Abs(velocity.x * Time.fixedDeltaTime), groundMask);
            RaycastHit2D hit2 = Physics2D.Raycast(botRight.position + Vector3.up * 0.001f, Vector2.right, Mathf.Abs(velocity.x * Time.fixedDeltaTime), groundMask);
            if (hit)
            {
                    isWalled = true;
            }
            else if (hit2)
            {
                    isWalled = true;
            }
            
        }
        if (velocity.x > 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(topLeft.position + Vector3.down * 0.001f, Vector2.left, Mathf.Abs(velocity.x * Time.fixedDeltaTime), groundMask);
            RaycastHit2D hit2 = Physics2D.Raycast(botLeft.position + Vector3.up * 0.001f, Vector2.left, Mathf.Abs(velocity.x * Time.fixedDeltaTime), groundMask);
            if (hit)
            {
                if (hit.collider.gameObject.tag == "Ground")
                {
                    isWalled = true;
                }
            }
            else if (hit2)
            {
                if (hit2.collider.gameObject.tag == "Ground")
                {
                    isWalled = true;
                }
            }
        }
        if (velocity.y > 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(topLeft.position + Vector3.right * 0.001f, Vector2.up, Mathf.Abs(velocity.y * Time.fixedDeltaTime), groundMask);
            RaycastHit2D hit2 = Physics2D.Raycast(topRight.position + Vector3.left * 0.001f, Vector2.up, Mathf.Abs(velocity.y * Time.fixedDeltaTime), groundMask);
            if (hit)
            {
                velocity.y = 0;
            }
            else if (hit2)
            {
                velocity.y = 0;
            }
        }
        if (isGrounded == false)
        {
            if (velocity.y < 0)
            {
                RaycastHit2D hit = Physics2D.Raycast(botLeft.position + Vector3.right * 0.001f, Vector2.down, Mathf.Abs(velocity.y * Time.fixedDeltaTime), groundMask);
                RaycastHit2D hit2 = Physics2D.Raycast(botRight.position + Vector3.left * 0.001f, Vector2.down, Mathf.Abs(velocity.y * Time.fixedDeltaTime), groundMask);
                if (hit)
                {
                    isGrounded = true;
                    velocity.y = hit.distance / Time.fixedDeltaTime * -1;     
                }
                else if (hit2)
                {
                        isGrounded = true;
                        velocity.y = hit2.distance / Time.fixedDeltaTime * -1;
                }

            }
        }


        transform.position += velocity * Time.fixedDeltaTime;
    }
}
