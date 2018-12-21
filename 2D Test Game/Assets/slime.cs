using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class slime : MonoBehaviour {



    public float speed;
    public float minDistance;
    public float health;
    public Image healthBar;

    public Transform target;
    private GameObject gameObjectSlime;

    private float startHealth;
    private Animator animator;
    private int north;
    private int northeast;
    private int east;
    private int eastsouth;
    private int south;
    private int southwest;
    private int west;
    private int westnorth;
    private string monster;

    void Start()
    {
        startHealth = health;

        animator = GetComponent<Animator>();
        monster = "slime";
        north = Animator.StringToHash(monster + "_north");
        east = Animator.StringToHash(monster + "_east");
        south = Animator.StringToHash(monster + "_south");
        west = Animator.StringToHash(monster + "_west");

        gameObjectSlime = this.gameObject;

    }



        void Update () {

        if (Vector2.Distance(transform.position, target.position) > minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }



        Vector3 dir = target.transform.position - transform.position;
        dir = target.transform.InverseTransformDirection(dir);
        float ang = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if (ang < 0)
        {
            ang = 360 + ang;
        }
        

        setAllFalse();
        if (ang > 0)
        {
            if (ang <= 45 || ang >= 315)
            {
                animator.SetTrigger(east);
            }
            else if (ang <= 135 && ang >= 45)
            {
                animator.SetTrigger(north);
            }
            else if (ang <= 225 && ang >= 135)
            {
                animator.SetTrigger(west);
            }
            else if (ang <= 315 && ang >= 225)
            {
                animator.SetTrigger(south);
            }
        }
    }
    public void takeDamage(float damage)
    {
        health -= damage;

        healthBar.fillAmount = health / startHealth;

        if(health <= 0)
        {
            dead();
        }
    }

    private void dead()
    {
        GameObject slimeClone1 = Instantiate(gameObjectSlime, transform.position, transform.rotation);
        GameObject slimeClone2 = Instantiate(gameObjectSlime, transform.position, transform.rotation);
        Destroy(this);
    }

    private void setAllFalse()
    {
        animator.SetBool(north, false);
        animator.SetBool(east, false);
        animator.SetBool(south, false);
        animator.SetBool(west, false);
        
    }
}
