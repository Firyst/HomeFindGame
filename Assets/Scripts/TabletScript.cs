using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;


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
    [SerializeField] private CompTry tablet;

    [SerializeField] private NKLPLocalizer localizer;



    void Start()
    {
        var data = Resources.Load<TextAsset>("data"); // прочитать файл 

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

        print(string.Format("tablet: <color=green> Loaded {0} lines </color>", locale_lines_count));
        // print(parsedData["1"]["Desc"]);

        InitUI();
    }

    void InitUI()
    {
        titleText.text = parsedData[levelID.ToString()]["Title" + PlayerPrefs.GetString("lang").ToUpper()];
        descText.text = parsedData[levelID.ToString()]["Desc" + PlayerPrefs.GetString("lang").ToUpper()];
        endingText.text = parsedData[levelID.ToString()]["Ending" + PlayerPrefs.GetString("lang").ToUpper()];
        // localizer.FindNewText();
        // localizer.LocalizeAllText();
    }

    public void EndBuy()
    {
        touchBlock.enabled = true;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        blackScreenAnimation["black_screen"].speed = -1f;
        blackScreenAnimation["black_screen"].time = 2f;
        blackScreenAnimation.Play();

        endingAnim1.Play();
        endingAnim2.Play();

        PlayerPrefs.SetInt("FIRSTTIMEOPENING", 1);
        StartLevelDelayed(15000, "MainMenu");
        EndBuy2();
    }

    async private void EndBuy2()
    {
        await Task.Delay(10000);
        print("reverse");


        endingAnim2["ending2"].time = endingAnim2["ending2"].length;
        endingAnim2["ending2"].speed = -1f;

        await Task.Delay(1000);
        endingAnim1["ending1"].time = endingAnim1["ending1"].length;
        endingAnim1["ending1"].speed = -1f;

        endingAnim1.Play();
        endingAnim2.Play();
    }

    public void EndDecline()
    {
        touchBlock.enabled = true;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        blackScreenAnimation["black_screen"].speed = -1f;
        blackScreenAnimation["black_screen"].time = 2f;
        blackScreenAnimation.Play();
        StartLevelDelayed(2500, "Podval");
    }

    async public void StartLevelDelayed(int delay, string scene)
    {
        await Task.Delay(delay);
        tablet.ChangeState();
        SceneManager.LoadScene(scene);
    }
}
