using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    dataInfo data;
    // Start is called before the first frame update
    public void set(string name, dataInfo d) {
        data = d;
        gameObject.name = data.name;
    }

}
