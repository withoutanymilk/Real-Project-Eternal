using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BossWalk : MonoBehaviour
{
    public Animator anime;
    public Transform target;
    public float speed;
    public float nextWaypointDistance = 3f;
    public Transform BossGFX;
    public Rigidbody2D rb;



    int cPoint = 0;
    bool reachedEnd = false;

    Path path;
    Seeker seeker;
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        InvokeRepeating("UpdatePath", 0f, .25f);
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void UpdatePath()
    {
        if(seeker.IsDone())
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
        if (path == null)
            return;
        
        if (cPoint >= path.vectorPath.Count)
        {
            reachedEnd = true;
            //anime.SetTrigger("Attack");
            return;
        } else
        {
            reachedEnd= false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[cPoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[cPoint]);
        
        if (distance < nextWaypointDistance)
        {
            cPoint++;
        }

        //Flipping the GFX Left and right
        if (rb.velocity.x >= 0.01f && force.x > 0f)
        {
            BossGFX.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (rb.velocity.x <= -0.01f && force.x < 0f)
        {
            BossGFX.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
