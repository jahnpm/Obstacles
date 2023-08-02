using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalSlider : MonoBehaviour
{
    [SerializeField] private float xMin, xMax;
    [SerializeField] private FloorController floorController;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(xMin, xMax),
            transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (!floorController.hasBall)
            return;

        float mouseDeltaX = Input.GetAxis("Mouse X");

        transform.position += mouseDeltaX * Vector3.right;

        if (transform.position.x < xMin)
            transform.position = new Vector3(xMin, transform.position.y, transform.position.z);
        if (transform.position.x > xMax)
            transform.position = new Vector3(xMax, transform.position.y, transform.position.z);
    }
}
