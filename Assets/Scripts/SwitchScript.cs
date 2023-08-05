using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// скрипт для вкл/выкл анимации. не более

public class SwitchScript : MonoBehaviour
{

    [SerializeField] private Animation anim;
    [SerializeField] private string animName;
    [SerializeField] private float speed;

    [SerializeField] private List<Light> lights;
    private bool state = true;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Light light in lights)
        {
            light.enabled = false;
        }
    }
    public void SwitchState()
    {
        foreach (Light light in lights)
        {
            light.enabled = !light.enabled;
        }

        if (state)
        {
            // anim["SinkAnim"].time = 0f;
            anim[animName].speed = 1f * speed;
            anim.Play();
        }
        else
        {
            if (anim[animName].time == 0f)
            {
                anim[animName].time = anim[animName].length;
            }
            anim[animName].speed = -1f * speed;
            anim.Play();
        }
        state = !state;


    }
}
