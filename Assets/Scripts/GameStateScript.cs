using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateScript : MonoBehaviour
{
    [SerializeField] private Animation startAnim;
    [SerializeField] private GameObject startPos;
    [SerializeField] private Animation loreAnim;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("FIRSTTIMEOPENING", 1) == 1)
        {
            PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0);
        }
        else
        {
            startAnim["HeroWake"].time = 13f;
            startAnim["HeroWake"].speed = 0;

            loreAnim["lore"].time = 11f;
            loreAnim["lore"].speed = 1;
            loreAnim.Play();
            // startPos.transform.localPosition = new Vector3(6.57f, 1.28f, 0f);
        }
    }

}
