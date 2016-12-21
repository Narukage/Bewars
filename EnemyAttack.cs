using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 5;


    Animator anim;
    GameObject Ninio;
    PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;


    void Awake ()
    {
        Ninio = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = Ninio.GetComponent <PlayerHealth> ();
        //enemyHealth = GetComponent<EnemyHealth>();
       anim = GetComponent <Animator> ();
    }


    void OnTriggerEnter2D (Collider2D other)
    {

        if (other.gameObject == Ninio)
        {
            playerInRange = true;
        }
    }


    void OnTriggerExit2D (Collider2D other)
    {
        if(other.gameObject == Ninio)
        {
           playerInRange = false;
        }
    }


    void Update ()
    {

        //Debug.Log(playerInRange);
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks && playerInRange /*&& enemyHealth.currentHealth > 0*/)
        {
            Attack ();
        }

        if(playerHealth.currentHealth <= 0)
        {
           anim.SetTrigger ("Dead");
        }
    }


    void Attack ()
    {
        timer = 0f;

        if(playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage (attackDamage);
        }
    }
}
