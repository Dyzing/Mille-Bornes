using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.carteJouée)
        {
            case "KM":
                MoveVoiture();
                GameManager.carteJouée = "";
                break;
            default:
                break;
        }
    }

    public void MoveVoiture()
    {
        Vector3 voiturepos = GameObject.Find("Voiture" + 1).transform.position;
        Vector3 destination;
        if (GameManager.KM_1 <= 39)
        {
            destination = GameObject.Find("Node" + GameManager.KM_1).transform.position;
        }
        else
        {
            destination = GameObject.Find("Node40").transform.position;
        }
        voiturepos = destination;
        voiturepos.y += 0.5f;
        GameManager.voiture1.transform.position = voiturepos;
        if (GameManager.KM_1 <= 38)
        {
            GameManager.voiture1.transform.eulerAngles = GameObject.Find("Node" + (GameManager.KM_1 + 1)).transform.eulerAngles;
        }
        else
        {
            GameManager.voiture1.transform.eulerAngles = GameObject.Find("Node40").transform.eulerAngles;
        }
    }
}
