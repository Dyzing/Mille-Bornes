using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : Photon.MonoBehaviour
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

    public static TextMeshProUGUI KmPlayerP1;
    public static TextMeshProUGUI KmPlayerP2;
    public static TextMeshProUGUI KmPlayerP3;
    public static TextMeshProUGUI KmPlayerP4;

    public static int KmP1;
    public static int KmP2;
    public static int KmP3;
    public static int KmP4;
    

    public GameObject carte1HUD;
    public GameObject carte2HUD;
    public GameObject carte3HUD;
    public GameObject carte4HUD;
    public GameObject carte5HUD;
    public GameObject carte6HUD;

    public GameObject selectionJ1HUD;
    public GameObject selectionJ2HUD;
    public GameObject selectionJ3HUD;
    public GameObject selectionJ4HUD;

    public static bool move_yes_no1;
    public static bool peutRouler1;
    public static bool hasNotAccident1;

    public static bool move_yes_no2;
    public static bool peutRouler2;
    public static bool hasNotAccident2;

    public static bool move_yes_no3;
    public static bool peutRouler3;
    public static bool hasNotAccident3;

    public static bool move_yes_no4;
    public static bool peutRouler4;
    public static bool hasNotAccident4;

    public static int joueurSelectionne;

    public static GameObject selectionJoueursPanel;

    public static Text etatJoueur1;
    public static Text etatJoueur2;
    public static Text etatJoueur3;
    public static Text etatJoueur4;

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
        { 10, "findelimitedevitesse"},
        { 11, "increvable"},
        { 12, "limitedevitesse"},
        { 13, "panneessence"},
        { 14, "rouedesecours"},
        { 15, "citerneessence"},
        { 16, "crevé"},
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
        etatJoueur1 = GameObject.Find("Joueur1Etat").GetComponent<Text>();
        etatJoueur2 = GameObject.Find("Joueur2Etat").GetComponent<Text>();
        etatJoueur3 = GameObject.Find("Joueur3Etat").GetComponent<Text>();
        etatJoueur4 = GameObject.Find("Joueur4Etat").GetComponent<Text>();
        selectionJoueursPanel.SetActive(false);

        move_yes_no1 = true;
        peutRouler1 = true;
        hasNotAccident1 = true;

        move_yes_no2 = true;
        peutRouler2 = true;
        hasNotAccident2 = true;

        move_yes_no3 = true;
        peutRouler3 = true;
        hasNotAccident3 = true;

        move_yes_no4 = true;
        peutRouler4 = true;
        hasNotAccident4 = true;

        joueurSelectionne = 0;
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


        /*PhotonNetwork.Instantiate(selectionJ1HUD.name, new Vector3(spawn.transform.position.x, spawn.transform.position.y + 1, spawn.transform.position.z), Quaternion.identity, 0);
        PhotonNetwork.Instantiate(selectionJ2HUD.name, new Vector3(spawn.transform.position.x, spawn.transform.position.y + 1, spawn.transform.position.z), Quaternion.identity, 0);
        PhotonNetwork.Instantiate(selectionJ3HUD.name, new Vector3(spawn.transform.position.x, spawn.transform.position.y + 1, spawn.transform.position.z), Quaternion.identity, 0);
        PhotonNetwork.Instantiate(selectionJ4HUD.name, new Vector3(spawn.transform.position.x, spawn.transform.position.y + 1, spawn.transform.position.z), Quaternion.identity, 0);*/

        //photonView.RPC("UpdateSliders", PhotonTargets.AllBufferedViaServer);
        gameCanvas.SetActive(false);
        sceneCamera.SetActive(false);
    }

}
