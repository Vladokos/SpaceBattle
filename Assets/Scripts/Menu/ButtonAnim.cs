using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnim : MonoBehaviour
{
    public float speed = 5f;
    private RectTransform _rectTransform;

    public GameObject plShip;
    public Animator fireEngine;
    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (_rectTransform.position.y < -1.3f)
        {
            _rectTransform.Translate(0,-1.3f * Time.deltaTime * speed,0);
        }

        if (plShip.transform.position.y < -1.13f)
        {
            plShip.transform.Translate(0,-1.13f * Time.deltaTime * speed,0);
        }
        else
        {
            fireEngine.gameObject.SetActive(false);
        }
    }
}
