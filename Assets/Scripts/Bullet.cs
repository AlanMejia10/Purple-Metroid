using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    Rigidbody2D rb;
    [SerializeField] GameObject impactEffect;
    float bulletSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(bulletSpeed, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("collied with: " + other.gameObject.name);
        GameObject bullet = Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(bullet, 0.3f);
        Destroy(gameObject);
    }

    
}
