using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ��� ���/���� ��������. �� �����

public class AnimScript : MonoBehaviour
{

    [SerializeField] private Animation anim;
    [SerializeField] private string animName;
    [SerializeField] private float speed;
    private bool state = true;

    // Start is called before the first frame update
    void Start()
    {
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
            anim[animName].speed = 1f*speed;
            anim.Play();
        }
        else
        {
            if (anim[animName].time == 0f)
            {
                anim[animName].time = anim[animName].length;
            }
            anim[animName].speed = -1f*speed;
            anim.Play();
        }
        state = !state;

    }
}
