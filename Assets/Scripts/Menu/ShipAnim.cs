using System.Collections;
using UnityEngine;

public class ShipAnim : MonoBehaviour
{
    public GameObject plShip;
    public Animator fireEngine;
    private Transform _transform;
    public float needPosShip;
    public float speed = 5f;
    void Start()
    {
        _transform = GetComponent<Transform>();
    }
    void Update()
    {

    }
    IEnumerator offEngine()
    {
        yield return new WaitForSeconds(1f);
        fireEngine.gameObject.SetActive(false);
    }

    public void moveShip()
    {
        if (plShip.transform.position.y < needPosShip)
        {
            plShip.transform.Translate(0, Time.deltaTime * speed, 0);
        }
        else
        {

            fireEngine.SetBool("ArrowcClick", false);
            StartCoroutine(offEngine());
        }
    }
}
