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
    public static gameManager I;

    public float pos = 0.0f;
    public Transform target01;
    public Transform target02;

    private float moveTimer;
    private bool isMoving;
    public float moveDuration = 0.2f;
    private Vector3 startPosition;
    public Transform targetPosition;

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
            Vector3 target = targetPosition.position;
            Vector3 start = train.position;

            moveTimer += Time.deltaTime;

            float alpha = moveTimer / moveDuration;

            transform.position = Vector3.Lerp(start, target, alpha);

        } 


    }



    /*public void moveForward()
    {
        dummy.transform.Translate(0f, 1.2f, 0f);
        isMoving = true;
        //Invoke("OnInvoke", 0.5f);
        //Invoke("OnInvoke",0.0f);
    }


    void OnInvoke()
    {
        //Vector3 spotPos = train.transform.position;
        //Vector3 endPos = new Vector3(0,1.2f,0);

        //train.transform.position += new Vector3(0f, 1.2f, 0f);

        //train.transform.Translate(0f, 1.2f, 0f);
        //train.transform.position = Vector3.Lerp(train.transform.position, dummy.transform.position, 0.05f);
        //train.transform.position = Vector3.MoveTowards(train.transform.position, dummy.transform.position, 1.2f);
        //train.transform.position = Vector3.MoveTowards(transform.position, dummy.transform.position, 0.1f);
    }*/

    public void showTrail()
    {
        pos +=1.2f;
        appearingTrail.SetActive(true);
        Instantiate(appearingTrail, new Vector3(0,pos), Quaternion.identity);
    }

    public void StartMoving()
    {

        moveTimer = 0;

        isMoving = true;

        startPosition = transform.position;

    }

}
