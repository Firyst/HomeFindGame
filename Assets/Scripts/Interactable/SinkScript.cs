using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkScript : MonoBehaviour
{

    [SerializeField] private Animation anim;
    [SerializeField] private bool waterEnabled;
    [SerializeField] private ParticleSystem water;
    [SerializeField] private AudioSource sound;
    private bool state = true;

    // Start is called before the first frame update
    void Start()
    {
        water.Stop();
        sound.volume = PlayerPrefs.GetFloat("volume", 0.4f) * 0.25f;
    }


    public void SwitchState()
    {
        if (state)
        {
            // anim["SinkAnim"].time = 0f;
            anim["SinkAnim"].speed = 1f;
            anim.Play();
            if (waterEnabled)
            {
                water.Play();
                sound.Play();
            }
        } else
        {
            if (anim["SinkAnim"].time == 0f)
            {
                anim["SinkAnim"].time = 0.5f;
            }
            anim["SinkAnim"].speed = -1f;
            anim.Play();
            water.Stop();
            sound.Stop();
        }
        state = !state;
        
    }
}
