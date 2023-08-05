using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Translator : MonoBehaviour
{
    [SerializeField] private CompTry Comp;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnCollisionEnter");
        if (Comp.GetNextLevel() != "")
        {
            SceneManager.LoadScene(Comp.GetNextLevel(), LoadSceneMode.Single);
        }
    }

}
