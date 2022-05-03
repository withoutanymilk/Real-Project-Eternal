using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bHealthNExtras : MonoBehaviour
{
    //animation
    public Animator anime;
    //Health stuffs
    public int cHealth = 0;
    public int maxHealth;
    //Attacking things
    public Transform attackPoint1;
    public Transform attackPoint2;
    public Transform attackPoint3;
    public float attackRange = 1.5f;
    public LayerMask playerLayer;
    public int attackDamage = 30;
    //walking things
    public GameObject walker;



    // Start is called before the first frame update
    void Start()
    {
        cHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int dmg)
    {
        cHealth -= dmg;
        Debug.Log("BOSS WAS HIT FOR: " + dmg);

        if (cHealth > (maxHealth*2/3))
        {
            return; //stage1 already
        }
        else if (cHealth > (maxHealth/3) && cHealth <= (maxHealth * 2 / 3))
        {
            //play intro2 only once
            //then continue with stage2 
        }
        else if (cHealth <= (maxHealth / 3))
        {
            /*isStage1 = false;
            isStage2 = false;
            isStage3 = true;*/

        }
        if (cHealth <= 0)
        {
            /*isStage1 = false;
            isStage2 = false;
            isStage3 = false;
            DeadState();*/
        }
    }



    public void atkDmg()
    {
        anime.ResetTrigger("Attack");
        bool hasHit = false;
        Collider2D[] hitZone1 = Physics2D.OverlapCircleAll(attackPoint1.position, attackRange, playerLayer);
        Collider2D[] hitZone2 = Physics2D.OverlapCircleAll(attackPoint2.position, attackRange, playerLayer);
        Collider2D[] hitZone3 = Physics2D.OverlapCircleAll(attackPoint3.position, attackRange, playerLayer);

        foreach (Collider2D player in hitZone1)
        {
            Debug.Log("PLAYER HIT in Zone 1 NAME : " + player.name);
            player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            hasHit = true;
        }


        if (!hasHit)
        {
            foreach (Collider2D player in hitZone2)
            {
                Debug.Log("PLAYER HIT in Zone 2 NAME : " + player.name);
                player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
                hasHit = true;
            }
        }
        if (!hasHit)
        {
            foreach (Collider2D player in hitZone3)
            {
                Debug.Log("PLAYER HIT in Zone 3 NAME : " + player.name);
                player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
                hasHit = true;
            }
        }
    }

    public void wlkTog()
    {
        walker.SetActive(true);
        //in wlkbhave it gets set to false on exit
    }

}
