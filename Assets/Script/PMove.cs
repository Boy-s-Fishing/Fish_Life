using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMove : MonoBehaviour
{
    public GameObject toward;
    public GameObject cam;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        transform.position=cam.transform.position;
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        rb.velocity =Vector3.zero;
    }
    public void move(){
        float posx=Input.GetAxis("Horizontal");
        float posz=Input.GetAxis("Vertical");
        if(posz!=0||posx!=0){
            transform.position += toward.transform.forward * posz * 0.1f;

            // Vector3 t=toward.transform.position;
            // Vector3 tt=new Vector3(t.x*posx,t.y,t.z*posz);
            // print(tt);
            // transform.position = Vector3.MoveTowards(transform.position,tt, Time.deltaTime);
            
        }
        
    }
    // public void rot(){
    //     float posx=Input.GetAxis("Horizontal");
    //     if(posx!=0){
    //         cam.transform.Rotate(new Vector3(0, posx, 0) * 0.1f);
    //     }
    // }
}
