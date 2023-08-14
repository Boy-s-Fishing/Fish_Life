using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fstate : MonoBehaviour
{
    public bool con=false;
    public int level=1;

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag=="Player"){
            int comlevel=other.gameObject.GetComponent<Pstate>().level;
            Debug.Log(comlevel);
            if(comlevel>=level){
                other.gameObject.GetComponent<Pstate>().exp+=level*10;
                Destroy(gameObject);
            }
        }else{
            con=true;
        }
    }
    private void OnCollisionExit(Collision other) {
        con=false;
    }

    public void OnCollisionStay(Collision other) {
        con=true;
    }
    private void OnCollisionExit(Collision other) {
        con=false;
    }

}
