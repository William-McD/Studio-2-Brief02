using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float deathTimerStart;
    public float speed;

    private void Awake()
    {
        deathTimerStart = 5f;
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
        deathTimerStart -= Time.deltaTime;
        if (deathTimerStart < 0 )
        {
            Destroy(gameObject);
        }
    }
}
