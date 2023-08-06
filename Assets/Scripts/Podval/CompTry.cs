using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompTry : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject CompCanvas;
    [SerializeField] private StarterAssets.StarterAssetsInputs w;
    [SerializeField] private NKLPLocalizer localizer;
    private string NextLevel = "";

    private void Start()
    {
        CompCanvas.SetActive(false);
    }

    public void ChangeState()
    {
        CompCanvas.SetActive(!CompCanvas.activeSelf);
        Player.SetActive(!Player.activeSelf);
        w.SetCursorState(!w.cursorLocked);
        if (CompCanvas.activeSelf)
        {
            // костыль - перезагрузить локализацию
            if (localizer != null)
            {
                localizer.FindNewText();
                localizer.LocalizeAllText();
            }
        }
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
