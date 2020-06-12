using UnityEngine;

public class ButtonAnim : MonoBehaviour
{
    public float speed = 5f;
    private RectTransform _rectTransform;
    public float needPos;
    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {

    }

    public void movePos()
    {
        if (_rectTransform.position.y < needPos)
        {
            _rectTransform.Translate(0, speed * Time.deltaTime, 0);
        }
    }
}
