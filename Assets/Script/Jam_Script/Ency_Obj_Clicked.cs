using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ency_Obj_Clicked : MonoBehaviour
{
    public void OnMouseDown()
    {
        GameObject.FindWithTag("GameManager").GetComponent<Ency_Button_Obj_On>().Obj_Clicked();
    }
}
