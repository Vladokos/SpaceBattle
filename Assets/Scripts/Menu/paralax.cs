using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralax : MonoBehaviour
{
    private float length,startPy;

    public GameObject cam;

    public float paral;
    // Start is called before the first frame update
    void Start()
    {
        startPy = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float disty = (cam.transform.position.y * paral);
        
        transform.position =new Vector3(transform.position.x,startPy + disty,transform.position.z);
    }
}
