using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MainCamer : MonoBehaviour
{
    public List<Transform> moveSpots;

    private int randomSpot;

    public float startWaitTime;

    private float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0,moveSpots.Count);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, Time.fixedDeltaTime * 0.5f);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Count);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
