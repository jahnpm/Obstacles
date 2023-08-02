using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDetector : MonoBehaviour
{
    [SerializeField] private FloorController floorController;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            BallController ball = other.GetComponent<BallController>();

            if (ball.currentFloor != null)
            {
                ball.currentFloor.hasBall = false;
            }

            floorController.hasBall = true;
            ball.currentFloor = floorController;
        }
    }
}
