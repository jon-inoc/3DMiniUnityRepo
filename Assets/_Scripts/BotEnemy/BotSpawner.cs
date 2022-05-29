using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSpawner : MonoBehaviour
{
    public GameObject[] BotEnemies;
    // Start is called before the first frame update

    private void OnEnable()
    {
        GameManager.onLevelStart += GameStart;
    }

    private void OnDisable()
    {
        GameManager.onLevelStart -= GameStart;
    }

    void GameStart()
    {
        InvokeRepeating("Spawn", 0f, 5f);
    }

    void Spawn() 
    {
        int i = Random.Range(0, BotEnemies.Length - 1);
        Instantiate(BotEnemies[i], transform.position, transform.rotation);
    }
}
