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
    [SerializeField] private Image image;

    // Start is called before the first frame update
    void Start()
    {
        if (parsedData != null)
        {
            titleText.text = parsedData[levelID.ToString()]["Title" + localizer.lang.ToUpper()];
            descText.text = parsedData[levelID.ToString()]["Desc" + localizer.lang.ToUpper()];
            goButton.onClick.AddListener(SendSignal);

            Sprite texture = Resources.Load<Sprite>("LevelLogos/level" + levelID.ToString());

            if (texture != null)
            {
                // Если текстура найдена, применяем её к Image
                image.sprite = texture;
            } else
            {
                Debug.LogWarning("Unable to find texture level" + levelID.ToString());
            }
        }
    }

    private void SendSignal()
    {
        player.MyPlaySound();
        targetScript.UpdateTarget("level"+levelID.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
