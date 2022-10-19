using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour

{
    public GameObject camera;
    public Rigidbody2D train;
    public Transform dummy;
    public GameObject appearingTrail;
    public GameObject ButtonForward;
    public GameObject ButtonLeft;
    public GameObject ButtonRight;
    public static gameManager I;

    public float pos = 0.0f;
    public Transform target01;
    public Transform target02;

    private float moveTimer;
    private bool isMoving;
    public float moveDuration = 0.05f;
    private Vector3 startPosition;
    public Transform targetPosition;

    private bool turnL;
    private bool turnR;


    private Vector3 moveTarget;


    void Awake()
    {
        I = this;
        train = train.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        camera.transform.position = new Vector3(target01.transform.position.x, target01.transform.position.y, -10);

        if (isMoving)
        {

            moveTimer += Time.deltaTime;

            float alpha = moveTimer / moveDuration;

            train.transform.position = Vector3.Lerp(startPosition, moveTarget, alpha);

        }

        /*if (turnL)
        {
            moveTimer += Time.deltaTime;

            float alpha = moveTimer / moveDuration;

            Quaternion targetRotation = Quaternion.Lerp(aRotation, bRotation, alpha);
            train.transform.rotation = targetRotation;s
        }*/

        if (turnR)
        {
            moveTimer += Time.deltaTime;

            float alpha = moveTimer / moveDuration;

            Quaternion aRotation = Quaternion.Euler(new Vector3(30, 0, 0));
            Quaternion bRotation = Quaternion.Euler(new Vector3(60, 0, 0));

            Quaternion targetRotation = Quaternion.Lerp(aRotation, bRotation, alpha);
            train.transform.rotation = targetRotation;
        }

    }

    /*public void moveForward()
    {
        dummy.transform.Translate(0f, 1.2f, 0f);
        
        //Invoke("OnInvoke", 0.5f);
    }*/

   public void turnLeft()
    {
        moveTimer = 0;

        Quaternion aRotation = Quaternion.Euler(new Vector3(30, 0, 0));
        Quaternion bRotation = Quaternion.Euler(new Vector3(60, 0, 0));

        turnL = true;
    }

    public void turnRight()
    {
        moveTimer = 0;


        turnR = true;
    }


    /*void OnInvoke()
    {
        isMoving = true;
    }*/

    public void showTrail()
    {
        pos += 1.2f;
        appearingTrail.SetActive(true);
        Instantiate(appearingTrail, new Vector3(0, pos), Quaternion.identity);
        dummy.Translate(0f, 1.2f, 0f);
    }

    public void StartMoving()
    {

        moveTimer = 0;

        startPosition = train.transform.position;
        moveTarget = dummy.transform.position;

        isMoving = true;
       
    }

}