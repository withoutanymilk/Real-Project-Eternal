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
    public float attackRange;
    public LayerMask playerLayer;
    public int attackDamage = 30;
    //walking things
    public GameObject walker;
    private bool pToggle = false;
    //portal things
    public GameObject portal;
    //boss hit box
    private bool bTog = true;
    //Stage things
    private bool i2 = true;




    // Start is called before the first frame update
    void Start()
    {
        cHealth = maxHealth;
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
            if (i2)
            {
                anime.SetTrigger("Intro2");
                i2 = false;
                attackDamage = 60;
            }
            else
                return;
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
        return;
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
            if (player.name == "Player")
            {
                Debug.Log("PLAYER HIT in Zone 1 NAME : " + player.name);
                player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
                hasHit = true;
            }
        }


        if (!hasHit)
        {
            foreach (Collider2D player in hitZone2)
            {
                if (player.name == "Player")
                {
                    Debug.Log("PLAYER HIT in Zone 2 NAME : " + player.name);
                    player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
                    hasHit = true;
                }
            }
        }
        if (!hasHit)
        {
            foreach (Collider2D player in hitZone3)
            {
                if (player.name == "Player")
                {
                    Debug.Log("PLAYER HIT in Zone 3 NAME : " + player.name);
                    player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
                    hasHit = true;
                }
            }
        }
    }

    public void wlkTog()//toggles walk state
    {
        if(!walker.activeSelf)
            walker.SetActive(true);
        return;
        //in wlkbhave it gets set to false on exit
    }

    public void portTog() //toggles bPortal on and off
    {
        pToggle = !pToggle;
        portal.SetActive(pToggle);
        return;
    }

    public void bcollideTog() //Toggles bhitbox 
    {
        bTog = !bTog;
        Debug.Log(bTog);
        GetComponent<Collider2D>().enabled =bTog;
        return;
    }

    public void stage2Walk()
    {
        walker.GetComponent<BossWalk>().speed = 4999999f;
    }
    public void stage2Enrage()
    {
        walker.GetComponent<BossWalk>().speed = 6999999f;
    }


    void OnDrawGizmosSelected()
    {
        if (attackPoint1 == null || attackPoint2 == null) { return; }


        Gizmos.DrawWireSphere(attackPoint1.position, attackRange);
        Gizmos.DrawWireSphere(attackPoint2.position, attackRange);
        Gizmos.DrawWireSphere(attackPoint3.position, attackRange);
    }


}
