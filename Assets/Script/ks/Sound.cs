using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    static List<AudioSource> audios;

    private void Start() {
        audios = new List<AudioSource> (GetComponents<AudioSource>());
        print(audios.Count);
    }

    public static void play(int i) {
        audios[i].Play();
    }
}
