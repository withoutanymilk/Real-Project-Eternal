using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;
public class EnemyPspwn : MonoBehaviour
{
    public float speed;
    public float nextWaypointDistance;
    public float maxHealth;
    public float health;
    public int damage;
    public GameObject deathEffect;
    public Image healthImage;
    int cPoint = 0;
    bool reachedEnd = false;
    public float moveT;

    private PlayerHealth player;
    Transform target;
    Rigidbody2D rb;
    Seeker seeker;
    Path path;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
            FindObjectOfType<AudioManager>().Play("Death");
        }
    }

    void Die()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
        Destroy(gameObject);
    }




    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        seeker = GetComponent<Seeker>();
        target = GameObject.FindWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

        InvokeRepeating("UpdatePath", 0f, moveT);
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            cPoint = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        healthImage.fillAmount = health / maxHealth;
        if (path == null)
            return;

        if (cPoint >= path.vectorPath.Count)
        {
            reachedEnd = true;
            return;
        }
        else
        {
            reachedEnd = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[cPoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[cPoint]);

        if (distance < nextWaypointDistance)
        {
            cPoint++;
        }


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth pHealth = collision.GetComponent<PlayerHealth>();
        if (pHealth != null)
            pHealth.TakeDamage(damage);
    }
}
