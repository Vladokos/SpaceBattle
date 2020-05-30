using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestrroyer : MonoBehaviour
{
    public int hp;
    public int enemyHp;

    private float speed = 20f;
    
    public BoxCollider2D bC;
    public Rigidbody2D rB2D;
    public Animator enemyAnimator,fireEngine;
     
    private GameObject player;
    private PlayerControllers pC;
    private Vector3 playerPos;

    private Vector3 enemyPos;

    public GameObject _fireEngine;
    // Start is called before the first frame update
    void Start()
    {
        enemyHp = hp;
        
        pC = GameObject.Find("Player").GetComponent<PlayerControllers>();
        player = GameObject.Find("Player");

        playerPos = pC.transform.position;
        enemyPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Charge();
    }
    //Если дотронулся пуля игрока то отнимается жизнь || eсли дотрагивается до игрока то вызрывается 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LaserBullet"))
        {
            Dm(1);
            Destroy(collision.gameObject);
            if(enemyHp < 1 )
            {
                enemyAnimator.SetBool("ded", true);
                pC.enemyDestroy = true;
                bC.enabled = false;
                StartCoroutine(DestroyEnemy());
            }
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DestroyEnemy());
            enemyAnimator.SetBool("ded", true);
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
    //Если есть игрок на сцене то летит на него
    void Charge()
    {
        if (player != null)
        {
            Vector3 charge = (playerPos - enemyPos).normalized;
            rB2D.AddForce(charge * speed);
            _fireEngine.gameObject.SetActive(true);
            fireEngine.SetBool("move",true);
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
