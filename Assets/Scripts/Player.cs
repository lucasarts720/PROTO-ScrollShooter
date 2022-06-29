using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public int velocidad, vida, vidaMaxima;
    public Transform cañon;
    public Projectil projectil;
    public LvlMgr lm;
    public bool isShielded = true;
    public GameObject shield;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lm = FindObjectOfType<LvlMgr>();
        vida = vidaMaxima;
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Disparar();
        }
        if (vida <= 0)
        {
            Morir();
        }
    }
    
    void Movimiento()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        Vector2 movimiento = new Vector2(inputX, inputY);
        rb.transform.Translate(movimiento * velocidad * Time.deltaTime);
    }

    void Disparar()
    {
        Instantiate(projectil, cañon.position, transform.rotation);
    }

    public void PerderVida(int dmg)
    {
        if (isShielded)
        {
            shield.gameObject.SetActive(false);
            isShielded = !isShielded;
        }
        else
        {
            vida = vida - dmg;
        }
    }
    void Morir()
    {
        lm.EndGame();
    }
}
