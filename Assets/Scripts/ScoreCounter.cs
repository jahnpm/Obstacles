using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public static float score = 0;

    [SerializeField] private Transform ballTransform;

    private TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BallController.dead)
        {
            text.text = ((int)(score)).ToString() + "\nGame Over\nSPACE to reset";

            return;
        }

        score += BallController.speed * Time.deltaTime;
        text.text = ((int)(score)).ToString();

        transform.position = ballTransform.position + 1.5f * Vector3.right + Vector3.up;
    }
}
