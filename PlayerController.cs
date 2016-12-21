using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpHeight;
    private Animator anim;
    private bool faceRight;
    private bool isGrounded;
    //private bool Attacked;
    private bool atacar;
    public Text score;
    public int puntuacion = 0;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        faceRight = true;
        score.text = puntuacion.ToString();
        // Attacked = true;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Platform" || collider.gameObject.tag == "Floor" || collider.gameObject.tag == "Ghost" || collider.gameObject.tag == "Bat"
        || collider.gameObject.tag == "Torch" || collider.gameObject.tag == "Coin" || collider.gameObject.tag == "Spikes")
        {
            isGrounded = true;
            if (collider.gameObject.tag == "Coin")
            {
                puntuacion++;
                score.text = puntuacion.ToString();
            }
        }
        else
        {
            isGrounded = false;
        }
        anim.SetBool("isGrounded", isGrounded);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Attacked);

        float horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            isGrounded = false;
            anim.SetBool("isGrounded", isGrounded);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            atacar = true;
            /*Attacked = false;
            anim.SetBool("Attacked", Attacked);*/
            anim.SetBool("atacar", atacar);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            atacar = false;
            anim.SetBool("atacar", atacar);
        }

        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        Flip(horizontal);
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !faceRight || horizontal < 0 && faceRight)
        {
            faceRight = !faceRight;

            Vector2 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    /*void activarAtaque()
    {
        Attacked = true;
        anim.SetBool("Attacked", Attacked);
    }*/
}
