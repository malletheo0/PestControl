using UnityEngine;

public class wallstop : MonoBehaviour
{

    public Transform top;
    public Transform left;
    public Transform right;
    public Transform bottom;
    public Vector3 speed = new Vector3();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(speed.x >= 0)
        {
            RaycastHit2D rightCast = Physics2D.Raycast(top.position + Vector3.up * 0.2f, Vector3.up, Mathf.Abs(speed.x * Time.fixedDeltaTime));
        }
    }


}
