using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsMenu : MonoBehaviour
{
    public List<Button> _Buttons;

    public Toggle musicON;
    
    public  AudioSource  _AudioSource;

    public RawImage _RawImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
        DontDestroyOnLoad(_AudioSource);

    }
    public void Settings()
    {
        _Buttons[0].gameObject.SetActive(false);
        _Buttons[1].gameObject.SetActive(false);
        _Buttons[2].gameObject.SetActive(true);
        musicON.gameObject.SetActive(true);
        _RawImage.gameObject.SetActive(true);
    }
    public void Resum()
    {
        _Buttons[0].gameObject.SetActive(true);
        _Buttons[1].gameObject.SetActive(true);
        _Buttons[2].gameObject.SetActive(false);
        musicON.gameObject.SetActive(false);
        _RawImage.gameObject.SetActive(false);
    }
    public void SoundOff()
    {
        if (musicON.isOn)
        { 
            _AudioSource.Play();
        }
        else
        {
            _AudioSource.Stop();
        }
    }
}
