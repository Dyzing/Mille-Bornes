using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Carte : HUD
{
    public int effetCarteId;
    public GameObject carte_i;
    public PhotonView photonView;
    public int id_tour_actuel;
    public int nb_players;

    public bool stopIdEquals1 = false;

    private void Awake()
    {
        if (PhotonNetwork.player.isMasterClient)
        {
            photonView.RPC("InstantiateIds", PhotonTargets.AllBuffered);
        }
    }
    void Start()
    {
        photonView.viewID = PhotonNetwork.player.ID;
        if (PhotonNetwork.player.isMasterClient)
        {
            photonView.RPC("InstantiateIds", PhotonTargets.AllBuffered);
        }
        ChangerCarte();
        GameManager.tour_joueur_i.text = "Tour au joueur " + 1;
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
        photonView.viewID = PhotonNetwork.player.ID;
        if (!stopIdEquals1)
        {
            photonView.RPC("InstantiateIds", PhotonTargets.AllBuffered);
            stopIdEquals1 = true;
        }
        //photonView.RPC("InstantiateIds", PhotonTargets.AllBuffered);
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
        Debug.Log("***** AVANT id_tour_actuel : " + id_tour_actuel);
        id_tour_actuel = 1;
        Debug.Log("***** APRES id_tour_actuel : " + id_tour_actuel);
    }

    [PunRPC]
    private void ChangerIdTour()
    {
        nb_players = PhotonNetwork.countOfPlayersOnMaster;
        Debug.Log("id_tour_actue : " + id_tour_actuel);
        id_tour_actuel++;
        id_tour_actuel = id_tour_actuel % (nb_players + 1);
        Debug.Log("id_tour_actue : " + id_tour_actuel);
        if(id_tour_actuel == 0)
        {
            id_tour_actuel = 1;
        }
        GameManager.tour_joueur_i.text = "Tour au joueur " + id_tour_actuel;
    }


    public void OnClickEffet()
    {
        nb_players = PhotonNetwork.countOfPlayersOnMaster;
        photonView.viewID = PhotonNetwork.player.ID;

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
            photonView.RPC("ChangerIdTour", PhotonTargets.AllBufferedViaServer);
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
