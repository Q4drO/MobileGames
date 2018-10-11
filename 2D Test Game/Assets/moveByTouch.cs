﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveByTouch : MonoBehaviour {

    public Joystick joystick;
    public float runSpeed;
    public Animator animatorCharacter;
    public Animator animatorGun;

    private float horizontalMove = 0f;
    private float verticalMove = 0f;

    private string gun;
    private string charakter;
    private int north;
    private int northeast;
    private int east;
    private int eastsouth;
    private int south;
    private int southwest;
    private int west;
    private int westnorth;

    private int north1;
    private int northeast1;
    private int east1;
    private int eastsouth1;
    private int south1;
    private int southwest1;
    private int west1;
    private int westnorth1;

    // Use this for initialization
    void Start () {
        charakter = "1";
        gun = "flamethrower";
        north = Animator.StringToHash(gun + "_north");
        northeast = Animator.StringToHash(gun + "_northeast");
        east = Animator.StringToHash(gun + "_east");
        eastsouth = Animator.StringToHash(gun + "_eastsouth");
        south = Animator.StringToHash(gun + "_south");
        southwest = Animator.StringToHash(gun + "_southwest");
        west = Animator.StringToHash(gun + "_west");
        westnorth = Animator.StringToHash(gun + "_westnorth");

        north1 = Animator.StringToHash(charakter + "_north");
        northeast1 = Animator.StringToHash(charakter + "_northeast");
        east1 = Animator.StringToHash(charakter + "_east");
        eastsouth1 = Animator.StringToHash(charakter + "_eastsouth");
        south1 = Animator.StringToHash(charakter + "_south");
        southwest1 = Animator.StringToHash(charakter + "_southwest");
        west1 = Animator.StringToHash(charakter + "_west");
        westnorth1 = Animator.StringToHash(charakter + "_westnorth");

    }
	
	// Update is called once per frame
	void Update () {

       // animatorCharacter.SetFloat("angel", 0);
       // animatorGun.SetFloat("angel", 0);
        if (Input.touchCount > 0)
        {
           

            horizontalMove = joystick.Horizontal * runSpeed;
            verticalMove = joystick.Vertical * runSpeed;


            
           

                Vector2 fromVector2 = new Vector2(0, 50);
                Vector2 toVector2 = new Vector2(joystick.Direction.x, joystick.Direction.y);

                float ang = Vector2.Angle(fromVector2, toVector2);
                Vector3 cross = Vector3.Cross(fromVector2, toVector2);

                if (cross.z > 0)
                    ang = 360 - ang;


            Debug.Log(ang);






            setAllFalse();
            if (ang <= 25 || ang >= 335)
            {
                animatorGun.SetTrigger(north);
                animatorCharacter.SetTrigger(north1);
            }
            else if (ang <= 65 && ang >= 25)
            {
                animatorGun.SetTrigger(northeast);
                animatorCharacter.SetTrigger(northeast1);
            }
            else if (ang <= 115 && ang >= 65)
            {
                animatorGun.SetTrigger(east);
                animatorCharacter.SetTrigger(east1);
            }
            else if (ang <= 155 && ang >= 115)
            {
                animatorGun.SetTrigger(eastsouth);
                animatorCharacter.SetTrigger(eastsouth1);
            }
            else if (ang <= 205 && ang >= 155)
            {
                animatorGun.SetTrigger(south);
                animatorCharacter.SetTrigger(south1);
            }
            else if (ang <= 245 && ang >= 205)
            {
                animatorGun.SetTrigger(southwest);
                animatorCharacter.SetTrigger(southwest1);
            }
            else if (ang <= 295 && ang >= 245)
            {
                animatorGun.SetTrigger(west);
                animatorCharacter.SetTrigger(west1);
            }
            else if (ang <= 335 && ang >= 295)
            {
                animatorGun.SetTrigger(westnorth);
                animatorCharacter.SetTrigger(westnorth1);
            }

            //for (int i = 0; i < Input.touchCount; i++){
            //    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
            //    Debug.DrawLine(Vector3.zero, touchPosition, Color.red);
            //}

            transform.position += new Vector3(horizontalMove, verticalMove, 0) * Time.deltaTime;

           // Touch touch = Input.GetTouch(0);
           // Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
           // touchPosition.z = 0f;
           // transform.position = touchPosition;
        }

	}
    private void setAllFalse()
    {
        animatorGun.SetBool(north, false);
        animatorGun.SetBool(northeast, false);
        animatorGun.SetBool(east, false);
        animatorGun.SetBool(eastsouth, false);
        animatorGun.SetBool(south, false);
        animatorGun.SetBool(southwest, false);
        animatorGun.SetBool(west, false);
        animatorGun.SetBool(westnorth, false);

        animatorCharacter.SetBool(north1, false);
        animatorCharacter.SetBool(northeast1, false);
        animatorCharacter.SetBool(east1, false);
        animatorCharacter.SetBool(eastsouth1, false);
        animatorCharacter.SetBool(south1, false);
        animatorCharacter.SetBool(southwest1, false);
        animatorCharacter.SetBool(west1, false);
        animatorCharacter.SetBool(westnorth1, false);
    }
}