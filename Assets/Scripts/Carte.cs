using System.Collections;
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
            photonView.RPC("InstantiateIds", PhotonTargets.AllBuffered);
        }
    }
    void Start()
    {
        
        if (PhotonNetwork.isMasterClient)
        {
            photonView.RPC("InstantiateIds", PhotonTargets.AllBuffered);
        }
        ChangerCarte();
        GameManager.tour_joueur_i.text = "Tour au joueur " + 1;
    }

    void Update()
    {
        if (!stopIdEquals1)
        {
            photonView.RPC("InstantiateIds", PhotonTargets.AllBuffered);
            stopIdEquals1 = true;
        }
    }

    public void ChangerCarte()
    {
        effetCarteId = UnityEngine.Random.Range(0, 7);
        Sprite spriteLoaded = Resources.Load<Sprite>("Cartes/" + GameManager.mapCarte[effetCarteId]);
        carte_i.GetComponent<Image>().sprite = spriteLoaded;
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
                            default:
                                break;
                        }
                    }
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

    public void Roulez()
    {
        switch (PhotonNetwork.player.ID)
        {
            case 1:
                if (!GameManager.peutRouler1)
                {
                    GameManager.peutRouler1 = true;
                    GameManager.move_yes_no1 = true;
                }
                break;
            case 2:
                if (!GameManager.peutRouler2)
                {
                    GameManager.peutRouler2 = true;
                    GameManager.move_yes_no2 = true;
                }
                break;
            case 3:
                if (!GameManager.peutRouler3)
                {
                    GameManager.peutRouler3 = true;
                    GameManager.move_yes_no3 = true;
                }
                break;
            case 4:
                if (!GameManager.peutRouler4)
                {
                    GameManager.peutRouler4 = true;
                    GameManager.move_yes_no4 = true;
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



}
