using UnityEngine;

public class BoxScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject leftDown;
    public GameObject rightDown;
    public Vector3 tempPosition;
    public bool stop = false;
    public bool foreverStop = false;
    public AudioSource audioSource;
    public AudioClip landSound;
    bool hasLanded = false;
    bool playedSound = false;
    public bool hasHit = true;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playedSound == false && hasLanded == true)
        {
            audioSource.PlayOneShot(landSound);
            hasLanded = false;
            playedSound = true;
        }
    }

    private void FixedUpdate()
    {
        if(hasHit)
        {
            Rigidbody2D boxRigidbody = gameObject.GetComponent<Rigidbody2D>();
            boxRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            Rigidbody2D boxRigidbody = gameObject.GetComponent<Rigidbody2D>();
            boxRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        if (foreverStop == false)
        {
            hasHit = false;
            if(rb.linearVelocityY>= 0.00000000001 || rb.linearVelocityY <= -0.000000001)
            {
                playedSound = false;
            }
            RaycastHit2D hitLeft = Physics2D.Raycast(leftDown.transform.position, Vector2.down, 0.1f);
            RaycastHit2D hitRight = Physics2D.Raycast(rightDown.transform.position, Vector2.down, 0.1f);
            tempPosition = transform.position;

            if (hitLeft)
            {
                Debug.Log("vänster träffar");
                if (hitLeft.collider.gameObject.tag == "Bottle" || hitLeft.collider.gameObject.tag == "Player")
                {
                    Debug.Log("vänster inne");
                    hasHit = true;

                    if (hitLeft.collider.gameObject.tag == "bottle")
                    {
                        hitLeft.collider.gameObject.GetComponent<BottleScript>().isUnder = true;
                        tempPosition.y -= hitLeft.distance;
                        transform.position = tempPosition;
                    }
                    else if (hitRight)
                    {
                        if (hitRight.collider.gameObject.tag != "Ground" && hitRight.collider.gameObject.tag != "Block" && hitRight.collider.gameObject.tag != "bottle")
                        {
                            tempPosition.y -= hitLeft.distance;
                            transform.position = tempPosition;
                        }
                    }

                    if (playedSound == false)
                    {
                        hasLanded = true;
                    }
                }
                else if (hitLeft.collider.gameObject.tag == "Ground" || hitLeft.collider.gameObject.tag == "Block")
                {
                    Debug.Log("Left träffadadadaedfe");
                    hasHit = true;
                    gameObject.tag = "Block";
                    tempPosition.y -= hitLeft.distance;
                    transform.position = tempPosition;
                    stop = true;
                    if (hitLeft.collider.gameObject.layer == 8)
                    { }
                    else
                    {
                        foreverStop = true;
                    }
                    if (playedSound == false)
                    {
                        hasLanded = true;
                    }
                }
                else if (hitLeft)
                {
                    if (hitRight)
                    {
                        if (hitLeft.collider.gameObject.tag == "Destroy" && (hitRight.collider.gameObject.tag != "Block" && hitRight.collider.gameObject.tag == "Ground"))
                        {
                            Destroy(gameObject);
                        }
                    }
                    else Destroy(gameObject);
                }

            }


            if (hitRight)
            {
                Debug.Log("högér träffar");
                if (hitRight.collider.gameObject.tag == "Bottle" || hitRight.collider.gameObject.tag == "Player")
                {
                    Debug.Log("högér träffar innw");
                    hasHit = true;
                    tempPosition.y -= hitLeft.distance;
                    transform.position = tempPosition;
                    if (hitRight.collider.gameObject.tag == "Bottle")
                    {
                        hitRight.collider.gameObject.GetComponent<BottleScript>().isUnder = true;
                    }
                    else if (hitLeft)
                    {
                        if (hitLeft.collider.gameObject.tag != "Ground" && hitLeft.collider.gameObject.tag != "Block" && hitLeft.collider.gameObject.tag != "bottle")
                        {
                            tempPosition.y -= hitRight.distance;
                            transform.position = tempPosition;
                        }
                    }
                    if (playedSound == false)
                    {
                        hasLanded = true;
                    }
                }
                else if (hitRight.collider.gameObject.tag == "Ground" || hitRight.collider.gameObject.tag == "Block")
                {
                    Debug.Log("right träffadadadaedfe");
                    hasHit = true;
                    gameObject.tag = "Block";
                    tempPosition.y -= hitLeft.distance;
                    transform.position = tempPosition;
                    if (hitRight.collider.gameObject.layer == 8)
                    { }
                    else
                    {
                        foreverStop = true;
                    }
                    stop = true;
                    if (playedSound == false)
                    {
                        hasLanded = true;
                    }
                }
                else if (hitRight)
                {
                    if (hitLeft)
                    {
                        if (hitRight.collider.gameObject.tag == "Destroy" && (hitLeft.collider.gameObject.tag != "Block" && hitLeft.collider.gameObject.tag == "Ground"))
                        {
                            Destroy(gameObject);
                        }
                    }
                    else
                    {
                        Destroy(gameObject);
                    }
                }

            }  
            if(hitLeft.collider == null && hitRight.collider == null)
            {
                hasHit = false;
            }

        }
    }
}
