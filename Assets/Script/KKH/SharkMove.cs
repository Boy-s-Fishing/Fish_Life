using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkMove : FishMove
{
    
    private Animator _animator;
    public GameObject mouth;
    bool bite=false;
    private int _bite;
    private int _swim;
    private int _fastswim;
    private void Awake() {
        _animator=GetComponent<Animator>();
        _bite = Animator.StringToHash("bite");
        _swim = Animator.StringToHash("swim");
        _fastswim = Animator.StringToHash("fastswim");
        _animator.SetBool(_swim,true);
    }
   public override void running(){
    _animator.SetBool(_swim,false);
    _animator.SetBool(_fastswim,true);
    pos=Player.transform.position;
    var dir = (pos - transform.position).normalized;
    obj.transform.LookAt(pos);
    StartCoroutine(RotateTowardsAngle(transform,obj.transform));
    transform.position += (dir) * sprintSpeed * Time.deltaTime;
    float distance = Vector3.Distance(transform.position, Player.transform.position);
    if (distance >=20f)
    {
        run=false;
        _animator.SetBool(_fastswim,false);
         _animator.SetBool(_swim,true);
         toward();
                        
    }
    float distance2 = Vector3.Distance(mouth.transform.position, Player.transform.position);
    if(distance2<=1.5&&!bite){
         bite=true;
         _animator.SetBool(_bite,true);
         Player.GetComponent<Pstate>().Dead();
         _animator.SetBool(_bite,false);
     }
        
    }
}
