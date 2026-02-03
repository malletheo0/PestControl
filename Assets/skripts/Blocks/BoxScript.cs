using UnityEngine;

public class BoxScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject leftDown;
    public GameObject rightDown;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        RaycastHit2D hitLeft = Physics2D.Raycast(leftDown.transform.position, Vector2.down, 0.1f);
        RaycastHit2D hitRight = Physics2D.Raycast(rightDown.transform.position, Vector2.down, 0.1f);

        //if (hitLeft)
        //{
        //}
        //else if (hitRight)
        //{
        //}


        if(hitLeft.collider.gameObject.tag != "Box")
        {
            Rigidbody2D boxRigidbody = gameObject.GetComponent<Rigidbody2D>();
            boxRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            gameObject.tag = "Untagged";

        }
        else if (hitRight.collider.gameObject.tag != "Box")
        {
            Rigidbody2D boxRigidbody = gameObject.GetComponent<Rigidbody2D>();
            boxRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            gameObject.tag = "Untagged";

        }

        //if (hitLeft.collider.gameObject.tag != "Box" || hitRight.collider.gameObject.tag != "Box")
        //{
        //    Rigidbody2D boxRigidbody = gameObject.GetComponent<Rigidbody2D>();
        //    boxRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        //    gameObject.tag = "Untagged";
        //}

        
    }
}
