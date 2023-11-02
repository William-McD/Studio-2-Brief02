using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed); // giving the bullet velocity

        DeathTimer();
    }

    public void DeathTimer() // MAY CHANGE FROM DEATHTIMER to a When at X/Y Value destroy self
    {
        if (transform.position.x < -16 || transform.position.x > 16 || transform.position.y < -16 || transform.position.y > 16)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyAttributes>().health -= 1;
            Destroy(gameObject);
        }
    }
}
