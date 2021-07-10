using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HUD : MonoBehaviour
{
    private TextMeshProUGUI KM_Text;
    void Start()
    {
        
    }

    void Update()
    {

    }

    public IEnumerator TextChange()
    {
        yield return new WaitForSeconds(1f);       
    }

    public void Selection25()
    {
        GameManager.KM_1 += 1;
        if (GameManager.KM_1 > 40)
            GameManager.KM_1 = 40;
        GameManager.carteJouée = "KM";
        Update_KM_HUD();
    }

    public void Selection50()
    {
        GameManager.KM_1 += 2;
        if (GameManager.KM_1 > 40)
            GameManager.KM_1 = 40;
        GameManager.carteJouée = "KM";
        Update_KM_HUD();
    }

    public void Selection75()
    {
        GameManager.KM_1 += 3;
        if (GameManager.KM_1 > 40)
            GameManager.KM_1 = 40;
        GameManager.carteJouée = "KM";
        Update_KM_HUD();
    }

    public void Selection100()
    {
        GameManager.KM_1 += 4;
        if (GameManager.KM_1 > 40)
            GameManager.KM_1 = 40;
        GameManager.carteJouée = "KM";
        Update_KM_HUD();
    }

    public void Selection200()
    {
        GameManager.KM_1 += 8;
        if (GameManager.KM_1 > 40)
            GameManager.KM_1 = 40;
        GameManager.carteJouée = "KM";
        Update_KM_HUD();
    }

    public void Update_KM_HUD()
    {
        KM_Text = GameObject.Find("KM Text").GetComponent<TextMeshProUGUI>();
        KM_Text.text = "KM : " + (GameManager.KM_1 * 25);
    }
}
