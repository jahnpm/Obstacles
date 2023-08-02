using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    public bool hasBall = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (BallController.dead)
            return;

        transform.position -= BallController.speed * Vector3.forward * Time.deltaTime;

        if (transform.position.z < -20.0f)
            Destroy(gameObject);
    }
}
