using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkScript : MonoBehaviour
{

    [SerializeField] private Animation anim;
    [SerializeField] private bool waterEnabled;
    [SerializeField] private ParticleSystem water;
    private bool state = true;

    // Start is called before the first frame update
    void Start()
    {
        water.Stop();
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
        }
        state = !state;
        
    }
}
