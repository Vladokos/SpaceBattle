using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MainCamer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.DOMoveY(1f, 1f, false);
    }
}
