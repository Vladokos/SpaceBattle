using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public bool gameStart;

    private float spawnPosX = 6f;
    private float spawnPosY = 3f;

    public List<GameObject> enemesPref;
    
    private PlayerControllers _playerControllers;
    void Start()
    {
        gameStart = true;
        Invoke("SpawnShip", 3f);
        _playerControllers = GameObject.Find("Player").GetComponent<PlayerControllers>();
    }
    
    private void FixedUpdate()
    {

    }
    //Спавн рандомных врагов  каждые 3 секунды в рандомном полезрения камеры
    void SpawnShip()
    {
        int randomShip = Random.Range(0, enemesPref.Count);
        Vector2 randomSpawn = new Vector2 (Random.Range(-spawnPosX, spawnPosX), Random.Range(spawnPosY, spawnPosY + 7f));
        if(gameStart == true && _playerControllers._gameOver == false)
        {
            Instantiate(enemesPref[randomShip], randomSpawn,Quaternion.identity);
        }
        else
        {
            Debug.LogError("no");
        }
        Invoke("SpawnShip", 3f);

    }
    // выполняет перезагрузку сцены
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
