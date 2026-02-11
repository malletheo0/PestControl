using UnityEngine;

public class PlayerBox : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject outOfBounds;
    void Start()
    {
        outOfBounds = GameObject.Find("OutOfBounds");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Block")
        {

            outOfBounds.GetComponent<outOfBoundsSkript>().missedBoxes++;
            Destroy(collision.gameObject);
        }
    }
}
