using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private BallController ball;
    [SerializeField] private float viewDistance = 60.0f;

    private FloorController newestFloor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (newestFloor == null)
        {
            generateRandomFloor(null);
        }
        else if (newestFloor.transform.position.z < viewDistance - 10.0f)
        {
            generateRandomFloor(newestFloor);
        }
    }

    private void generateRandomFloor(FloorController newest)
    {
        int randomIndex = Random.Range(0, prefabs.Length);

        Vector3 pos = newest == null ? 10 * Vector3.forward
            : newest.transform.position + 20.0f * Vector3.forward;

        FloorController floor = Instantiate(prefabs[randomIndex], pos, Quaternion.identity)
                                    .GetComponent<FloorController>();

        newestFloor = floor;
    }
}
