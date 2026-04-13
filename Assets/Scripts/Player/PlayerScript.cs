using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public PlayerInput playerInput;
    InputAction moveAction;
    InputAction jumpAction;

    public Vector3 velocity;
    public Transform topLeft;
    public Transform topRight;
    public Transform midTopLeft;
    public Transform midTopRight;
    public Transform midRight;
    public Transform midLeft;
    public Transform midBotLeft;
    public Transform midBotRight;
    public Transform botLeft;
    public Transform botRight;
    Vector3 inputVelocity;

    public bool isGrounded;
    bool hasJumped = false;
    bool hasLanded = false;
    public LayerMask groundMask;
    public Animator animator;
    public string sceneName;
    public TextMeshProUGUI levelText;

    //public AudioClip jumpSound;
    public AudioClip landSound;
    public AudioClip walkSound;
    public AudioSource audioSource;
    public AudioSource audioSource2;
    void Start()
    {
        moveAction = playerInput.actions.FindAction("Move");
        jumpAction = playerInput.actions.FindAction("Jump");
        moveAction.Enable();
        jumpAction.Enable();

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        levelText.SetText(sceneName);
    }
    void Update()
    {
        Vector3 inputVector = moveAction.ReadValue<Vector2>();
        //transform.Translate(inputVector * 3 * Time.deltaTime);
        inputVelocity.x = inputVector.x * 5f;

        if (jumpAction.WasPressedThisFrame() && isGrounded == true)
        {

            //audioSource2.PlayOneShot(jumpSound);
            hasJumped = true;
        }
        if (hasLanded)
        { 
            audioSource2.PlayOneShot(landSound);
            hasLanded = false;
        }

        animator.SetFloat("VelocityX", Mathf.Abs(velocity.x));
        animator.SetBool("IsGrounded", isGrounded);
    }
    private void FixedUpdate()
    {
        velocity.x = inputVelocity.x;

        if(hasJumped)
        {
            velocity.y = 12;
            isGrounded = false;
            hasJumped = false;
        }
        if (isGrounded)
        {
            velocity.y = 0f;
            RaycastHit2D hit1 = Physics2D.Raycast(botLeft.position + Vector3.right * 0.01f, Vector2.down, 0.01f, groundMask);
            RaycastHit2D hit2 = Physics2D.Raycast(botRight.position + Vector3.left * 0.01f, Vector2.down, 0.01f, groundMask);
            if (!hit1 && !hit2)
            {
                isGrounded = false;
            }
        }

        if (isGrounded == false)
        {
            velocity.y -= 30f * Time.fixedDeltaTime;
        }

        if (velocity.x > 0)
        {
            if (!audioSource.isPlaying && isGrounded == true)
            {
                audioSource.Play();
            }
            GetComponent<SpriteRenderer>().flipX = false;
            RaycastHit2D[] hit2Ds = { Physics2D.Raycast(topRight.position + Vector3.down * 0.01f, Vector2.right, Mathf.Abs(velocity.x * Time.fixedDeltaTime), groundMask),
            Physics2D.Raycast(midTopRight.position, Vector2.right, Mathf.Abs(velocity.x * Time.fixedDeltaTime), groundMask),
            Physics2D.Raycast(midRight.position, Vector2.right, Mathf.Abs(velocity.x * Time.fixedDeltaTime), groundMask),
            Physics2D.Raycast(midBotRight.position, Vector2.right, Mathf.Abs(velocity.x * Time.fixedDeltaTime), groundMask),
            Physics2D.Raycast(botRight.position + Vector3.up * 0.01f, Vector2.right, Mathf.Abs(velocity.x * Time.fixedDeltaTime), groundMask)};

            for (int i = 0; i < hit2Ds.Length; i++)
            {
                if (hit2Ds[i])
                {
                    float smallestDistance = 0;
                    for (int j = 0; j < hit2Ds.Length; j++)
                    {
                        if (smallestDistance >= hit2Ds[j].distance)
                        {
                            smallestDistance = hit2Ds[j].distance;
                        }
                    }
                    velocity.x = smallestDistance / Time.fixedDeltaTime;
                    i = hit2Ds.Length;
                }
            }

        }
        if (velocity.x < 0)
        {
            if (!audioSource.isPlaying&& isGrounded == true)
            {
                audioSource.Play();
            }
            GetComponent<SpriteRenderer>().flipX = true;
            RaycastHit2D[] hit2Ds = { Physics2D.Raycast(topLeft.position + Vector3.down * 0.01f, Vector2.left, Mathf.Abs(velocity.x * Time.fixedDeltaTime), groundMask),
            Physics2D.Raycast(midTopLeft.position, Vector2.left, Mathf.Abs(velocity.x * Time.fixedDeltaTime), groundMask),
            Physics2D.Raycast(midLeft.position, Vector2.left, Mathf.Abs(velocity.x * Time.fixedDeltaTime), groundMask),
            Physics2D.Raycast(midBotLeft.position, Vector2.left, Mathf.Abs(velocity.x * Time.fixedDeltaTime), groundMask),
            Physics2D.Raycast(botLeft.position + Vector3.up * 0.01f, Vector2.left, Mathf.Abs(velocity.x * Time.fixedDeltaTime), groundMask)};

            for (int i = 0; i < hit2Ds.Length; i++)
            {
                if (hit2Ds[i])
                {
                    float smallestDistance = 0;
                    for (int j = 0; j < hit2Ds.Length; j++)
                    {
                        if(smallestDistance >= hit2Ds[j].distance)
                        {
                            smallestDistance = hit2Ds[j].distance;
                        }
                    }
                    velocity.x = smallestDistance / Time.fixedDeltaTime * -1f;
                    i = hit2Ds.Length;
                }
            }
        }
        if(velocity.x == 0)
        {
            audioSource.Pause();
        }
        if (velocity.y > 0)
        {
            RaycastHit2D hit1 = Physics2D.Raycast(topLeft.position + Vector3.right * 0.01f, Vector2.up, Mathf.Abs(velocity.y * Time.fixedDeltaTime), groundMask);
            RaycastHit2D hit2 = Physics2D.Raycast(topRight.position + Vector3.left * 0.01f, Vector2.up, Mathf.Abs(velocity.y * Time.fixedDeltaTime), groundMask);
            if (hit1)
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
                RaycastHit2D hit1 = Physics2D.Raycast(botLeft.position + Vector3.right * 0.01f, Vector2.down, Mathf.Abs(velocity.y * Time.fixedDeltaTime), groundMask);
                RaycastHit2D hit2 = Physics2D.Raycast(botRight.position + Vector3.left * 0.01f, Vector2.down, Mathf.Abs(velocity.y * Time.fixedDeltaTime), groundMask);
                if (hit1)
                {
                    hasLanded = true;
                    isGrounded = true;
                    velocity.y = hit1.distance / Time.fixedDeltaTime * -1;     
                }
                else if (hit2)
                {
                    hasLanded = true;
                    isGrounded = true;
                        velocity.y = hit2.distance / Time.fixedDeltaTime * -1;
                }
            }
        }

       

        inputVelocity.x = 0f;
        transform.position += velocity * Time.fixedDeltaTime;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject collided = collision.gameObject;
        if (sceneName != "WinScene")
        {
            if (collided.CompareTag("Finish"))
            {
                StartCoroutine(DelayGoal());
                velocity.x = 0;
                velocity.y = 0;
            }
        }
    }
    IEnumerator DelayGoal()
    {
        
            for (float i = 0; i < 3f; i += Time.deltaTime)
            {
                yield return null;
            }
        
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
