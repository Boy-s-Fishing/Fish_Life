using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ency_FishBtn_Clicked : MonoBehaviour
{
    public int num;   //버튼 몇번째인지
    public Ency_Button_Obj_On Ency_Button_Obj_On;

    private void Awake()
    {
        //매니저스크립트 찾기
        Ency_Button_Obj_On = GameObject.FindWithTag("GameManager").GetComponent<Ency_Button_Obj_On>();
    }

    public void Clicked()
    {
        Ency_Button_Obj_On.Btn_Clicked(this.num);

    }
}
