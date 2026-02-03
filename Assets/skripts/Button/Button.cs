using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Button : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Cloud;
    public GameObject Box;
    public GameObject Bottle;
    public int cloudAmount;
    public int boxAmount;
    public int bottleAmount;

    public TextMeshProUGUI cloudButtonText;
    public TextMeshProUGUI boxButtonText;
    public TextMeshProUGUI bottleButtonText;
    public GameObject gameManager;
    Vector2 mousePosition;

    void Start()
    {
        cloudButtonText.text = cloudAmount.ToString();
        boxButtonText.text = boxAmount.ToString();
        bottleButtonText.text = bottleAmount.ToString();
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        
    }

    public void SpawnCloud()
    {
        if (cloudAmount >= 0.1 && gameManager.GetComponent<GameManager>().blockSelected == false)
        {
            Instantiate(Cloud, mousePosition, Quaternion.identity.normalized);
            cloudAmount -= 1;
            cloudButtonText.text = cloudAmount.ToString();
            gameManager.GetComponent<GameManager>().blockSelected = true;
        }
    }

    public void SpawnBox()
    {
        if (boxAmount >= 0.1 && gameManager.GetComponent<GameManager>().blockSelected == false)
        {
            Instantiate(Box, mousePosition, Quaternion.identity.normalized);
            boxAmount -= 1;
            boxButtonText.text = boxAmount.ToString();
            gameManager.GetComponent<GameManager>().blockSelected = true;
        }
    }

    public void SpawnBottle()
    {
        if (bottleAmount >= 0.1 && gameManager.GetComponent<GameManager>().blockSelected == false)
        {
            Instantiate(Bottle, mousePosition, Quaternion.identity.normalized);
            bottleAmount -= 1;
            bottleButtonText.text = bottleAmount.ToString();
            gameManager.GetComponent<GameManager>().blockSelected = true;
        }
    }
}
