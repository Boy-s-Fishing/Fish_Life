using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    
    public Vector3 pos;
    public GameObject navi;
    public GameObject Player;
    public Rigidbody rb;
    
     public float speed=1f;
     public float sprintSpeed=2f;
     bool run=false;
     public float maxH=50;//최대높이
     public float minH=10;//최소높이

    // Start is called before the first frame update
    void Start()
    {
        pos=transform.position;
        StartCoroutine("Roaming");
    }

     IEnumerator Roaming()
    {
        toward();
       while (true) 
        {
            rb.velocity =Vector3.zero;
            if(!run){
                walking();
                float distance = Vector3.Distance(transform.position, pos); // 몬스터와 목적지 사이 거리 구하기 
                if (distance <=0.1f) // 목적지와의 거리가 0.1 이하라면 목적지 다시 정함
                    {
                        toward();
                    }
            }else if(run){
                running();
                float distance = Vector3.Distance(transform.position, Player.transform.position);
                Debug.Log(distance);
                if (distance >=50f)
                    {
                        run=false;
                        toward();
                        
                    }
            }
            
            yield return null;  
        }

    }
  //목적지
    void toward(){
        if(Vector3.Distance(transform.position, Player.transform.position)<=5) run=true;
        Vector3 tempPos=new Vector3(0,0,0);           //반복문에 사용할 임시변수
        if(!run){
            do{
                tempPos.x = Random.Range(-10f, 10f); // 목적지 x 값은 -3~3 사이 랜덤값
                tempPos.z = Random.Range(-10f, 10f); // 목적지 z 값은 -3~3 사이 랜덤값
            }while (Vector3.Distance(transform.position,tempPos)<=20);
            pos+=tempPos;
            pos.y=tempPos.z = Random.Range(minH, maxH);
        }        
    }

    //이동
    void walking(){
        
        var dir = (pos - transform.position).normalized;
        navi.transform.LookAt(pos);
        StartCoroutine(RotateTowardsAngle(transform,navi.transform));
        transform.position += dir * speed * Time.deltaTime;
    }

    //도망
    void running(){
        pos.x=transform.position.x+transform.position.x-Player.transform.position.x;
        pos.y=transform.position.y;
        pos.z=transform.position.z+transform.position.z-Player.transform.position.z;
        var dir = (pos - transform.position).normalized;
        navi.transform.LookAt(pos);
        StartCoroutine(RotateTowardsAngle(transform,navi.transform));
        transform.position += (dir) * sprintSpeed * Time.deltaTime;
    }

    private void OnCollisionStay(Collision other) {
        
        toward();
    }
    // private void OnTriggerEnter(Collider other) {
    //     if(other.gameObject.tag=="Player"){
    //         StopCoroutine("Roaming");
    //         GameObject a=other.gameObject;
    //         StartCoroutine(aproach(a));
    //     }
    //}
    

    // IEnumerator aproach(GameObject other){
    //     while(true){
            
    //     pos.x=other.transform.position.x;
    //     pos.z=other.transform.position.z;
    //         float dis= Vector3.Distance(transform.position, other.transform.position);
    //         if(!back&&!stop){
                
    //             running();
    //             if(dis<5){
    //                 stop=true;
    //             }
    //         }
            
    //     yield return new WaitForEndOfFrame();
    //     }
    // }
    public IEnumerator RotateTowardsAngle(Transform myTransform, Transform NTransform)  
{
    Quaternion startRotation = myTransform.rotation;
    Quaternion targetRotation = Quaternion.Euler(NTransform.eulerAngles.x, NTransform.eulerAngles.y, NTransform.eulerAngles.z);

    float elapsedTime = 0f;
    float duration=5f;
    while (elapsedTime < duration)
    {
        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / duration);
        myTransform.rotation = Quaternion.Lerp(startRotation, targetRotation, t);
        yield return null;
    }
}
}
