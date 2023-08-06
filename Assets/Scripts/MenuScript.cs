using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Canvas mainCanvas;
    [SerializeField] private Canvas settingsCanvas;
    [SerializeField] private Animation fadeAnim;
    [SerializeField] private Slider volumeSlider;

    void Start()
    {
        settingsCanvas.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        volumeSlider.onValueChanged.AddListener(changeVolume);
        volumeSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat("volume", 0.4f));
    }

    public void SwitchState()
    {
        settingsCanvas.enabled = !settingsCanvas.enabled;
        mainCanvas.enabled = !mainCanvas.enabled;
    }

    private void changeVolume(float newVol)
    {
        PlayerPrefs.SetFloat("volume", newVol);
    }

    public void StartGame()
    {
        fadeAnim["black_screen"].time = 2f;
        fadeAnim["black_screen"].speed = -1f;
        fadeAnim.Play();
        Cursor.lockState = CursorLockMode.Locked;
        PlayerPrefs.SetInt("FIRSTTIMEOPENING", 1);
        StartLevelDelayed(2225, "Podval");
    }

    public void QuitGame()
    {
        print("goodbye");
        Application.Quit();
    }

    async public void StartLevelDelayed(int delay, string scene)
    {
        await Task.Delay(delay);
        SceneManager.LoadScene(scene);
    }
}
