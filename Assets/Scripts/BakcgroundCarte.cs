using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BakcgroundCarte : MonoBehaviour
{
    private GameObject background_carte;
    private string carte_active_name;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Background_Carte_Enable()
    {
        carte_active_name = this.name;

        background_carte = GameObject.Find(carte_active_name);
        background_carte.transform.SetAsLastSibling();   
        Color colorBackground = new Color(236, 170, 0, 255);
        background_carte.GetComponent<Image>().color = colorBackground;
    }

    public void Background_Carte_Disable()
    {
        //carte_active_name = this.name;
        //background_carte.SetActive(false);

        Color colorBackground = new Color(236, 170, 0, 0);
        background_carte.GetComponent<Image>().color = colorBackground;
    }
}
