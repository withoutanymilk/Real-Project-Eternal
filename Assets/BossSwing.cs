using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSwing : MonoBehaviour
{

    public Animator anime;
    public Transform attackPoint1;
    public Transform attackPoint2;
    public Transform attackPoint3;
    public float attackRange;
    public LayerMask playerLayer;



    // Update is called once per frame
    void Update()
    {
        Collider2D[] range1 = Physics2D.OverlapCircleAll(attackPoint1.position, attackRange - .7f, playerLayer);
        Collider2D[] range2 = Physics2D.OverlapCircleAll(attackPoint2.position, attackRange - .7f, playerLayer);
        Collider2D[] range3 = Physics2D.OverlapCircleAll(attackPoint3.position, attackRange - .7f, playerLayer);
        foreach (Collider2D player in range1)
        {
            if (player.name == "Player")
            {
                anime.SetTrigger("Attack");
            }
        }
        foreach (Collider2D player in range2)
        {
            if (player.name == "Player")
            {
                anime.SetTrigger("Attack");
            }
        }
        foreach (Collider2D player in range3)
        {
            if (player.name == "Player")
            {
                anime.SetTrigger("Attack");
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint1 == null || attackPoint2 == null) { return; }


        Gizmos.DrawWireSphere(attackPoint1.position, attackRange - .7f);
        Gizmos.DrawWireSphere(attackPoint2.position, attackRange - .7f);
        Gizmos.DrawWireSphere(attackPoint3.position, attackRange - .7f);
    }

}
