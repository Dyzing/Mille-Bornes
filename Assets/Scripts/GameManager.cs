using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameObject voiture1;
    public static int KM_1;
    public static string carteJouée;

    void Start()
    {
        voiture1 = GameObject.Find("Voiture" + 1);
        KM_1 = 0;
        carteJouée = "";
    }

    void Update()
    {

    }

}
