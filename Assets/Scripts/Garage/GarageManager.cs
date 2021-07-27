using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageManager : MonoBehaviour
{
    public static int id_voiture;

    public void LoadMenu()
    {
        PhotonNetwork.LoadLevel("Menu");
    }
}
