using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    GameObject name;

    void Start()
    {
        name = transform.GetChild(transform.childCount).gameObject;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="Player"){
            name.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag=="Player"){
            name.SetActive(false);
        }
    }
}
