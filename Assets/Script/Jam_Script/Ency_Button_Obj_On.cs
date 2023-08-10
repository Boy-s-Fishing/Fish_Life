using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ency_Button_Obj_On : MonoBehaviour
{
    public GameObject[] SeaObj; //해양생물 오브젝트 목록
    public GameObject[] SeaExplain; //설명창 목록

    public GameObject nowOnObj; //현재 보고 있는 (켜져있는) 해양생물
    public GameObject nowOnExp; //현재 보고 있는 (켜져있는) 설명창

    public int input_num;   //버튼한테서 입력받는 num

    public void Btn_Clicked(int x)
    {
        input_num = x;
        try
        {
            nowOnObj.SetActive(false);
            nowOnExp.SetActive(false);
        }
        finally
        {
            nowOnObj = SeaObj[x];
            SeaObj[x].SetActive(true);
        }
    }

    public void Obj_Clicked()
    {
        try
        {
            nowOnExp.SetActive(false);
        }
        finally
        {
            nowOnExp = SeaExplain[input_num];
            SeaExplain[input_num].SetActive(true);
        }
    }
}
