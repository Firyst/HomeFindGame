using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySoundHandler : MonoBehaviour
{
    [SerializeField] AudioSource sound;
    [SerializeField] float volume;
    [SerializeField] float pitch;
    [SerializeField] float startPos;

    public void MyPlaySound()
    {
        sound.volume = volume * PlayerPrefs.GetFloat("volume", 0.4f) * 0.5f;
        sound.pitch = pitch;
        sound.time = startPos;
        sound.Play();
    }


}
