using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public static float speed = 5;
    public static bool dead = false;

    public FloorController currentFloor;

    private const float circ = 2 * Mathf.PI * 0.5f;

    private Vector3 targetPosition;
    private int realTimeIntegerPrevious = 0;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dead = false;
            speed = 5;
            ScoreCounter.score = 0;
        }

        if (BallController.dead)
            return;

        int realTimeInteger = (int)Time.realtimeSinceStartup;

        if (realTimeInteger % 10 == 0 && realTimeIntegerPrevious != realTimeInteger)
        {
            speed += 1;
            realTimeIntegerPrevious = realTimeInteger;
        }

        float dist = speed * Time.deltaTime;
        float deg = (dist / circ) * 360.0f;

        transform.Rotate(Vector3.right, deg);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
            dead = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            targetPosition = new Vector3(Random.Range(-3.5f, 3.5f), transform.position.y, transform.position.z);
        }
    }
}
