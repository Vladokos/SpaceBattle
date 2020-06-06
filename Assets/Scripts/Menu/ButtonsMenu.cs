using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsMenu : MonoBehaviour
{
    public List<Button> _Buttons;
    public List<Button> HangarButtons;

    public Toggle musicON;
    
    public  AudioSource  _AudioSource;

    public List<RawImage> _RawImage;
    
    public GameObject _playerShipM1;

    public List<TextMeshProUGUI> _Text;
    
    private Statistick _statistick;

    public void Start()
    {
        _statistick = GameObject.Find("Statistick").GetComponent<Statistick>();
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
        DontDestroyOnLoad(_AudioSource);
        DontDestroyOnLoad(_statistick);
    }
    public void Settings()
    {
        /*_Buttons[0].gameObject.SetActive(false);
        _Buttons[1].gameObject.SetActive(false);
        _Buttons[3].gameObject.SetActive(false);
        _Buttons[4].gameObject.SetActive(false);*/
        foreach (Button i in _Buttons)
        {
            i.gameObject.SetActive(false);
        }
        _Buttons[2].gameObject.SetActive(true);
        musicON.gameObject.SetActive(true);
        _RawImage[0].gameObject.SetActive(true);
    }
    public void Resum()
    {
        /*_Buttons[0].gameObject.SetActive(true);
        _Buttons[1].gameObject.SetActive(true);
        _Buttons[3].gameObject.SetActive(true);
        _Buttons[4].gameObject.SetActive(true);*/
        foreach (Button i in _Buttons)
        {
            i.gameObject.SetActive(true);
        }
        musicON.gameObject.SetActive(false);
        _RawImage[0].gameObject.SetActive(false);
        _RawImage[1].gameObject.SetActive(false);
        _Buttons[2].gameObject.SetActive(false);
        _Buttons[5].gameObject.SetActive(false);
        foreach (Button b in HangarButtons)
        {
            b.gameObject.SetActive(false);
        }
        foreach (TextMeshProUGUI t in _Text)
        {
            t.gameObject.SetActive(false);
        }
        
        Vector3 posShip = new Vector3(_playerShipM1.transform.position.x,_playerShipM1.transform.position.y,93f);
        _playerShipM1.transform.position = posShip;
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

    public void Hangar()
    {
        foreach (Button i in _Buttons)
        {
            i.gameObject.SetActive(false);
        }
        _RawImage[1].gameObject.SetActive(true);
        _Buttons[5].gameObject.SetActive(true);
        foreach (Button b in HangarButtons)
        {
            b.gameObject.SetActive(true);
        }
        /*HangarButtons[0].gameObject.SetActive(true);
        HangarButtons[1].gameObject.SetActive(true);
        HangarButtons[2].gameObject.SetActive(true);*/
        foreach (TextMeshProUGUI t in _Text)
        {
            t.gameObject.SetActive(true);
        }
        
        Vector3 posShip = new Vector3(_playerShipM1.transform.position.x,_playerShipM1.transform.position.y,90f);
        _playerShipM1.transform.position = posShip;
    }

    public void LvlUpDamage()
    {
        if (_statistick.dmNum < 3)
        {
            _statistick.dm++;
            _statistick.dmNum = _statistick.dm;
            Debug.Log(_statistick.dmNum);
            _Text[2].SetText("" + _statistick.dmNum);   
        }
    }
    public void LvlUpHp()
    {
        if (_statistick.HpNum < 9)
        {
            _statistick.Hp++;
            _statistick.HpNum = _statistick.Hp;
            Debug.Log(_statistick.HpNum);
            _Text[3].SetText("Hp  " + _statistick.HpNum);
        }
    }
    public void LvlUpSpeed()
    {
        if (_statistick.speed < 350)
        {
            _statistick.speed += 50;
            _statistick.SpeedNum = _statistick.speed;
            print(_statistick.SpeedNum);
            _Text[4].SetText("Speed  " + _statistick.SpeedNum);
        }
    }
}
