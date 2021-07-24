using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HUD : MonoBehaviour
{
    public static TextMeshProUGUI KM_Text;

    public static GameObject victoire_Canvas;


    void Start()
    {
        KM_Text = GameObject.Find("KM Text").GetComponent<TextMeshProUGUI>();
        victoire_Canvas = GameObject.Find("Victoire Canvas");

        victoire_Canvas.SetActive(false);
    }

    public IEnumerator TextChange()
    {
        yield return new WaitForSeconds(1f);       
    }

    public void UpdateEachRound()
    {
        Update_KM_HUD();
        Victoire_HUD();
    }

    public void Background_Carte_i_SetActive_False()
    {
        GameObject.Find("Background Carte 1 HUD").SetActive(false);
        GameObject.Find("Background Carte 2 HUD").SetActive(false);
        GameObject.Find("Background Carte 3 HUD").SetActive(false);
        GameObject.Find("Background Carte 4 HUD").SetActive(false);
        GameObject.Find("Background Carte 5 HUD").SetActive(false);
        GameObject.Find("Background Carte 6 HUD").SetActive(false);
    }

    
    public void Update_KM_HUD()
    {
        KM_Text.text = "KM : " + (GameManager.KM_1 * 25);
    }

    public void Victoire_HUD()
    {
        if (GameManager.KM_1 >= 40)
        {
            victoire_Canvas.SetActive(true);
        }
    }


}
