using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// скрипт для вкл/выкл анимации. не более

public class AnimScript : MonoBehaviour
{
    [Header(" Animation")]
    [SerializeField] private Animation anim;
    [SerializeField] private string animName;
    [SerializeField] private float speed;
    [Header(" Sounds")]
    [SerializeField] private float volume;
    [SerializeField] private AudioSource soundOn;
    [SerializeField] private float soundOnDelay;
    [SerializeField] private AudioSource soundOff;
    [SerializeField] private float soundOffDelay;
    private bool state = true;

    // Start is called before the first frame update
    void Start()
    {
        if (soundOn != null)
        {
            soundOn.volume = volume * PlayerPrefs.GetFloat("volume", 0.4f) * 0.5f;
        }
        if (soundOff != null)
        {
            soundOff.volume = volume * PlayerPrefs.GetFloat("volume", 0.4f) * 0.5f;
        }

        anim[animName].time = 0f;
        anim[animName].speed = 0f;
        anim.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchState()
    {
        if (anim[animName].speed <= 0)
        {
            // anim["SinkAnim"].time = 0f;
            anim[animName].speed = 1f * speed;
            anim.Play();
            if (anim[animName].time == 0f)
            {
                // play sound only from start pos
                if (soundOn != null)
                {
                    soundOn.PlayDelayed(soundOnDelay);
                }
            }
        }
        else
        {
            if (anim[animName].time == 0f)
            {
                anim[animName].time = anim[animName].length;
                // play sound only from last pos
                if (soundOff != null)
                {
                    soundOff.PlayDelayed(soundOffDelay);
                }
            } else if (soundOff != null && anim[animName].time / speed > soundOffDelay && anim[animName].time / speed > soundOff.clip.length)
            {
                // учесть задержку звука. Полезно для дверей
                soundOff.PlayDelayed(soundOffDelay - (anim[animName].length - anim[animName].time)); 
            }
            anim[animName].speed = -1f * speed;
            anim.Play();
        }
        state = !state;

    }
}
