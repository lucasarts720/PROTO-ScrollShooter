using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOTHER : MonoBehaviour
{
    Rigidbody2D rb;
    public int vida, speed, dmg;
    public GameObject[] Obstacles;
    public Transform[] spawnpoint;
    public int minWait;
    public int maxWait;
    int objToSpawn, actualSpawnPoint;
    public LvlMgr lm;

    void Start()
    {
        StartCoroutine(spawntimer());
        rb = GetComponent<Rigidbody2D>();
        lm = FindObjectOfType<LvlMgr>();
    }
    private void Update()
    {
        rb.velocity = new Vector2(-speed * 0.25f, 0);

        if (vida <= 0)
        {
            Morir();
        }
    }

    public void PerderVida(int dmg)
    {
        vida = vida - dmg;
    }

    void Morir()
    {
        lm.bossIsActive = false;
        lm.jefesMuertos = lm.jefesMuertos + 1;
        lm.SpawnerActivate();
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            Player s_player = collision.gameObject.GetComponent<Player>();
            s_player.PerderVida(dmg);
        }

        if (collision.gameObject.CompareTag("Pared"))
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator spawntimer()
    {
        yield return new WaitForSeconds(Random.Range(minWait, maxWait));
        objToSpawn = Random.Range(0, Obstacles.Length);
        actualSpawnPoint = Random.Range(0, spawnpoint.Length);
        Instantiate(Obstacles[objToSpawn], spawnpoint[actualSpawnPoint]);
        StartCoroutine(spawntimer());
    }
}
