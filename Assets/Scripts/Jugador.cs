using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{

    public int velocidad;
    public int fuerzaSalto;
    public bool facingRight;

    private Rigidbody2D fisica;

    private void Awake()
    {
        facingRight = true;
        fisica = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Movimiento();
        Salto();
        Giro();
        //DobleSalto();     

    }

    private bool TocaSuelo()
    {
        RaycastHit2D toca = Physics2D.Raycast(transform.position + new Vector3(0, -2f, 0), Vector3.down, 0.2f);
        return toca.collider != null;
    }

    private void Movimiento()
    {
        float entradaX = Input.GetAxis("Horizontal");
        fisica.velocity = new Vector2(entradaX * velocidad, fisica.velocity.y);
    }

    private void Salto()
    {
        if (Input.GetKeyDown(KeyCode.Space) && TocaSuelo())
        {
            fisica.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }

    private void Giro()
    {
        if(fisica.velocity.x > 0.1 && !facingRight) Flip();
        if (fisica.velocity.x < -0.1 && facingRight) Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
