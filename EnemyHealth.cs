using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Animator anim;
    public int vida = 1;
    SineWaveMovement batMovement;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        batMovement = GetComponent<SineWaveMovement>();

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Sword")
        {
            vida--;
            if (vida <= 0)
            {
                batMovement.enabled = false;
                anim.SetTrigger("Dead");
                Invoke("Dead", 2f);
            }
        }
    }

    void Dead()
    {
        Destroy(this.gameObject);
    }

}
