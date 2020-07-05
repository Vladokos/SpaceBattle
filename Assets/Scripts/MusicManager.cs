using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private Statistick _statistick;

    public List<AudioSource> audioS;
    // Start is called before the first frame update
    void Start()
    {
        _statistick = GameObject.Find("Statistick").GetComponent<Statistick>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_statistick.musickToggle == false)
        {
            audioS[0].gameObject.SetActive(false);
        }
        if(_statistick.effectToggle == false)
        {
            audioS[1].Stop();
            audioS[2].Stop();
        }
    }
}
