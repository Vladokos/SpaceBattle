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
    public Animator fireEngine;
     
    private GameObject player;
    private PlayerControllers pC;

    public GameObject _fireEngine;
    
    public ParticleSystem explosion;
    // Start is called before the first frame update
    void Start()
    {
        enemyHp = hp;
        
        pC = GameObject.Find("Player").GetComponent<PlayerControllers>();
        player = GameObject.Find("Player");
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
                pC.enemyDestroy = true;
                bC.enabled = false;
                StartCoroutine(DestroyEnemy());
                explosion.gameObject.SetActive(true);
                explosion.Play();
                speed = 0;
            }
        }
        if (collision.gameObject.CompareTag("Player") )
        {
            StartCoroutine(DestroyEnemy());
            explosion.gameObject.SetActive(true);
            explosion.Play();
        }

        if (collision.gameObject.CompareTag("DetectColl"))
        {
            Destroy(gameObject);
        }

    }
    //Уменьшение здоровья 
    void Dm(int dm)
    {
        enemyHp -= dm;
    }
    //Уничтожение через неск. сек. чтобы успела анимация проиграться
    IEnumerator DestroyEnemy()
    { 
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
    //Если есть игрок на сцене то летит на него
    void Charge()
    {
        if (player != null && hp == 1)
        {
            Vector3 charge = (player.transform.position - transform.position).normalized;
            rB2D.AddForce(charge * speed);
            _fireEngine.gameObject.SetActive(true);
            fireEngine.SetBool("move",true);
        }
    }
}
