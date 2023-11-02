using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    public float spawnRadius;

    public float countdownTimerStart;
    [SerializeField] float countdownTimer;


    private void Awake()
    {
        countdownTimer = countdownTimerStart;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (countdownTimer >= 0)
        {
            countdownTimer -= Time.deltaTime;
        }
        else
        {
            SpawnEnemyOnEdge();
            countdownTimer = countdownTimerStart;
        }
    }


    private void SpawnEnemyOnEdge()
    {
        float radius = spawnRadius;
        Vector3 randomPos = Random.insideUnitSphere * radius;
        randomPos += transform.position;
        randomPos.y = 0f;

        Vector3 direction = randomPos - transform.position;
        direction.Normalize();

        float dotProduct = Vector3.Dot(transform.forward, direction);
        float dotProductAngle = Mathf.Acos(dotProduct / transform.forward.magnitude * direction.magnitude);

        randomPos.x = Mathf.Cos(dotProductAngle) * radius + transform.position.x;
        randomPos.y = Mathf.Sin(dotProductAngle * (Random.value > 0.5f ? 1f : -1f)) * radius + transform.position.y;
        randomPos.z = transform.position.z;

        GameObject go = Instantiate(enemy, randomPos, Quaternion.identity);
        go.transform.position = randomPos;
    }
}
