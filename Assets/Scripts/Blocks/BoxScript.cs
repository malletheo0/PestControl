using UnityEngine;

public class BoxScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject leftDown;
    public GameObject rightDown;
    public Vector3 tempPosition;
    public bool stop = false;
    public AudioSource audioSource;
    public AudioClip landSound;
    bool hasLanded = false;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasLanded)
        {
            audioSource.PlayOneShot(landSound);
            hasLanded = false;
        }
    }

    private void FixedUpdate()
    {
        if (rb.linearVelocityY < -0.01)
        {
            RaycastHit2D hitLeft = Physics2D.Raycast(leftDown.transform.position, Vector2.down, 0.1f);
            RaycastHit2D hitRight = Physics2D.Raycast(rightDown.transform.position, Vector2.down, 0.1f);
            tempPosition = transform.position;

            if (hitLeft)
            {
                if (hitLeft.collider.gameObject.tag == "Bottle")
                {
                    Rigidbody2D boxRigidbody = gameObject.GetComponent<Rigidbody2D>();
                    boxRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
                    tempPosition.y -= hitLeft.distance;
                    transform.position = tempPosition;
                    hitLeft.collider.gameObject.GetComponent<BottleScript>().isUnder = true;
                }
                else if (hitLeft.collider.gameObject.tag != "Box" || hitLeft.collider.gameObject.tag != "Preview")
                {
                    Rigidbody2D boxRigidbody = gameObject.GetComponent<Rigidbody2D>();
                    boxRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
                    gameObject.tag = "Block";
                    tempPosition.y -= hitLeft.distance;
                    transform.position = tempPosition;
                    stop = true;

                }

                hasLanded = true;
            }
            else
            {
                stop = false;
            }

            if (stop == false)
            {
                Rigidbody2D boxRigidbody = gameObject.GetComponent<Rigidbody2D>();
                boxRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            }

            if (hitRight)
            {
                if (stop == false)
                {
                    if (hitRight.collider.gameObject.tag == "Bottle")
                    {
                        Rigidbody2D boxRigidbody = gameObject.GetComponent<Rigidbody2D>();
                        boxRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
                        tempPosition.y -= hitLeft.distance;
                        transform.position = tempPosition;
                        hitRight.collider.gameObject.GetComponent<BottleScript>().isUnder = true;
                        if (rb.linearVelocityY < -0.05)
                        {
                            hasLanded = true;
                        }
                    }
                    else if (hitRight.collider.gameObject.tag != "Box" || hitRight.collider.gameObject.tag != "Preview")
                    {
                        Rigidbody2D boxRigidbody = gameObject.GetComponent<Rigidbody2D>();
                        boxRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
                        gameObject.tag = "Block";
                        tempPosition.y -= hitRight.distance;
                        transform.position = tempPosition;
                        stop = true;
                        if (rb.linearVelocityY < -0.05)
                        {
                            hasLanded = true;
                        }

                    }

                    hasLanded = true;
                }
            }

            if (stop == false)
            {
                Rigidbody2D boxRigidbody = gameObject.GetComponent<Rigidbody2D>();
                boxRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }
}
