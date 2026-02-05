using UnityEngine;
using UnityEngine.SceneManagement;

public class outOfBoundsSkript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            int id = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(id);
        }
        else if(collision.gameObject.tag == "Box" || collision.gameObject.tag == "Block")
        {
            Destroy(collision.gameObject);
        }
    }
}
