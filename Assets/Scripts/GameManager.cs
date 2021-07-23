﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject gameCanvas;
    public GameObject sceneCamera;
    public GameObject spawn;
    public TextMeshProUGUI pingText;
    public static TextMeshProUGUI tour_joueur_i;
    public static int id_tour_actuel;

    public static int KM_1;
    public static string carteJouée;
    public static PhotonPlayer[] list_players;

    public GameObject carte1HUD;
    public GameObject carte2HUD;
    public GameObject carte3HUD;
    public GameObject carte4HUD;
    public GameObject carte5HUD;
    public GameObject carte6HUD;

    public static TextMeshProUGUI KmPlayerP1;
    public static TextMeshProUGUI KmPlayerP2;
    public static TextMeshProUGUI KmPlayerP3;
    public static TextMeshProUGUI KmPlayerP4;

    public static int KmP1;
    public static int KmP2;
    public static int KmP3;
    public static int KmP4;

    public static GameObject selectionJoueursPanel;



    public static Dictionary<int, string> mapCarte = new Dictionary<int, string>()
    {
        { 0, "25km"},
        { 1, "50km"},
        { 2, "75km"},
        { 3, "100km"},
        { 4, "200km"},
        { 5, "roulez"},
        { 6, "stop"},
        { 7, "accident"},
        { 8, "réparations"},
        { 9, "essence"},
        { 10, "panneessence"},
        { 11, "increvable"},
        { 12, "limitedevitesse"},
        { 13, "findelimitedevitesse"},
        { 14, "rouedesecours"},
        { 15, "crevé"},
        { 16, "citerneessence"},
        { 17, "asduvolant"},
        { 18, "vehiculeprioritaire"}
    };
    
    private void Awake()
    {
        gameCanvas.SetActive(true);
        KM_1 = 0;
        KmP1 = 0;
        KmP2 = 0;
        KmP3 = 0;
        KmP4 = 0;
        id_tour_actuel = 1;
        carteJouée = "";
        tour_joueur_i = GameObject.Find("TourJoueurText").GetComponent<TextMeshProUGUI>();
        selectionJoueursPanel = GameObject.Find("SelectionJoueursPanel");
        selectionJoueursPanel.SetActive(false);
        KmPlayerP1 = GameObject.Find("KmtextP1").GetComponent<TextMeshProUGUI>();
        KmPlayerP2 = GameObject.Find("KmtextP2").GetComponent<TextMeshProUGUI>();
        KmPlayerP3 = GameObject.Find("KmtextP3").GetComponent<TextMeshProUGUI>();
        KmPlayerP4 = GameObject.Find("KmtextP4").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        list_players = PhotonNetwork.playerList;
        

        pingText.text = "PING : " + PhotonNetwork.GetPing() + "ms";
    }

    public void SpawnPlayer()
    {
        //float randomValue = Random.Range(-1f, 1f);

        PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(spawn.transform.position.x, spawn.transform.position.y + 1, spawn.transform.position.z), Quaternion.identity, 0);

        PhotonNetwork.Instantiate(carte1HUD.name, new Vector3(spawn.transform.position.x, spawn.transform.position.y + 1, spawn.transform.position.z), Quaternion.identity, 0);
        PhotonNetwork.Instantiate(carte2HUD.name, new Vector3(spawn.transform.position.x, spawn.transform.position.y + 1, spawn.transform.position.z), Quaternion.identity, 0);
        PhotonNetwork.Instantiate(carte3HUD.name, new Vector3(spawn.transform.position.x, spawn.transform.position.y + 1, spawn.transform.position.z), Quaternion.identity, 0);
        PhotonNetwork.Instantiate(carte4HUD.name, new Vector3(spawn.transform.position.x, spawn.transform.position.y + 1, spawn.transform.position.z), Quaternion.identity, 0);
        PhotonNetwork.Instantiate(carte5HUD.name, new Vector3(spawn.transform.position.x, spawn.transform.position.y + 1, spawn.transform.position.z), Quaternion.identity, 0);
        PhotonNetwork.Instantiate(carte6HUD.name, new Vector3(spawn.transform.position.x, spawn.transform.position.y + 1, spawn.transform.position.z), Quaternion.identity, 0);



        gameCanvas.SetActive(false);
        sceneCamera.SetActive(false);
    }

}
