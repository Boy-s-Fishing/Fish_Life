using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishMove : MonoBehaviour
{
    
    public Vector3 pos;
    public GameObject Player;
    public Rigidbody rb;
    public GameObject fish;
     public float speed=1f;
     public float sprintSpeed=2f;
     public bool run=false;
     public float maxH=50;//최대높이
     public float minH=10;//최소높이
     public bool con;

    // Start is called before the first frame update
    public void Start()
    {
        
        StartCoroutine("Roaming");
    }

    public IEnumerator Roaming()
    {
        rb.velocity =Vector3.zero;
        toward();
       while (true) 
        {
            con=fish.gameObject.GetComponent<Fstate>().con;
            rb.velocity =Vector3.zero;
            if(!con){
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
            }else if(con){
                toward();
            }
            yield return null;  
        }

    }
  //목적지
    public void toward(){
        pos=transform.position;
        Vector3 tempPos=new Vector3(0,0,0);           //반복문에 사용할 임시변수
        if(!run){
            do{
                tempPos.x = Random.Range(-30f, 30f); // 목적지 x 값은 -3~3 사이 랜덤값
                tempPos.z = Random.Range(-30f, 30f); // 목적지 z 값은 -3~3 사이 랜덤값
            }while (Vector3.Distance(transform.position,tempPos)<=20);
            pos+=tempPos;
            pos.y=tempPos.z = Random.Range(minH, maxH);
        }        
    }

    //이동
    public void walking(){
        
        Vector3 dir = (pos - transform.position).normalized;
        StartCoroutine(RotateTowardsAngle(dir));
        transform.position += dir * speed * Time.deltaTime;
    }

    //도망
    public virtual void running(){
        pos.x=transform.position.x+transform.position.x-Player.transform.position.x;
        pos.y=transform.position.y;
        pos.z=transform.position.z+transform.position.z-Player.transform.position.z;
        Vector3 dir = (pos - transform.position).normalized;
        StartCoroutine(RotateTowardsAngle(dir));
        transform.position += (dir) * sprintSpeed * Time.deltaTime;
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        if (distance >=20f)
            {
                run=false;
                toward();
                        
            }
    }
    
   public IEnumerator RotateTowardsAngle(Vector3 dir)  
    {
        float elapsedTime = 0f;
        float duration=1f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * t);
            yield return null;
        }
}
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="Player"){
            run=true;
        }
    }
    
}
