using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ency_FishBtn_Clicked : MonoBehaviour
{
    public int num;   //��ư ���°����
    public Ency_Button_Obj_On Ency_Button_Obj_On;

    private void Awake()
    {
        //�Ŵ�����ũ��Ʈ ã��
        Ency_Button_Obj_On = GameObject.FindWithTag("GameManager").GetComponent<Ency_Button_Obj_On>();
    }

    public void Clicked()
    {
        Ency_Button_Obj_On.Btn_Clicked(this.num);

    }
}
