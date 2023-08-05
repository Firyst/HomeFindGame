using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaleItemScript : MonoBehaviour
{
    public int levelID;
    public NKLPLocalizer localizer;
    public Dictionary<string, Dictionary<string, string>>  parsedData;
    public Translator targetScript;
    public MySoundHandler player;

    [SerializeField] private Text titleText;
    [SerializeField] private Text descText;
    [SerializeField] private Button goButton;

    // Start is called before the first frame update
    void Start()
    {
        if (parsedData != null)
        {
            titleText.text = parsedData[levelID.ToString()]["Title" + localizer.lang.ToUpper()];
            descText.text = parsedData[levelID.ToString()]["Desc" + localizer.lang.ToUpper()];
            goButton.onClick.AddListener(SendSignal);
        }
    }

    private void SendSignal()
    {
        player.MyPlaySound();
        targetScript.UpdateTarget("level0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
