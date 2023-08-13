using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ency_Content : MonoBehaviour
{
    public ScrollRect sr;
    public void Exam()
    {
        sr.content.localPosition = new Vector3(3, 1, 0);

    }

}
