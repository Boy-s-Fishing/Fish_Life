using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    
    public Vector3 pos;
    public GameObject navi;
    public Rigidbody rb;
    
     public float speed=1f;
     public float sprintSpeed=2f;

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine("Roaming");
    }

     IEnumerator Roaming()
    {
        toward();
       while (true) 
        {
           walking();
           rb.velocity =Vector3.zero;
            float distance = Vector3.Distance(transform.position, pos); // 몬스터와 목적지 사이 거리 구하기 
            if (distance <=0.1f) // 목적지와의 거리가 0.1 이하라면 목적지 다시 정함
            {
                toward();
            }
            
            yield return null;  
        }

    }
    void toward(){
        do{
        pos.x = Random.Range(-10f, 10f); // 목적지 x 값은 -3~3 사이 랜덤값
        pos.z = Random.Range(-10f, 10f); // 목적지 z 값은 -3~3 사이 랜덤값
        pos.y = Random.Range(-10f, 10f); // 목적지 y 값은 -3~3 사이 랜덤값
        }while (Vector3.Distance(transform.position,pos)>=20);
    }
    void walking(){
        
        var dir = (pos - transform.position).normalized;
        navi.transform.LookAt(pos);
        StartCoroutine(RotateTowardsAngle(transform,navi.transform));
        transform.position += dir * speed * Time.deltaTime;
    }
    void running(){
        
        var dir = (pos - transform.position).normalized;
        navi.transform.LookAt(pos);
        StartCoroutine(RotateTowardsAngle(transform,navi.transform));
        transform.position += dir * sprintSpeed * Time.deltaTime;
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
