using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    private PlayerControllers _playerControllers;
    private Statistick _statistick;
    private MusicManager _musicManager;


    public List<Button> _Buttons;

    public RawImage pauseImage;

    public GameObject settings;

    public List<Slider> sliders;

    private float musVolume;
    void Start()
    {
        _playerControllers = GameObject.Find("Player").GetComponent<PlayerControllers>();
        _statistick = GameObject.Find("Statistick").GetComponent<Statistick>();
        _musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();

        sliders[0].value = _statistick.musickVolume;
    }

    public void PauseButton()
    {
        _playerControllers.restartButton.gameObject.SetActive(true);
        _playerControllers._gameOver = true;

        _Buttons[1].gameObject.SetActive(false);

        pauseImage.gameObject.SetActive(true);

        _Buttons[0].gameObject.SetActive(true);
        _Buttons[3].gameObject.SetActive(true);
        _Buttons[4].gameObject.SetActive(true);
    }

    public void Resum()
    {
        _playerControllers.restartButton.gameObject.SetActive(false);
        _playerControllers._gameOver = false;

        _Buttons[1].gameObject.SetActive(true);

        pauseImage.gameObject.SetActive(false);

        _Buttons[0].gameObject.SetActive(false);
        _Buttons[3].gameObject.SetActive(false);
        _Buttons[4].gameObject.SetActive(false);
    
    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void SettingsBtn()
    {
        settings.gameObject.SetActive(true);
        foreach(Button sB in _Buttons )
        {
            sB.gameObject.SetActive(false);
        }
    }

    public void MusicSlider()
    {
        musVolume = sliders[0].value;
        _musicManager.audioS[0].volume = musVolume;
        _statistick.musickVolume = musVolume;
    }



    public void closeBtn()
    {
        settings.gameObject.SetActive(false);
        foreach (Button sB in _Buttons)
        {
            sB.gameObject.SetActive(true);
        }
        _Buttons[1].gameObject.SetActive(false);
    } 



}
