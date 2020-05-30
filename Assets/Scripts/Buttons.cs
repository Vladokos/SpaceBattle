using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using  UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    private PlayerControllers _playerControllers;

    public List<Button> _Buttons;
    public Toggle _Toggle;

    public RawImage pauseImage;

    public AudioSource _AudioSource;
    void Start()
    {
        _playerControllers = GameObject.Find("Player").GetComponent<PlayerControllers>();
    }

    public  void PauseButton()
    {
        _playerControllers.restartButton.gameObject.SetActive(true);
        _playerControllers._gameOver = true;
        _Buttons[1].gameObject.SetActive(false);
        pauseImage.gameObject.SetActive(true);
        _Buttons[0].gameObject.SetActive(true);
        _Buttons[3].gameObject.SetActive(true);
    }

    public void Resum()
    {
        _playerControllers.restartButton.gameObject.SetActive(false);
        _playerControllers._gameOver = false;
        _Buttons[1].gameObject.SetActive(true);
        pauseImage.gameObject.SetActive(false);
        _Buttons[0].gameObject.SetActive(false);
        _Buttons[3].gameObject.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuScene");
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
      _Toggle.gameObject.SetActive(true);
    }

    public void _Resum()
    {
        _Buttons[0].gameObject.SetActive(true);
        _Buttons[1].gameObject.SetActive(true);
        _Buttons[2].gameObject.SetActive(false);
        _Toggle.gameObject.SetActive(false);
    }

    public void SoundOff()
    {
        if (_Toggle.isOn)
      { 
          _AudioSource.Play();
      }
        else
        {
            _AudioSource.Stop();
        }
    }
}
