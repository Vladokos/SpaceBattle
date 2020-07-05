using UnityEngine;

public class Statistick : MonoBehaviour
{
    public int dm = 1;
    public int dmNum;

    public int Hp = 3;
    public int HpNum;

    public float speed = 150;
    public float SpeedNum;

    public float braking = 5f;
    public float BrakingNum;

    public bool musickToggle = true;
    public bool effectToggle = true;

    private void Awake()
    {
        int numStaticsPlayer = FindObjectsOfType<Statistick>().Length;
        if (numStaticsPlayer != 1)
        {
            Destroy(this.gameObject);
        }
        // if more then one music player is in the scene
        //destroy ourselves
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }
    private void Update()
    {
        print(effectToggle);
    }
}
