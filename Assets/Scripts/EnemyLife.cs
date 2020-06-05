using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyLife : MonoBehaviour
{
    public int hp;
    public int enemyHp;
    public int dm = 1;

    public BoxCollider2D bC,bc2;
    public Rigidbody2D rB2D;

    private PlayerControllers pC;
    
    public GameObject enemyBullet;
    
    public float timeShoot,coolDownd;
    
    private GameObject explosion;

    private Vector3 _position;

    private Statistick _statistick;
    // Start is called before the first frame update
    void Start()
    {
        enemyHp = hp;
        
        pC = GameObject.Find("Player").GetComponent<PlayerControllers>();
        _statistick = GameObject.Find("Statistick").GetComponent<Statistick>();
        bC = GetComponent<BoxCollider2D>();
        rB2D = GetComponent<Rigidbody2D>();
        
        _position = new Vector3(transform.position.x,transform.position.y,-38f);
        explosion = GameObject.Find("Explosion");
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
            Dm();
            Destroy(collision.gameObject);
            if(enemyHp < 1)
            {
                StartCoroutine(DestroyEnemy());
                pC.enemyDestroy = true;
                bC.enabled = false;
                bc2.enabled = false;
                Instantiate(explosion,_position, Quaternion.identity);
            }
        }
        //Если дотрагивается игрок то физика будет Kinematic чтоб игрок не мог толкать врага
        if (collision.gameObject.CompareTag("Player"))
        {
            rB2D.bodyType = RigidbodyType2D.Kinematic;
        }
    }
    //Уменьшение здоровья 
    void Dm()
    {
        enemyHp -= _statistick.dm;
    }
    //Уничтожение через неск. сек. чтобы успела анимация проиграться
    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
    //Вермя через которое может выстрелить враг
    void Shoot()
    {
        if (timeShoot <= 0 && pC._gameOver == false)
        {
            timeShoot = coolDownd;
            Instantiate(enemyBullet, transform.position,Quaternion.identity);
        }
        if (timeShoot > 0 && pC._gameOver == false)
        {
            timeShoot -= Time.deltaTime;
        }
    }
}
