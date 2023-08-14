using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Name : MonoBehaviour
{
    TextMeshProUGUI name;

    void Start()
    {
        name = transform.GetChild(transform.childCount-1).GetChild(0).GetComponent<TextMeshProUGUI>();
        name.enabled = false;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="Player"){
            name.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag=="Player"){
            name.enabled = false;
        }
    }
}
