using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class TabletScript : MonoBehaviour

{
    public Dictionary<string, Dictionary<string, string>> parsedData = new Dictionary<string, Dictionary<string, string>>();

    [SerializeField] private int levelID;
    [SerializeField] private Text titleText;
    [SerializeField] private Text descText;
    [SerializeField] private Text endingText;

    [SerializeField] private Animation blackScreenAnimation;
    [SerializeField] private Animation endingAnim1;
    [SerializeField] private Animation endingAnim2;

    [SerializeField] private GraphicRaycaster touchBlock;



    void Start()
    {
        GetLocalizer().FindNewText();
        GetLocalizer().LocalizeAllText();
        var data = Resources.Load<TextAsset>("data"); // прочитать файл локализации

        if (data == null)
        {
            Debug.LogError("tablet: file not found");
            return;
        }

        string[] lines = data.text.Split('\n'); // разбить файл по строчкам

        string[] col_array = lines[0].Split(";");  // получить столбцы


        for (int line_i = 1; line_i < col_array.Length; line_i++)
        {
            parsedData.Add(col_array[line_i], new Dictionary<string, string>()); // заполнить главный словарь локализации словарями для переводов
        }


        long locale_lines_count = 0; // счетчик загруженных строк

        for (int key_i = 1; key_i < lines.Length; key_i++)
        {
            // чтение файла локализации
            string[] locale_line = lines[key_i].Split(";");
            if (locale_line.Length > 2)
            {
                for (int line_i = 1; line_i < col_array.Length; line_i++)
                {
                    // запись перевода для каждого языка
                    parsedData[col_array[line_i]].Add(locale_line[0], locale_line[line_i]);
                }
                locale_lines_count++;
            }
        }

        print(string.Format("tablet: <color=green> Loaded {0} lines </color>", locale_lines_count));
        // print(parsedData["1"]["Desc"]);

        InitUI();
    }

    void InitUI()
    {
        var localizer = GetLocalizer();
        titleText.text = parsedData[levelID.ToString()]["Title" + localizer.lang.ToUpper()];
        descText.text = parsedData[levelID.ToString()]["Desc" + localizer.lang.ToUpper()];
        endingText.text = parsedData[levelID.ToString()]["Ending" + localizer.lang.ToUpper()];
    }

    private NKLPLocalizer GetLocalizer()
    {

        NKLPLocalizer res = (NKLPLocalizer)FindObjectOfType(typeof(NKLPLocalizer));
        if (res == null)
        {

            Debug.LogError("Unable to find localizer object instance :(");
        }
        return res;
    }

    public void EndBuy()
    {
        touchBlock.enabled = true;
        blackScreenAnimation["black_screen"].speed = -1f;
        blackScreenAnimation["black_screen"].time = 2f;
        blackScreenAnimation.Play();

        endingAnim1.Play();
        endingAnim2.Play();
    }

    public void EndDecline()
    {
        touchBlock.enabled = true;
        blackScreenAnimation["black_screen"].speed = -1f;
        blackScreenAnimation["black_screen"].time = 2f;
        blackScreenAnimation.Play();
    }
}
