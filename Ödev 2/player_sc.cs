using System.Runtime.CompilerServices;
using UnityEngine;

public class player_sc2 : MonoBehaviour
{
    public int speed = 10;

    private float nextFire = 0;


    [SerializeField]
    private float fireRate = 0.25f;

    [SerializeField]
    public GameObject laserPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position=new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {

        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space)&&(Time.time>nextFire))
        {
            nextFire = Time.time + fireRate;
            FireLaser();
        }
       
    }

void FireLaser()
    {
       Instantiate(laserPrefab, (this.transform.position + new Vector3(0, 0, 0)), Quaternion.identity);       
    }



    void CalculateMovement(){
    

        float horizontalInput=Input.GetAxis("Horizontal");
        float verticalInput=Input.GetAxis("Vertical");
        Vector3 direction=new Vector3(horizontalInput,verticalInput,0);

        transform.Translate(direction*speed*Time.deltaTime);

        transform.position=new Vector3(transform.position.x, Mathf.Clamp(transform.position.y,-3.8f,0),0);
/*
        if(trnasform.positon.y>=0){
            transform.positon=new Vector3(transform.positon.x,0,0);
        }
        
        else if(transform.positon.y<=-5.6f){
            transform.position=new Vector3(transform.position,-5.6f,0);
        }
  */      
        if(transform.position.x>11.7f){
            transform.position=new Vector3(-11.7f,transform.position.y,0);
        }

        else if(transform.position.x<-11.7f){
            transform.position=new Vector3(11.7f,transform.position.y,0);
        }



    }

}


