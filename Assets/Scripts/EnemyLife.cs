using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyLife : MonoBehaviour
{
    public int hp;
    public int enemyHp;

    public Animator enemyAnimator;
    public bool explosinBool = false;

    public BoxCollider2D bC,bc2;
    public Rigidbody2D rB2D;

    private PlayerControllers pC;
    private SpawnManager sM;

    private GameObject player;

    private float fire = 4f;
    public float firstFire = 1.0f;

    public GameObject enemyBullet;
    
    public float timeShoot,coolDownd;
    // Start is called before the first frame update
    void Start()
    {
        enemyHp = hp;
        
        pC = GameObject.Find("Player").GetComponent<PlayerControllers>();
        bC = GetComponent<BoxCollider2D>();
        sM = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        rB2D = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Shoot();
    }
    //Если дотронулся пуля игрока то отнимается жизнь
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LaserBullet"))
        {
            Dm(1);
            Destroy(collision.gameObject);
            if(enemyHp < 1)
            {
                StartCoroutine(DestroyEnemy());
                pC.enemyDestroy = true;
                explosinBool = true;
                enemyAnimator.SetBool("1", true);
                bC.enabled = false;
                bc2.enabled = false;
            }
        }
        //Если дотрагивается игрок то физика будет Kinematic чтоб игрок не мог толкать врага
        if (collision.gameObject.CompareTag("Player"))
        {
            rB2D.bodyType = RigidbodyType2D.Kinematic;
        }
    }
    //Уменьшение здоровья 
    void Dm(int dm)
    {
        enemyHp -= dm;
    }
    //Уничтожение через 1.3 сек чтобы успела анимация проиграться
    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(1.3f);
        Destroy(gameObject);
    }
    //Вермя через которое может выстрелить враг(не работает надо исправить)
    void Shoot()
    {
        if (timeShoot <= 0 && pC._gameOver == false)
        {
            timeShoot = coolDownd;
            Instantiate(enemyBullet, transform.position,Quaternion.identity);
        }
        if (timeShoot > 0)
        {
            timeShoot -= Time.deltaTime;
        }
    }
// Если выйдет из бэкграунда удалиться 
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BackGround"))
        {
            StartCoroutine(DestroyEnemy());
        }
    }
}
