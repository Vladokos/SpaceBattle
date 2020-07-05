using System.Collections;
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

    public List<Toggle> _toggle;

    public AudioSource _AudioSource;

    public List<RawImage> _RawImage;

    public GameObject _playerShipM1;

    public List<TextMeshProUGUI> _Text;
    public List<TextMeshProUGUI> InfoText;

    private Statistick _statistick;

    public List<GameObject> enemy;

    private int versionEnemy = 1;
    private int hpEnemy = 2;

    public List<Image> optionImage;

    public GameObject singIn;

    public List<Animator> _animator;

    private int a;
    public void Start()
    {
        _statistick = GameObject.Find("Statistick").GetComponent<Statistick>();

        _AudioSource = GetComponent<AudioSource>();

    }

    public void Update()
    {
        CheckStatText();
    }
    //Загружает сцену с игрой
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }
    //Открывает настройки делает кнопки и анимацию активными
    public void Settings()
    {
        foreach (Button i in _Buttons)
        {
            i.gameObject.SetActive(false);
        }

        singIn.SetActive(true);
        _Buttons[6].gameObject.SetActive(true);
        _toggle[0].gameObject.SetActive(true);
        _toggle[1].gameObject.SetActive(true);

        foreach (Image image in optionImage)
        {
            image.gameObject.SetActive(true);
        }

        _animator[0].SetBool("SettingsOpen", true);
        _animator[1].SetBool("SettingsOpen", true);
    }
    //Кнопка крестик - делает объекты и анимацию не активной но кнопки в гл мнею активными
    public void Close()
    {

        _animator[0].SetBool("SettingsOpen", false);
        _animator[1].SetBool("SettingsOpen", false);

        StartCoroutine(setActivFlase());
    }
    IEnumerator setActivFlase()
    {
        yield return new WaitForSeconds(1.3f);

        _animator[0].SetBool("IsDone", true);
        _animator[1].SetBool("IsDone", true);

        singIn.SetActive(false);

        _toggle[0].gameObject.SetActive(false);
        _toggle[1].gameObject.SetActive(false);

        foreach (Image image in optionImage)
        {
            image.gameObject.SetActive(false);
        }

        ResumArrow();

    }
    //Кнопка стрелочки выхода - делает объекты  не активной но кнопки в гл мнею активными

    //сделать для стрелки ангара
    public void ResumArrowHangar()
    {
        _animator[2].SetBool("IsOpen", false);
        _animator[3].SetBool("IsOpen", false);
        _animator[4].SetBool("IsOpen", false);
        _animator[5].SetBool("IsOpen", false);
        _animator[6].SetBool("IsOpen", false);

        StartCoroutine(outHangar());
    }
    IEnumerator outHangar()
    {
        yield return new WaitForSeconds(1.5f);
        _animator[2].SetBool("AnimEnd", true);
        _animator[3].SetBool("AnimEnd", true);
        _animator[4].SetBool("AnimEnd", true);
        _animator[5].SetBool("AnimEnd", true);
        _animator[6].SetBool("AnimEnd", true);

        foreach (Button b in HangarButtons)
        {
            b.gameObject.SetActive(false);
        }

        foreach (TextMeshProUGUI t in _Text)
        {
            t.gameObject.SetActive(false);
        }

        _Buttons[2].gameObject.SetActive(false);

        _RawImage[0].gameObject.SetActive(false);

        cHangar();
    }
    public void cHangar()
    {
        foreach (Button i in _Buttons)
        {
            i.gameObject.SetActive(true);
        }


        _RawImage[1].gameObject.SetActive(false);

        _Buttons[5].gameObject.SetActive(false);

        _Buttons[2].gameObject.SetActive(false);

        _Buttons[6].gameObject.SetActive(false);

        InfoText[0].gameObject.SetActive(false);
        InfoText[1].gameObject.SetActive(false);

        versionEnemy = 1;
        hpEnemy = 2;

        foreach (GameObject e in enemy)
        {
            e.gameObject.SetActive(false);
        }

        foreach (Button f in InformButtons)
        {
            f.gameObject.SetActive(false);
        }
    }

    IEnumerator outInfo()
    {
        yield return new WaitForSeconds(2f);
        _animator[7].SetBool("End", true);
        _animator[8].SetBool("End", true);
        _animator[9].SetBool("End", true);


        foreach (Button i in _Buttons)
        {
            i.gameObject.SetActive(true);
        }


        _RawImage[1].gameObject.SetActive(false);

        _Buttons[5].gameObject.SetActive(false);

        _Buttons[2].gameObject.SetActive(false);

        _Buttons[6].gameObject.SetActive(false);

        InfoText[0].gameObject.SetActive(false);
        InfoText[1].gameObject.SetActive(false);

        versionEnemy = 1;
        hpEnemy = 2;

        foreach (GameObject e in enemy)
        {
            e.gameObject.SetActive(false);
        }

        foreach (Button f in InformButtons)
        {
            f.gameObject.SetActive(false);
        }
    }
    public void ResumArrow()
    {
        StartCoroutine(outInfo());


        _animator[7].SetBool("Open", false);
        _animator[8].SetBool("Open", false);
        _animator[9].SetBool("Open", false);


        Vector3 posShip = new Vector3(_playerShipM1.transform.position.x, _playerShipM1.transform.position.y, 93f);
        _playerShipM1.transform.position = posShip;
    }
    //Вкл/Выкл музыки
    public void SoundOff()
    {
        if (_toggle[0].isOn)
        {
            _AudioSource.Play();
            _statistick.musickToggle = true;
        }
        else
        {
            _AudioSource.Stop();
            _statistick.musickToggle = false;
        }
    }
    public void EffectToggle()
    {
        if (_toggle[1].isOn)
        {
            _statistick.effectToggle = true;
        }
        else
        {
            _statistick.effectToggle = false;
        }
    }
    //Открывает ангар делает нужыне кнопки активными другие нет 
    public void Hangar()
    {
        /*Vector3 posShip = new Vector3(_playerShipM1.transform.position.x,-7.53f, 79f);
        _playerShipM1.transform.position = posShip;*/

        foreach (Button i in _Buttons)
        {
            i.gameObject.SetActive(false);
        }

        _RawImage[0].gameObject.SetActive(true);
        _Buttons[2].gameObject.SetActive(true);
        foreach (Button b in HangarButtons)
        {
            b.gameObject.SetActive(true);
        }

        foreach (TextMeshProUGUI t in _Text)
        {
            t.gameObject.SetActive(true);
        }

        _animator[2].SetBool("IsOpen",true);
        _animator[3].SetBool("IsOpen", true);
        _animator[4].SetBool("IsOpen", true);
        _animator[5].SetBool("IsOpen", true);
        _animator[6].SetBool("IsOpen", true);


        _animator[4].SetBool("AnimEnd", false);
    }
    //дмг +
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
    //хп +
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
    //скорость +
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
    //тормозной путь -
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
    //Открывает инфвормацию о врагах и делает нужыне кнопки активными другие нет
    public void Inform()
    {
        _RawImage[1].gameObject.SetActive(true);

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


        _animator[7].SetBool("Open", true);
        _animator[8].SetBool("Open", true);
        _animator[9].SetBool("Open", true);
    }

    //Стрелка для перемещения в inform
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
    //Стрелка для перемещения в inform
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
    //Проверка на значение в Statick 
    public void CheckStatText()
    {
        _Text[2].SetText("" + _statistick.dm);
        _Text[3].SetText("Hp  " + _statistick.HpNum);
        _Text[4].SetText("Speed  " + _statistick.SpeedNum);
        _Text[5].SetText("Braking  " + _statistick.BrakingNum);
    }
}
