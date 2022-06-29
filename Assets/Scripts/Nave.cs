using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    Rigidbody2D rb;
    public int vida, speed, dmg;
    public LvlMgr lm;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lm = FindObjectOfType<LvlMgr>();
    }
    private void Update()
    {
        rb.velocity = new Vector2(-speed, 0);

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
        lm.bajas = lm.bajas + 1;
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
}
