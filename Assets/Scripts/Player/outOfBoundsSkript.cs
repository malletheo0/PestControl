using UnityEngine;
using UnityEngine.SceneManagement;

public class outOfBoundsSkript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject fade;
    public GameObject player;
    public GameObject canvas;

    public Vector3 fadeStartPosition;
    public Vector3 playerStartPosition;
    void Start()
    {
        playerStartPosition = player.transform.position;
        fadeStartPosition = fade.transform.position;
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
        //    int id = SceneManager.GetActiveScene().buildIndex;
        //    SceneManager.LoadScene(id);
        }
        else if(collision.gameObject.tag == "Block")
        {
            Destroy(collision.gameObject);
        }
    }
}
