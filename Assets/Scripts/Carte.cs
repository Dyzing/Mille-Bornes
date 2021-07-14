using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carte : HUD
{
    public int effetCarteId;
    [SerializeField]
    //public int mainCarteId;
    public GameObject carte_i;
    public PhotonView photonView;
    public  int id_tour_actuel;
    public int nb_players;

    private int local_id_tour;
    private int local_playerViewId;

    private void Awake()
    {

    }
    void Start()
    {
        photonView.viewID = 1;
        id_tour_actuel = 1;
        local_playerViewId = PhotonNetwork.player.ID;
        photonView.RPC("InstantiateIds", PhotonTargets.AllBuffered);
        ChangerCarte();
/*        if (PhotonNetwork.player.isMasterClient)
        {
            local_id_tour = 1;
            if(photonView.isMine)
            {
                local_playerViewId = PhotonNetwork.player.ID;
            }
        }
        photonView.viewID = local_playerViewId;*/
    }

    void Update()
    {
        photonView.viewID = 1;
        photonView.RPC("InstantiateIds", PhotonTargets.AllBuffered);
    }

    public void ChangerCarte()
    {
        effetCarteId = Random.Range(0, 4);
        Sprite spriteLoaded = Resources.Load<Sprite>("Cartes/" + GameManager.mapCarte[effetCarteId]);
        carte_i.GetComponent<Image>().sprite = spriteLoaded;
    }

    [PunRPC]
    private void InstantiateIds()
    {
        Debug.Log("Debug.Log(photonView.viewID); " + photonView.viewID);
        if (PhotonNetwork.player.isMasterClient)
        {
            id_tour_actuel = 1;
        }
        if (photonView.isMine)
        {
            Debug.Log("photonView.isMine, viewid = " + local_playerViewId);
            photonView.viewID = local_playerViewId;
        }
        Debug.Log("Debug.Log(photonView.viewID); " + photonView.viewID);
    }

    [PunRPC]
    private void ChangerIdTour()
    {
        nb_players = PhotonNetwork.countOfPlayersInRooms + PhotonNetwork.countOfPlayersOnMaster;
        id_tour_actuel++;
        id_tour_actuel = id_tour_actuel % (nb_players + 1);
    }

    [PunRPC]
    private void ChangerIdCedric()
    {
        ServerManager.id_tour_cedric++;
    }

    public void OnClickEffet()
    {
        nb_players = PhotonNetwork.countOfPlayersInRooms + PhotonNetwork.countOfPlayersOnMaster;
        Debug.Log("*********** AVANT ServerManager.id_tour_cedric : " + ServerManager.id_tour_cedric);
        photonView.RPC("ChangerIdCedric", PhotonTargets.AllBuffered);
        Debug.Log("*********** APRES ServerManager.id_tour_cedric : " + ServerManager.id_tour_cedric);
        if (PhotonNetwork.player.ID == id_tour_actuel)
        {
            switch (effetCarteId)
            {
                case 0:
                    Selection25();
                    break;
                case 1:
                    Selection50();
                    break;
                case 2:
                    Selection75();
                    break;
                case 3:
                    Selection100();
                    break;
                case 4:
                    Selection200();
                    break;
                default:
                    break;
            }
            photonView.RPC("ChangerIdTour", PhotonTargets.AllBuffered);
            ChangerCarte();
        }
    }

    public void Selection25()
    {
        GameManager.KM_1 += 1;
        if (GameManager.KM_1 > 40)
            GameManager.KM_1 = 40;
        GameManager.carteJouée = "KM";
        UpdateEachRound();
    }

    public void Selection50()
    {
        GameManager.KM_1 += 2;
        if (GameManager.KM_1 > 40)
            GameManager.KM_1 = 40;
        GameManager.carteJouée = "KM";
        UpdateEachRound();
    }

    public void Selection75()
    {
        GameManager.KM_1 += 3;
        if (GameManager.KM_1 > 40)
            GameManager.KM_1 = 40;
        GameManager.carteJouée = "KM";
        UpdateEachRound();
    }

    public void Selection100()
    {
        GameManager.KM_1 += 4;
        if (GameManager.KM_1 > 40)
            GameManager.KM_1 = 40;
        GameManager.carteJouée = "KM";
        UpdateEachRound();
    }

    public void Selection200()
    {
        GameManager.KM_1 += 8;
        if (GameManager.KM_1 > 40)
            GameManager.KM_1 = 40;
        GameManager.carteJouée = "KM";
        UpdateEachRound();
    }

}
