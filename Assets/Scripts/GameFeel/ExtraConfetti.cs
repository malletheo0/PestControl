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
                StartCoroutine(MegaConffeti((float)1.5, blockCount));
            }
        }
    }

    private IEnumerator MegaConffeti(float timer, int blockAmount)
    {
        float timerMax = timer;
        timer = 0f;
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        if (blockCount >= 1)
        {
            while (timer < timerMax)
            {
            timer += Time.deltaTime;
            if (cloudButton != null)
            {
                cloudButton.transform.position = cloudButton.transform.position + (new Vector3 (screenPoint.x, screenPoint.y) - cloudButton.transform.position) * (timer / timerMax);
            }
            if (bottleButton != null)
            {
                bottleButton.transform.position = bottleButton.transform.position + (new Vector3(screenPoint.x, screenPoint.y) - bottleButton.transform.position) * (timer / timerMax);
            }
            if (boxButton != null)
            {
                boxButton.transform.position = boxButton.transform.position + (new Vector3(screenPoint.x, screenPoint.y) - boxButton.transform.position) * (timer / timerMax);
            }
            yield return null;
            }

            Instantiate(Confetti, new Vector2(0,0), Quaternion.identity);
        }
        
    }
}
