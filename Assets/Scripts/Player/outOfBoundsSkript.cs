using UnityEngine;
using UnityEngine.SceneManagement;

public class outOfBoundsSkript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject fade;
    public GameObject player;
    public GameObject canvas;

    public int missedBoxes;
    public int originalBottleAmount;
    public Vector3 fadeStartPosition;
    public Vector3 playerStartPosition;
    void Start()
    {
        playerStartPosition = player.transform.position;
        fadeStartPosition = fade.transform.position;
        originalBottleAmount = canvas.GetComponent<Button>().bottleAmount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.transform.position = playerStartPosition;
            Instantiate(fade, fadeStartPosition, Quaternion.identity.normalized,canvas.transform);

            canvas.GetComponent<Button>().bottleAmount = originalBottleAmount;
            canvas.GetComponent<Button>().bottleButtonText.text = originalBottleAmount.ToString();

            canvas.GetComponent<Button>().boxAmount += missedBoxes;
            canvas.GetComponent<Button>().boxButtonText.text = canvas.GetComponent<Button>().boxAmount.ToString();
            missedBoxes = 0;
        }
        else if(collision.gameObject.tag == "Block")
        {
            missedBoxes++;
            Destroy(collision.gameObject);
        }
    }
}
