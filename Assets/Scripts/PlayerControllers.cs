using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllers : MonoBehaviour
{
    public float horInput;
    public float verInput;
    private float xRange = 7f;
    private float yRange = 11f;
    private float speedX;
    private float speedY;

    public Rigidbody2D rb2d;

    public GameObject bullet;
    public GameObject fireEngine;
    private Vector3 bulletVector;

    public Animator fireAnim;

    public TextMeshProUGUI scoreT;
    public int score;

    public bool enemyDestroy = false;

    public AudioSource shot;
    public AudioSource boom;

    public int hp;
    public int playerHp;

    public Button restartButton;

    public float timeShoot, coolDownd;
    public bool _gameOver = false;

    private GameObject explosion;
    private Vector3 positionExplosion;

    private Statistick _statistick;

    private Buttons _buttons;
    void Start()
    {
        explosion = GameObject.Find("Explosion");

        rb2d = GetComponent<Rigidbody2D>();

        _statistick = GameObject.Find("Statistick").GetComponent<Statistick>();

        playerHp = _statistick.HpNum;

        _buttons = GameObject.Find("UIManager").GetComponent<Buttons>();
    }

    void FixedUpdate()
    {
        UpdateScore();
        InvisibleWall();
        Reload();
        MovePlayer();
        bulletVector = new Vector3(transform.position.x - 0.055f, transform.position.y + 1f, transform.position.z);
    }
    //Движение игрока
    void MovePlayer()
    {
        Vector2 asd = new Vector2(speedX, speedY);
        rb2d.AddForce(asd.normalized * _statistick.SpeedNum * Time.fixedDeltaTime);
    }
    //Кнопка вверх
    public void UpArrow()
    {
        if (_gameOver == false)
        {
            speedY = verInput * Time.deltaTime;
            fireEngine.SetActive(true);
            fireAnim.SetBool("ArrowcClick", true);
            rb2d.drag = 0f;
        }
    }
    //Кнопка вниз
    public void DownArrow()
    {
        if (_gameOver == false)
        {
            speedY = -verInput * Time.deltaTime;
            fireEngine.SetActive(true);
            fireAnim.SetBool("ArrowcClick", true);
            rb2d.drag = 0f;
        }
    }
    //Кнопка влево
    public void LeftArrow()
    {
        if (_gameOver == false)
        {
            speedX = -horInput * Time.deltaTime;
            fireEngine.SetActive(true);
            fireAnim.SetBool("ArrowcClick", true);
            rb2d.drag = 0f;
        }
    }
    //Кнопка впрво
    public void RightArrow()
    {
        if (_gameOver == false)
        {
            speedX = horInput * Time.deltaTime;
            fireEngine.SetActive(true);
            fireAnim.SetBool("ArrowcClick", true);
            rb2d.drag = 0f;
        }
    }
    // кнопка выстрела
    public void fireArrow()
    {
        //Если время выстрела(timeShoot) <= 0 то можно произвести выстрел && игра не проиграна
        if (timeShoot <= 0 && _gameOver == false)
        {
            timeShoot = coolDownd;
            Instantiate(bullet, bulletVector, transform.rotation);
            shot.Play();
        }
    }
    //Во время поднимание кнопки игрок останав. и анимация
    public void Stop()
    {
        speedX = 0;
        speedY = 0;
        fireAnim.SetBool("ArrowcClick", false);
        fireEngine.SetActive(false);
        rb2d.drag = _statistick.BrakingNum;
    }

    //Если умирает враг +1 очко
    void UpdateScore()
    {
        scoreT.SetText("" + score);
        if (enemyDestroy == true)
        {
            score++;
            boom.Play();
            enemyDestroy = false;
        }
    }
    //Проверка на столконевение с пулей врага и дестроуером
    //И проверка здорвье
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            Dm(1);
        }
        if (playerHp < 1 || collision.gameObject.CompareTag("Destroyer"))
        {
            _gameOver = true;

            Destroy(gameObject);
            positionExplosion = new Vector3(transform.position.x, transform.position.y, -46f);
            Instantiate(explosion, positionExplosion, Quaternion.identity);

            boom.Play();
            _buttons.PauseButton();
            _buttons._Buttons[0].gameObject.SetActive(false);
        }
    }
    //Снижение здоровья
    void Dm(int dm)
    {
        playerHp -= dm;
    }
    //прочитай название
    void InvisibleWall()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }
        if (transform.position.y > yRange + 4f)
        {
            transform.position = new Vector3(transform.position.x, yRange + 4f, transform.position.z);
        }
    }
    // Если время выстрела(timeShoot) > 0 то его уменьшают с помошью Time.deltaTime
    private void Reload()
    {
        if (timeShoot > 0)
        {
            timeShoot -= Time.deltaTime;
        }
    }
}
