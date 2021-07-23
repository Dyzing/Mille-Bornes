﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Carte : HUD
{
    public int effetCarteId;
    public GameObject carte_i;
    public PhotonView photonView;
    public int nb_players;

    public bool stopIdEquals1 = false;

    private void Awake()
    {
        if (PhotonNetwork.isMasterClient)
        {
            photonView.RPC("InstantiateIds", PhotonTargets.AllViaServer);
        }
    }
    void Start()
    {
        
        if (PhotonNetwork.isMasterClient)
        {
            photonView.RPC("InstantiateIds", PhotonTargets.AllViaServer);
        }
        ChangerCarte(-1);
        GameManager.tour_joueur_i.text = "Tour au joueur " + 1;
    }

    void Update()
    {
        if (!stopIdEquals1)
        {
            photonView.RPC("InstantiateIds", PhotonTargets.AllViaServer);
            stopIdEquals1 = true;
        }
    }

    public void ChangerCarte(int effetCarte)
    {
        effetCarteId = UnityEngine.Random.Range(2, 9);
        Sprite spriteLoaded = Resources.Load<Sprite>("Cartes/" + GameManager.mapCarte[effetCarteId]);
        carte_i.GetComponent<Image>().sprite = spriteLoaded;
        photonView.RPC("UpdateSliders", PhotonTargets.AllBufferedViaServer,effetCarte);

    }
    [PunRPC]
    private void UpdateSliders(int effetCarte)
    {

        switch (GameManager.id_tour_actuel)
        {
            case 1:
                if (GameManager.move_yes_no1)
                {
                    switch (effetCarte)
                    {
                        case 0:
                            GameManager.KmP1 += 25;
                            break;
                        case 1:
                            GameManager.KmP1 += 50;
                            break;
                        case 2:
                            GameManager.KmP1 += 75;
                            break;
                        case 3:
                            GameManager.KmP1 += 100;
                            break;
                        case 4:
                            GameManager.KmP1 += 200;
                            break;
                        default:
                            break;
                    }
                }
                break;

            case 2:
                if (GameManager.move_yes_no2)
                {
                    switch (effetCarte)
                    {
                        case 0:
                            GameManager.KmP2 += 25;
                            break;
                        case 1:
                            GameManager.KmP2 += 50;
                            break;
                        case 2:
                            GameManager.KmP2 += 75;
                            break;
                        case 3:
                            GameManager.KmP2 += 100;
                            break;
                        case 4:
                            GameManager.KmP2 += 200;
                            break;
                        default:
                            break;
                    }
                }
                break;
            case 3:
                if (GameManager.move_yes_no3)
                {
                    switch (effetCarte)
                    {
                        case 0:
                            GameManager.KmP3 += 25;
                            break;
                        case 1:
                            GameManager.KmP3 += 50;
                            break;
                        case 2:
                            GameManager.KmP3 += 75;
                            break;
                        case 3:
                            GameManager.KmP3 += 100;
                            break;
                        case 4:
                            GameManager.KmP3 += 200;
                            break;
                        default:
                            break;
                    }
                }
                break;

            case 4:
                if (GameManager.move_yes_no4)
                {
                    switch (effetCarte)
                    {
                        case 0:
                            GameManager.KmP4 += 25;
                            break;
                        case 1:
                            GameManager.KmP4 += 50;
                            break;
                        case 2:
                            GameManager.KmP4 += 75;
                            break;
                        case 3:
                            GameManager.KmP4 += 100;
                            break;
                        case 4:
                            GameManager.KmP4 += 200;
                            break;
                        default:
                            break;
                    }
                }
                break;
            default:
                break;
        }

        for (int i = 0; i < PhotonNetwork.room.PlayerCount; i++)

        {
            if (i == 0)
            {

                GameManager.KmPlayerP1.text = "P" + (i + 1) + " :" + Math.Min(GameManager.KmP1,1000) + " Km";
            }
            if (i == 1)
            {
                GameManager.KmPlayerP2.text = "P" + (i + 1) + " :" + Math.Min(GameManager.KmP2, 1000) + " Km";
            }
            if (i == 2)
            {
                GameManager.KmPlayerP3.text = "P" + (i + 1) + " :" + Math.Min(GameManager.KmP3, 1000) + " Km";
            }
            if (i == 3)
            {
                GameManager.KmPlayerP4.text = "P" + (i + 1) + " :" + Math.Min(GameManager.KmP4, 1000) + " Km";
            }

        }

    }

    [PunRPC]
    private void InstantiateIds()
    {
        //Debug.Log("***** AVANT id_tour_actuel : " + GameManager.id_tour_actuel);
        GameManager.id_tour_actuel = 1;
        //Debug.Log("***** APRES id_tour_actuel : " + GameManager.id_tour_actuel);
    }

    [PunRPC]
    private void ChangerIdTour()
    {
        nb_players = PhotonNetwork.playerList.Length;
        //Debug.Log("id_tour_actuel : " + GameManager.id_tour_actuel);
        GameManager.id_tour_actuel++;
        GameManager.id_tour_actuel = GameManager.id_tour_actuel % (nb_players + 1);
        //Debug.Log("id_tour_actuel : " + GameManager.id_tour_actuel);
        if(GameManager.id_tour_actuel == 0)
        {
            GameManager.id_tour_actuel = 1;
        }
        GameManager.tour_joueur_i.text = "Tour au joueur " + GameManager.id_tour_actuel;
    }


    public void OnClickEffet()
    {
        nb_players = PhotonNetwork.playerList.Length;
        if (PhotonNetwork.player.ID == GameManager.id_tour_actuel)
        {
            switch(PhotonNetwork.player.ID)
            {
                case 1:
                    if (GameManager.move_yes_no1) //en route
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
                            case 6:
                                AfficherJoueursSelectionStop();
                                break;
                            case 7:
                                AfficherJoueursSelectionAccident();
                                break;
                            default:
                                break;
                        }
                    }
                    else // a l'arrêt
                    {
                        switch (effetCarteId)
                        {
                            case 5:
                                Roulez();
                                break;
                            case 6:
                                AfficherJoueursSelectionStop();
                                break;
                            case 7:
                                AfficherJoueursSelectionAccident();
                                break;
                            case 8:
                                Reparations();
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case 2:
                    if (GameManager.move_yes_no2) //en route
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
                            case 6:
                                AfficherJoueursSelectionStop();
                                break;
                            case 7:
                                AfficherJoueursSelectionAccident();
                                break;
                            default:
                                break;
                        }
                    }
                    else // a l'arrêt
                    {
                        switch (effetCarteId)
                        {
                            case 5:
                                Roulez();
                                break;
                            case 6:
                                AfficherJoueursSelectionStop();
                                break;
                            case 7:
                                AfficherJoueursSelectionAccident();
                                break;
                            case 8:
                                Reparations();
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case 3:
                    if (GameManager.move_yes_no3) //en route
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
                            case 6:
                                AfficherJoueursSelectionStop();
                                break;
                            case 7:
                                AfficherJoueursSelectionAccident();
                                break;
                            default:
                                break;
                        }
                    }
                    else // a l'arrêt
                    {
                        switch (effetCarteId)
                        {
                            case 5:
                                Roulez();
                                break;
                            case 6:
                                AfficherJoueursSelectionStop();
                                break;
                            case 7:
                                AfficherJoueursSelectionAccident();
                                break;
                            case 8:
                                Reparations();
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case 4:
                    if (GameManager.move_yes_no4) //en route
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
                            case 6:
                                AfficherJoueursSelectionStop();
                                break;
                            case 7:
                                AfficherJoueursSelectionAccident();
                                break;
                            default:
                                break;
                        }
                    }
                    else // a l'arrêt
                    {
                        switch (effetCarteId)
                        {
                            case 5:
                                Roulez();
                                break;
                            case 6:
                                AfficherJoueursSelectionStop();
                                break;
                            case 7:
                                AfficherJoueursSelectionAccident();
                                break;
                            case 8:
                                Reparations();
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }
            ChangerCarte(effetCarteId);
            photonView.RPC("ChangerIdTour", PhotonTargets.AllViaServer);
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


    [PunRPC]
    private void ChangerEtatBonJoueur1()
    {
        GameManager.peutRouler1 = true;
        GameManager.move_yes_no1 = true;
        GameManager.hasNotAccident1 = true;
        GameManager.etatJoueur1.text = "Joueur 1 ";
    }

    [PunRPC]
    private void ChangerEtatBonJoueur2()
    {
        GameManager.peutRouler2 = true;
        GameManager.move_yes_no2 = true;
        GameManager.hasNotAccident2 = true;
        GameManager.etatJoueur2.text = "Joueur 2 ";
    }

    [PunRPC]
    private void ChangerEtatBonJoueur3()
    {
        GameManager.peutRouler3 = true;
        GameManager.move_yes_no3 = true;
        GameManager.hasNotAccident3 = true;
        GameManager.etatJoueur3.text = "Joueur 3 ";
    }

    [PunRPC]
    private void ChangerEtatBonJoueur4()
    {
        GameManager.peutRouler4 = true;
        GameManager.move_yes_no4 = true;
        GameManager.hasNotAccident4 = true;
        GameManager.etatJoueur4.text = "Joueur 4 ";
    }

    public void Roulez()
    {
        switch (PhotonNetwork.player.ID)
        {
            case 1:
                if (!GameManager.peutRouler1)
                {
                    photonView.RPC("ChangerEtatBonJoueur1", PhotonTargets.AllViaServer);
                }
                break;
            case 2:
                if (!GameManager.peutRouler2)
                {
                    photonView.RPC("ChangerEtatBonJoueur2", PhotonTargets.AllViaServer);
                }
                break;
            case 3:
                if (!GameManager.peutRouler3)
                {
                    photonView.RPC("ChangerEtatBonJoueur3", PhotonTargets.AllViaServer);
                }
                break;
            case 4:
                if (!GameManager.peutRouler4)
                {
                    photonView.RPC("ChangerEtatBonJoueur4", PhotonTargets.AllViaServer);
                }
                break;
            default:
                break;
        }
    }

    public void Reparations()
    {
        switch (PhotonNetwork.player.ID)
        {
            case 1:
                if (!GameManager.hasNotAccident1)
                {
                    photonView.RPC("ChangerEtatBonJoueur1", PhotonTargets.AllViaServer);
                }
                break;
            case 2:
                if (!GameManager.hasNotAccident2)
                {
                    photonView.RPC("ChangerEtatBonJoueur2", PhotonTargets.AllViaServer);
                }
                break;
            case 3:
                if (!GameManager.hasNotAccident3)
                {
                    photonView.RPC("ChangerEtatBonJoueur3", PhotonTargets.AllViaServer);
                }
                break;
            case 4:
                if (!GameManager.hasNotAccident4)
                {
                    photonView.RPC("ChangerEtatBonJoueur4", PhotonTargets.AllViaServer);
                }
                break;
            default:
                break;
        }
    }

    public void AfficherJoueursSelectionStop()
    {
        GameManager.selectionJoueursPanel.SetActive(true);
        GameManager.carteJouée = "Stop";
    }

    public void AfficherJoueursSelectionAccident()
    {
        GameManager.selectionJoueursPanel.SetActive(true);
        GameManager.carteJouée = "Accident";
    }


}
