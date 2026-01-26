using UnityEngine;

public class Spawnmanager : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public float fireCooldown = 0.2f;
    private float nextFireTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TrySpawnBullet()
    {
        if (bulletPrefab == null)
            return;
        if (Time.time < nextFireTime)
            return;

        Transform shootPoint = spawnPoint == null ? transform : spawnPoint;
        GameObject newBullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation); 

        Playerbulletskript bullet = newBullet.GetComponent<Playerbulletskript>();

        nextFireTime = Time.time + fireCooldown; 
    }
}
