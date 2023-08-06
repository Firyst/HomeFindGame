using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class Translator : MonoBehaviour
{
    private string targetLevel = "";
    private bool started = false;

    [SerializeField] private Animation fadeAnim;
    [SerializeField] private Animation goAnim;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnCollisionEnter");
        if (targetLevel != "" && !started)
        {
            print("go");
            StartLevelDelayed(2000, targetLevel);
            fadeAnim["lore"].time = 13f;
            fadeAnim["lore"].speed = -1f;
            fadeAnim.Play();
            started = true;
        }
    }

    public void UpdateTarget(string target)
    {
        targetLevel = target;
        goAnim.Play();
    }

    async public void StartLevelDelayed(int delay, string scene)
    {
        await Task.Delay(delay);
        Debug.Log("Switching level to " + scene);
        SceneManager.LoadScene(scene);
    }

}
