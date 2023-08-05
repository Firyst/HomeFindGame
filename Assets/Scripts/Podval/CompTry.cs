using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompTry : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject CompCanvas;
    [SerializeField] private StarterAssets.StarterAssetsInputs w;
    private string NextLevel = "";

    public void ChangeState()
    {
        CompCanvas.SetActive(!CompCanvas.activeSelf);
        Player.SetActive(!Player.activeSelf);
        w.SetCursorState(!w.cursorLocked);
    }

    public void ChangeNextLevel(string next)
    {
        NextLevel = next;
    }

    public string GetNextLevel()
    {
        return NextLevel;
    }
}
