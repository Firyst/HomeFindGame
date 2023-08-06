using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{

    [SerializeField] private AudioSource sound;
    [SerializeField] private GameObject player;
    [SerializeField] private float soundThreshold;

    private Vector3 lastPos;


    // Update is called once per frame
    void FixedUpdate()
    {
        if ((Mathf.Pow(player.transform.localPosition.x - lastPos.x, 2) + Mathf.Pow(player.transform.localPosition.z - lastPos.z, 2f)) > soundThreshold)
        {
            if (!sound.isPlaying)
            {
                sound.volume = PlayerPrefs.GetFloat("volume", 0.4f) * 0.5f;
                sound.Play();
            }
        } else
        {
            if (sound.isPlaying)
            {
                sound.Stop();
            }
        }

        lastPos = player.transform.localPosition;
    }
}
