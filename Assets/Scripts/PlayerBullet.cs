using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public GameObject hitEffect;
    public int damage = 2;

    void Start()
    {

    }
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        EnemyPspwn enemyp = collision.GetComponent<EnemyPspwn>();
        if (enemyp != null)
        {
            enemyp.TakeDamage(damage);
        }
        bHealthNExtras boss = collision.GetComponent<bHealthNExtras>();
        if (boss != null)
        {
            boss.TakeDamage(damage);
        }
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.2f);
        Destroy(gameObject);
    }
}
