using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompScripts : MonoBehaviour
{

    [SerializeField] private NKLPLocalizer localizer;
    [SerializeField] private int lastID;
    [SerializeField] GameObject parent;
    [SerializeField] GameObject salePrefab;
    [SerializeField] Translator translator;
    [SerializeField] MySoundHandler player;

    public Dictionary<string, Dictionary<string, string>> parsedData = new Dictionary<string, Dictionary<string, string>>();

    // Start is called before the first frame update
    void Start()
    {
        LoadData();

        for (int index=1; index<=lastID; index++)
        {
            print(index);
            var sale = Instantiate(salePrefab);
            sale.transform.SetParent(parent.transform);
            sale.GetComponent<SaleItemScript>().levelID = index;
            sale.GetComponent<SaleItemScript>().localizer = localizer;
            sale.GetComponent<SaleItemScript>().parsedData = parsedData;
            sale.GetComponent<SaleItemScript>().targetScript = translator;
            sale.GetComponent<SaleItemScript>().player = player;
            sale.transform.localScale = Vector3.one;
            sale.transform.localPosition = new Vector3(0, 80 - 210 * index, 0);
            sale.transform.localEulerAngles = Vector3.zero;
        }

        localizer.FindNewText();
        localizer.LocalizeAllText();
    }


    void LoadData()
    {
        var data = Resources.Load<TextAsset>("data"); // прочитать файл локализации

        if (data == null)
        {
            Debug.LogError("comp: file not found");
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
            // чтение файла 
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

        print(string.Format("comp: <color=green> Loaded {0} lines </color>", locale_lines_count));
    }

}
