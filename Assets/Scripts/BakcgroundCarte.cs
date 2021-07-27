using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BakcgroundCarte : MonoBehaviour
{
    private GameObject background_carte;
    private string carte_active_name;
    public GameObject carte_associee;

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
        background_carte.transform.position = new Vector3(background_carte.transform.position.x, background_carte.transform.position.y + 40, background_carte.transform.position.z);
    }

    public void Background_Carte_Disable()
    {
        //carte_active_name = this.name;
        //background_carte.SetActive(false);
        carte_associee.transform.position = new Vector3(carte_associee.transform.position.x, carte_associee.transform.position.y - 40, carte_associee.transform.position.z);
        background_carte.transform.position = new Vector3(background_carte.transform.position.x, background_carte.transform.position.y - 40, background_carte.transform.position.z);
        Color colorBackground = new Color(236, 170, 0, 0);
        background_carte.GetComponent<Image>().color = colorBackground;
    }
}
