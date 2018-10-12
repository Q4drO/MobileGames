using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


    public Animator animator;

    public float speed;
    public float lifetime;

    private float lifetimeleft;
    private bool isAlive = false;

    // Use this for initialization
    void Start () {
        lifetimeleft = lifetime;
        isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {


        if (isAlive)
        {
            lifetimeleft -= Time.deltaTime;

            if (lifetimeleft <= 0)
            {
                isAlive = false;
                lifetimeleft = lifetime;
                Destroy(gameObject);
            }

        }

	}
}
