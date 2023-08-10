using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fstate : MonoBehaviour
{
    public int level=1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag=="Player"){
            int comlevel=other.gameObject.GetComponent<Pstate>().level;
            Debug.Log(comlevel);
            if(comlevel>=level){
                other.gameObject.GetComponent<Pstate>().exp+=level*10;
                Destroy(gameObject);
            }
        }
    }

}
