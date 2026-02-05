using UnityEngine;

public class BoxScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject leftDown;
    public GameObject rightDown;
    public Vector3 tempPosition;
    public bool stop = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (stop == false)
        {
            RaycastHit2D hitLeft = Physics2D.Raycast(leftDown.transform.position, Vector2.down, 0.1f);
            RaycastHit2D hitRight = Physics2D.Raycast(rightDown.transform.position, Vector2.down, 0.1f);
            tempPosition = transform.position;
            if (hitLeft)
            {
                if (hitLeft.collider.gameObject.tag != "Box" || hitLeft.collider.gameObject.tag != "Preview")
                {
                    Rigidbody2D boxRigidbody = gameObject.GetComponent<Rigidbody2D>();
                    boxRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
                    gameObject.tag = "Block";
                    tempPosition.y -= hitLeft.distance;
                    transform.position = tempPosition;
                    stop = true;

                }
            }

            if (hitRight)
            {
                if (stop == false)
                {
                    if (hitRight.collider.gameObject.tag != "Box" || hitRight.collider.gameObject.tag != "Preview")
                    {
                        Rigidbody2D boxRigidbody = gameObject.GetComponent<Rigidbody2D>();
                        boxRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
                        gameObject.tag = "Untagged";
                        tempPosition.y -= hitRight.distance;
                        transform.position = tempPosition;
                        stop = true;

                    }
                }
            }
        }
        
    }
}
