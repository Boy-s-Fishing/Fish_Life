using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishMove : MonoBehaviour
{
    
    public Vector3 pos;
    public GameObject navi;
    public GameObject Player;
    public Rigidbody rb;
    
     public float speed=1f;
     public float sprintSpeed=2f;
     public bool run=false;
     public float maxH=50;//최대높이
     public float minH=10;//최소높이
     public float loookDis=5;  //물고기가 플레이어를 인식하는 거리

     protected GameObject obj;

    // Start is called before the first frame update
    public void Start()
    {
        pos=transform.position;
        obj=Instantiate(navi, transform.position, transform.rotation) ;
        obj.transform.parent=this.transform;
        rb=gameObject.GetComponent<Rigidbody>();
        StartCoroutine("Roaming");
    }

    public IEnumerator Roaming()
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
            }
            
            yield return null;  
        }

    }
  //목적지
    public void toward(){
        if(Vector3.Distance(transform.position, Player.transform.position)<=loookDis) run=true;
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
    public void walking(){
        
        var dir = (pos - transform.position).normalized;
        obj.transform.LookAt(pos);
        StartCoroutine(RotateTowardsAngle(this.transform,obj.transform));
        transform.position += dir * speed * Time.deltaTime;
    }

    //도망
    public virtual void running(){
        pos.x=transform.position.x+transform.position.x-Player.transform.position.x;
        pos.y=transform.position.y;
        pos.z=transform.position.z+transform.position.z-Player.transform.position.z;
        var dir = (pos - transform.position).normalized;
        obj.transform.LookAt(pos);
        StartCoroutine(RotateTowardsAngle(this.transform,obj.transform));
        transform.position += (dir) * sprintSpeed * Time.deltaTime;
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        if (distance >=20f)
            {
                run=false;
                toward();
                        
            }
    }

    public void OnCollisionStay(Collision other) {
        
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
    float duration=1f;
    while (elapsedTime < duration)
    {
        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / duration);
        myTransform.rotation = Quaternion.Lerp(startRotation, targetRotation, t);
        yield return null;
    }
}

//    public IEnumerator RotateTowardsAngle(Vector3 NTransform)  
// {

//     float elapsedTime = 0f;
//     float duration=1f;
//     while (elapsedTime < duration)
//     {
//         elapsedTime += Time.deltaTime;
//         float t = Mathf.Clamp01(elapsedTime / duration);
//         myTransform.rotation = Quaternion.Lerp(startRotation, targetRotation, t);
//         yield return null;
//     }
// }
}
