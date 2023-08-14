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
                    float distance = Vector3.Distance(transform.position, pos); // 물고기와 목적지 사이 거리 구하기 
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
        Vector3 tempPos=new Vector3(0,transform.position.y,0);          // 반복문에 사용할 임시변수
        if(!run){
            do{
                tempPos=pos;
                tempPos.x = pos.x+Random.Range(-20f, 20f);              // 목적지 x 값은 -20~20 사이 랜덤값    현재 위치를 기준으로 해서 랜덤으로 목적지 지정
                tempPos.z = pos.z+Random.Range(-20f, 20f);              // 목적지 z 값은 -20~20 사이 랜덤값
            }while (Vector3.Distance(transform.position,tempPos)<=10);  // 목적지와의 거리가 너무 가까우면 다시 지정
            pos+=tempPos;                                               // 최종 목적지의 x, z값 지정
            pos.y = Random.Range(minH, maxH);                           // y값은 지정된 범위만 이동하게 지정
        }        
    }

    //이동
    public void walking(){
        
        Vector3 dir = (pos - transform.position).normalized;            // 목적지까지의 방향 정규화
        StartCoroutine(RotateTowardsAngle(dir));                        // 목적지를 바라보게 회전
        transform.position += dir * speed * Time.deltaTime;             // 해당 방향으로 이동
    }

    //도망
    public virtual void running(){
        pos.x=transform.position.x+transform.position.x-Player.transform.position.x;   // 현재 위치를 기준으로 플레이어가 있는 방향의 반대 방향을 목적지로 구함
        pos.y=transform.position.y;                                                    // y값은 지정범위를 유지하기 위해 현재 높이로 유지
        pos.z=transform.position.z+transform.position.z-Player.transform.position.z;
        Vector3 dir = (pos - transform.position).normalized;
        StartCoroutine(RotateTowardsAngle(dir));
        transform.position += (dir) * sprintSpeed * Time.deltaTime;
        float distance = Vector3.Distance(transform.position, Player.transform.position); //플레이어와의 거리 측정
        if (distance >=20f)  //춤분히 멀어지면 다시 목적지 정함
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
            Player=other.gameObject;
        }
    }
    
}
