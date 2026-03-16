using System.Collections;
using UnityEngine;

public class ExtraConfetti : MonoBehaviour
{
    public ParticleSystem Confetti;
    public GameObject canvas;
    public GameObject cloudButton;
    public GameObject bottleButton;
    public GameObject boxButton;
    public int blockCount;
    public bool played;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (played != true)
        {
            if (collision.gameObject.tag == "Player")
            {
                played = true;
                blockCount = canvas.GetComponent<Button>().boxAmount + canvas.GetComponent<Button>().bottleAmount + canvas.GetComponent<Button>().cloudAmount;
                StartCoroutine(MegaConffeti(Time.deltaTime, blockCount));
            }
        }
    }

    private IEnumerator MegaConffeti(float wait, int blockAmount)
    {
        while((gameObject.transform.position - boxButton.transform.position).magnitude <= 0.5 && 
            (gameObject.transform.position - bottleButton.transform.position).magnitude <= 0.5 &&
            (gameObject.transform.position - cloudButton.transform.position).magnitude <= 0.5)
        {

            yield return null;
        }
        if (blockCount >= 1)
        {
            Instantiate(Confetti, new Vector2(960, 540), Quaternion.identity);
        }

    }
}
