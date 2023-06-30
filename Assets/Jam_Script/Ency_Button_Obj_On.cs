using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ency_Button_Obj_On : MonoBehaviour
{
    public GameObject[] SeaObj; //�ؾ���� ������Ʈ ���
    public GameObject[] SeaExplain; //����â ���

    public GameObject nowOnObj; //���� ���� �ִ� (�����ִ�) �ؾ����
    public GameObject nowOnExp; //���� ���� �ִ� (�����ִ�) ����â

    public int input_num;   //��ư���׼� �Է¹޴� num

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
