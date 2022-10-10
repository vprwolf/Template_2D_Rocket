using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
    
{
    public GameObject camera;
    public Rigidbody2D train;
    public GameObject appearingTrail;
    public GameObject ButtonForward;
    public static gameManager I;

    public float pos = 0.0f;
    public Transform target01;
    public Transform target02;
    // public float speed = 0.05f;

    public Transform movetarget;
    public float Speed = 1f;



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
    void Update()
    {
        camera.transform.position = new Vector3(target01.transform.position.x, target01.transform.position.y, -10);
    }

   

    public void moveForward()
    {
        Invoke("OnInvoke", 0.5f); 
    }


    void OnInvoke()
    {
        //Vector3 spotPos = train.transform.position;
        //Vector3 endPos = new Vector3(0,1.2f,0);

        //train.transform.position += new Vector3(0f, 1.2f, 0f);
        //train.transform.position = Vector3.Lerp(spotPos, new Vector3(0f,spotPos.y+1.2f, 0f), 0.5f);
        //train.transform.position = Vector3.Lerp(spotPos, spotPos+endPos, 0.5f);

        //train.transform.Translate(0f, 1.2f, 0f);
        //train.MovePosition(transform.position - transform.up*Time.deltaTime* frwaySpeed);
        //transform.position = Vector3.MoveTowards(transform.position, movetarget.position, Speed * Time.deltaTime);
        train.transform.Translate(0f, 1.2f, 0f);

    }

    public void showTrail()
    {
        pos +=1.2f;
        appearingTrail.SetActive(true);
        Instantiate(appearingTrail, new Vector3(0,pos), Quaternion.identity);
    }

}
