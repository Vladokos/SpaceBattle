using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;
using Toggle = UnityEngine.UI.Toggle;

public class ButtonsMenu : MonoBehaviour
{
    public List<Button> _Buttons;
    public Button[] HangarButtons;
    public List<Button> InformButtons;

    public Toggle musicON;

    public AudioSource _AudioSource;

    public List<RawImage> _RawImage;

    public GameObject _playerShipM1;

    public List<TextMeshProUGUI> _Text;
    public List<TextMeshProUGUI> InfoText;

    private Statistick _statistick;

    public List<GameObject> enemy;

    private int versionEnemy = 1;
    private int hpEnemy = 2;

    private ButtonAnim playBtn;
    private ButtonAnim infoBtn;
    private ButtonAnim hangarBtn;
    private ButtonAnim settingsBtn;
    private bool tapToplay;

    private ShipAnim _shipAnim;

    public List<Image> optionImage;
    public void Start()
    {
        _statistick = GameObject.Find("Statistick").GetComponent<Statistick>();

        playBtn = GameObject.Find("PlayButton").GetComponent<ButtonAnim>();
        infoBtn = GameObject.Find("Info").GetComponent<ButtonAnim>();
        hangarBtn = GameObject.Find("Hangar").GetComponent<ButtonAnim>();
        settingsBtn = GameObject.Find("OptionsButton ").GetComponent<ButtonAnim>();

        _shipAnim = GameObject.Find("Player_ship_m1").GetComponent<ShipAnim>();

        _AudioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {

        CheckStatText();
        if (tapToplay == true)
        {
            playBtn.movePos();
            infoBtn.movePos();
            hangarBtn.movePos();
            settingsBtn.movePos();
            _shipAnim.moveShip();
            _Buttons[6].gameObject.SetActive(false);
            _Text[6].gameObject.SetActive(false);
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Settings()
    {
        foreach (Button i in _Buttons)
        {
            i.gameObject.SetActive(false);
        }

        _Buttons[7].gameObject.SetActive(true);
        musicON.gameObject.SetActive(true);
        foreach (Image image in optionImage )
        {
            image.gameObject.SetActive(true);
        }
    }
    public void Resum()
    {
        foreach (Button i in _Buttons)
        {
            i.gameObject.SetActive(true);
        }

        musicON.gameObject.SetActive(false);

        _RawImage[0].gameObject.SetActive(false);
        _RawImage[1].gameObject.SetActive(false);

        _Buttons[2].gameObject.SetActive(false);
        _Buttons[5].gameObject.SetActive(false);
        _Buttons[7].gameObject.SetActive(false);

        InfoText[0].gameObject.SetActive(false);
        InfoText[1].gameObject.SetActive(false);

        versionEnemy = 1;
        hpEnemy = 2;

        foreach (GameObject e in enemy)
        {
            e.gameObject.SetActive(false);
        }

        foreach (Button b in HangarButtons)
        {
            b.gameObject.SetActive(false);
        }

        foreach (Button f in InformButtons)
        {
            f.gameObject.SetActive(false);
        }

        foreach (TextMeshProUGUI t in _Text)
        {
            t.gameObject.SetActive(false);
        }
        foreach (Image image in optionImage )
        {
            image.gameObject.SetActive(false);
        }

        Vector3 posShip = new Vector3(_playerShipM1.transform.position.x, _playerShipM1.transform.position.y, 93f);
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

        foreach (TextMeshProUGUI t in _Text)
        {
            t.gameObject.SetActive(true);
        }

        Vector3 posShip = new Vector3(_playerShipM1.transform.position.x, _playerShipM1.transform.position.y, 87f);
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

    public void LvlUpBraking()
    {
        if (_statistick.braking < 15)
        {
            _statistick.braking += 5;
            _statistick.BrakingNum = _statistick.braking;
            print(_statistick.BrakingNum);
            _Text[5].SetText("Braking  " + _statistick.BrakingNum);
        }
    }

    public void Inform()
    {
        _RawImage[2].gameObject.SetActive(true);

        foreach (Button i in _Buttons)
        {
            i.gameObject.SetActive(false);
        }

        foreach (Button f in InformButtons)
        {
            f.gameObject.SetActive(true);
        }

        InfoText[0].gameObject.SetActive(true);
        InfoText[1].gameObject.SetActive(true);
        _Buttons[5].gameObject.SetActive(true);
        enemy[0].gameObject.SetActive(true);
    }

    public void RightArrow()
    {
        if (versionEnemy < 6)
        {
            versionEnemy++;
            hpEnemy++;
            InfoText[0].SetText("v" + versionEnemy);
            InfoText[1].SetText("HP:" + hpEnemy);
        }

        switch (versionEnemy)
        {
            case 1:
                break;
            case 2:
                enemy[0].gameObject.SetActive(false);
                enemy[1].gameObject.SetActive(true);
                break;
            case 3:
                enemy[1].gameObject.SetActive(false);
                enemy[2].gameObject.SetActive(true);
                break;
            case 4:
                enemy[2].gameObject.SetActive(false);
                enemy[3].gameObject.SetActive(true);
                break;
            case 5:
                enemy[3].gameObject.SetActive(false);
                enemy[4].gameObject.SetActive(true);
                InfoText[1].SetText("HP:" + hpEnemy + "\n" + "Helper" + "\n" + "Hp:2" + "\n" );
                break;
            case 6:
                enemy[4].gameObject.SetActive(false);
                enemy[5].gameObject.SetActive(true);
                InfoText[0].SetText("Destroyer");
                InfoText[1].SetText("HP:" + "\n" + "1");
                break;
        }
    }

    public void LeftArrow()
    {
        if (versionEnemy != 7 && versionEnemy != 1)
        {
            versionEnemy--;
            hpEnemy--;
            InfoText[0].SetText("v" + versionEnemy);
            InfoText[1].SetText("HP:" + hpEnemy);
        }

        switch (versionEnemy)
        {
            case 1:
                enemy[0].gameObject.SetActive(true);
                enemy[1].gameObject.SetActive(false);
                break;
            case 2:
                enemy[1].gameObject.SetActive(true);
                enemy[2].gameObject.SetActive(false);
                break;
            case 3:
                enemy[2].gameObject.SetActive(true);
                enemy[3].gameObject.SetActive(false);
                break;
            case 4:
                enemy[3].gameObject.SetActive(true);
                enemy[4].gameObject.SetActive(false);
                break;
            case 5:
                enemy[4].gameObject.SetActive(true);
                enemy[5].gameObject.SetActive(false);
                InfoText[1].SetText("HP:" + hpEnemy + "\n" + "Helper" + "\n" + "Hp:2" + "\n");
                break;
            case 6:
                enemy[4].gameObject.SetActive(false);
                enemy[5].gameObject.SetActive(true);
                InfoText[0].SetText("Destroyer");
                InfoText[1].SetText("HP:" + "\n" + "1");
                break;
        }
    }

    public void CheckStatText()
    {
        _Text[2].SetText("" + _statistick.dm);
        _Text[3].SetText("Hp  " + _statistick.HpNum);
        _Text[4].SetText("Speed  " + _statistick.SpeedNum);
        _Text[5].SetText("Braking  " + _statistick.BrakingNum);
    }

    public void TapToPlay()
    {
        tapToplay = true;
        _AudioSource.Play();

    }
}
