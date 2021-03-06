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
        ChangerCarte(-1);
        GameManager.tour_joueur_i.text = "Tour a " + PhotonNetwork.player.NickName;
        ChangerKMColor();
    }

    void Update()
    {
        if (!stopIdEquals1)
        {
            photonView.RPC("InstantiateIds", PhotonTargets.AllBuffered);
            stopIdEquals1 = true;
        }
    }

    public void ChangerCarte(int effetCarte)
    {
        int indexRand = UnityEngine.Random.Range(0, GameManager.deck.Count);
        effetCarteId = GameManager.deck[indexRand];

        Sprite spriteLoaded = Resources.Load<Sprite>("Cartes/" + GameManager.mapCarte[effetCarteId]);
        carte_i.GetComponent<Image>().sprite = spriteLoaded;
        photonView.RPC("UpdateSliders", PhotonTargets.AllBufferedViaServer, effetCarte);

    }
    [PunRPC]
    private void UpdateSliders(int effetCarte)
    {

        switch (GameManager.id_tour_actuel)
        {
            case 1:
                if (Player.move_yes_no1)
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
                            if (Player.hasNotLimite1)
                                GameManager.KmP1 += 75;
                            break;
                        case 3:
                            if (Player.hasNotLimite1)
                                GameManager.KmP1 += 100;
                            break;
                        case 4:
                            if (Player.hasNotLimite1)
                                GameManager.KmP1 += 200;
                            break;
                        default:
                            break;
                    }
                }
                break;

            case 2:
                if (Player.move_yes_no2)
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
                            if (Player.hasNotLimite2)
                                GameManager.KmP2 += 75;
                            break;
                        case 3:
                            if (Player.hasNotLimite2)
                                GameManager.KmP2 += 100;
                            break;
                        case 4:
                            if (Player.hasNotLimite2)
                                GameManager.KmP2 += 200;
                            break;
                        default:
                            break;
                    }
                }
                break;

            case 3:
                if (Player.move_yes_no3)
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
                            if (Player.hasNotLimite3)
                                GameManager.KmP3 += 75;
                            break;
                        case 3:
                            if (Player.hasNotLimite3)
                                GameManager.KmP3 += 100;
                            break;
                        case 4:
                            if (Player.hasNotLimite3)
                                GameManager.KmP3 += 200;
                            break;
                        default:
                            break;
                    }
                }
                break;

            case 4:
                if (Player.move_yes_no4)
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
                            if (Player.hasNotLimite4)
                                GameManager.KmP4 += 75;
                            break;
                        case 3:
                            if (Player.hasNotLimite4)
                                GameManager.KmP4 += 100;
                            break;
                        case 4:
                            if (Player.hasNotLimite4)
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
                GameManager.KmPlayerP1.text = PhotonNetwork.player.Get(i+1).NickName + " : " + Math.Min(GameManager.KmP1, 1000) + " Km";
            }
            if (i == 1)
            {
                GameManager.KmPlayerP2.text = PhotonNetwork.player.Get(i+1).NickName + " : " + Math.Min(GameManager.KmP2, 1000) + " Km";
            }
            if (i == 2)
            {
                GameManager.KmPlayerP3.text = PhotonNetwork.player.Get(i+1).NickName + " : " + Math.Min(GameManager.KmP3, 1000) + " Km";
            }
            if (i == 3)
            {
                GameManager.KmPlayerP4.text = PhotonNetwork.player.Get(i+1).NickName + " : " + Math.Min(GameManager.KmP4, 1000) + " Km";
            }

        }

    }

    public void ChangerKMColor()
    {
        if (photonView.isMine)
        {
            if (photonView.owner != null)
            {
                switch (photonView.owner.ID)
                {
                    case 1:
                        GameManager.KmPlayerP1.color = Color.green;
                        break;
                    case 2:
                        GameManager.KmPlayerP2.color = Color.green;

                        break;
                    case 3:
                        GameManager.KmPlayerP3.color = Color.green;

                        break;
                    case 4:
                        GameManager.KmPlayerP4.color = Color.green;

                        break;
                    default:
                        break;
                }
            }
        }
    }

    [PunRPC]
    private void InstantiateIds()
    {
        GameManager.id_tour_actuel = 1;
    }

    [PunRPC]
    private void ChangerIdTour()
    {
        nb_players = PhotonNetwork.playerList.Length;
        if (nb_players == 1)
        {
            GameManager.id_tour_actuel++;
            GameManager.id_tour_actuel = GameManager.id_tour_actuel % (nb_players + 1);
            GameManager.tour_joueur_i.text = "Tour a " + PhotonNetwork.player.NickName;
        }
        else
        {
            GameManager.tour_joueur_i.text = "Tour a " + PhotonNetwork.player.GetNextFor(GameManager.id_tour_actuel).NickName;
            GameManager.id_tour_actuel = PhotonNetwork.player.GetNextFor(GameManager.id_tour_actuel).ID;
        }
        if (GameManager.id_tour_actuel == 0)
        {
            GameManager.id_tour_actuel = 1;
        }
        //GameManager.tour_joueur_i.text = "Tour au joueur " + GameManager.id_tour_actuel;
        AfficherPanelAToiDeJouer();
    }

    public void AfficherPanelAToiDeJouer()
    {
        if (PhotonNetwork.player.ID == GameManager.id_tour_actuel)
        {
            StartCoroutine(CoroutineAToiDeJouer());
        }
    }

    private IEnumerator CoroutineAToiDeJouer()
    {
        GameManager.aToiDeJouerPanel.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        GameManager.aToiDeJouerPanel.SetActive(false);
    }

    public void OnClickEffet()
    {
        nb_players = PhotonNetwork.playerList.Length;
        if (PhotonNetwork.player.ID == GameManager.id_tour_actuel)
        {
            switch(PhotonNetwork.player.ID)
            {
                case 1:
                    if (Player.move_yes_no1) //en route
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
                                if(Player.hasNotLimite1)
                                    Selection75();
                                break;
                            case 3:
                                if (Player.hasNotLimite1)
                                    Selection100();
                                break;
                            case 4:
                                if (Player.hasNotLimite1)
                                    Selection200();
                                break;
                            case 6:
                                AfficherJoueursSelectionStop();
                                break;
                            case 7:
                                AfficherJoueursSelectionAccident();
                                break;
                            case 9:
                                AfficherJoueursSelectionPanneEssence();
                                break;
                            case 12:
                                AfficherJoueursSelectionCrevaison();
                                break;
                            case 13:
                                AfficherJoueursSelectionLimite();
                                break;
                            case 14:
                                ChangerCarteJouee("Fin limite vitesse");
                                SoundManager.PlaySoound("finlimite");
                                break;
                            case 15:
                                SelectionIncrevable();
                                break;
                            case 16:
                                SelectionCiterne();
                                break;
                            case 17:
                                SelectionAsDuVolant();
                                break;
                            case 18:
                                SelectionPrioritaire();
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
                                ChangerCarteJouee("Roulez");
                                SoundManager.PlaySoound("roulez");
                                break;
                            case 6:
                                AfficherJoueursSelectionStop();
                                break;
                            case 7:
                                AfficherJoueursSelectionAccident();
                                break;
                            case 8:
                                ChangerCarteJouee("Reparations");
                                SoundManager.PlaySoound("pub-carglass-1");
                                break;
                            case 9:
                                AfficherJoueursSelectionPanneEssence();
                                break;
                            case 10:
                                ChangerCarteJouee("Essence");
                                SoundManager.PlaySoound("essence");
                                break;
                            case 11:
                                ChangerCarteJouee("Roue de secours");
                                SoundManager.PlaySoound("feu-vert");
                                break;
                            case 12:
                                AfficherJoueursSelectionCrevaison();
                                break;
                            case 13:
                                AfficherJoueursSelectionLimite();
                                break;
                            case 14:
                                ChangerCarteJouee("Fin limite vitesse");
                                SoundManager.PlaySoound("finlimite");
                                break;
                            case 15:
                                SelectionIncrevable();
                                break;
                            case 16:
                                SelectionCiterne();
                                break;
                            case 17:
                                SelectionAsDuVolant();
                                break;
                            case 18:
                                SelectionPrioritaire();
                                break;
                        }
                    }
                    break;
                case 2:
                    if (Player.move_yes_no2) //en route
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
                                if (Player.hasNotLimite1)
                                    Selection75();
                                break;
                            case 3:
                                if (Player.hasNotLimite1)
                                    Selection100();
                                break;
                            case 4:
                                if (Player.hasNotLimite1)
                                    Selection200();
                                break;
                            case 6:
                                AfficherJoueursSelectionStop();
                                break;
                            case 7:
                                AfficherJoueursSelectionAccident();
                                break;
                            case 9:
                                AfficherJoueursSelectionPanneEssence();
                                break;
                            case 12:
                                AfficherJoueursSelectionCrevaison();
                                break;
                            case 13:
                                AfficherJoueursSelectionLimite();
                                break;
                            case 14:
                                ChangerCarteJouee("Fin limite vitesse");
                                SoundManager.PlaySoound("finlimite");
                                break;
                            case 15:
                                SelectionIncrevable();
                                break;
                            case 16:
                                SelectionCiterne();
                                break;
                            case 17:
                                SelectionAsDuVolant();
                                break;
                            case 18:
                                SelectionPrioritaire();
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
                                ChangerCarteJouee("Roulez");
                                SoundManager.PlaySoound("roulez");
                                break;
                            case 6:
                                AfficherJoueursSelectionStop();
                                break;
                            case 7:
                                AfficherJoueursSelectionAccident();
                                break;
                            case 8:
                                ChangerCarteJouee("Reparations");
                                SoundManager.PlaySoound("pub-carglass-1");
                                break;
                            case 9:
                                AfficherJoueursSelectionPanneEssence();
                                break;
                            case 10:
                                ChangerCarteJouee("Essence");
                                SoundManager.PlaySoound("essence");
                                break;
                            case 11:
                                ChangerCarteJouee("Roue de secours");
                                SoundManager.PlaySoound("feu-vert");
                                break;
                            case 12:
                                AfficherJoueursSelectionCrevaison();
                                break;
                            case 13:
                                AfficherJoueursSelectionLimite();
                                break;
                            case 14:
                                ChangerCarteJouee("Fin limite vitesse");
                                SoundManager.PlaySoound("finlimite");
                                break;
                            case 15:
                                SelectionIncrevable();
                                break;
                            case 16:
                                SelectionCiterne();
                                break;
                            case 17:
                                SelectionAsDuVolant();
                                break;
                            case 18:
                                SelectionPrioritaire();
                                break;
                        }
                    }
                    break;
                case 3:
                    if (Player.move_yes_no3) //en route
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
                                if (Player.hasNotLimite1)
                                    Selection75();
                                break;
                            case 3:
                                if (Player.hasNotLimite1)
                                    Selection100();
                                break;
                            case 4:
                                if (Player.hasNotLimite1)
                                    Selection200();
                                break;
                            case 6:
                                AfficherJoueursSelectionStop();
                                break;
                            case 7:
                                AfficherJoueursSelectionAccident();
                                break;
                            case 9:
                                AfficherJoueursSelectionPanneEssence();
                                break;
                            case 12:
                                AfficherJoueursSelectionCrevaison();
                                break;
                            case 13:
                                AfficherJoueursSelectionLimite();
                                break;
                            case 14:
                                ChangerCarteJouee("Fin limite vitesse");
                                SoundManager.PlaySoound("finlimite");
                                break;
                            case 15:
                                SelectionIncrevable();
                                break;
                            case 16:
                                SelectionCiterne();
                                break;
                            case 17:
                                SelectionAsDuVolant();
                                break;
                            case 18:
                                SelectionPrioritaire();
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
                                ChangerCarteJouee("Roulez");
                                SoundManager.PlaySoound("roulez");
                                break;
                            case 6:
                                AfficherJoueursSelectionStop();
                                break;
                            case 7:
                                AfficherJoueursSelectionAccident();
                                break;
                            case 8:
                                ChangerCarteJouee("Reparations");
                                SoundManager.PlaySoound("pub-carglass-1");
                                break;
                            case 9:
                                AfficherJoueursSelectionPanneEssence();
                                break;
                            case 10:
                                ChangerCarteJouee("Essence");
                                SoundManager.PlaySoound("essence");
                                break;
                            case 11:
                                ChangerCarteJouee("Roue de secours");
                                SoundManager.PlaySoound("feu-vert");
                                break;
                            case 12:
                                AfficherJoueursSelectionCrevaison();
                                break;
                            case 13:
                                AfficherJoueursSelectionLimite();
                                break;
                            case 14:
                                ChangerCarteJouee("Fin limite vitesse");
                                SoundManager.PlaySoound("finlimite");
                                break;
                            case 15:
                                SelectionIncrevable();
                                break;
                            case 16:
                                SelectionCiterne();
                                break;
                            case 17:
                                SelectionAsDuVolant();
                                break;
                            case 18:
                                SelectionPrioritaire();
                                break;
                        }
                    }
                    break;
                case 4:
                    if (Player.move_yes_no4) //en route
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
                                if (Player.hasNotLimite1)
                                    Selection75();
                                break;
                            case 3:
                                if (Player.hasNotLimite1)
                                    Selection100();
                                break;
                            case 4:
                                if (Player.hasNotLimite1)
                                    Selection200();
                                break;
                            case 6:
                                AfficherJoueursSelectionStop();
                                break;
                            case 7:
                                AfficherJoueursSelectionAccident();
                                break;
                            case 9:
                                AfficherJoueursSelectionPanneEssence();
                                break;
                            case 12:
                                AfficherJoueursSelectionCrevaison();
                                break;
                            case 13:
                                AfficherJoueursSelectionLimite();
                                break;
                            case 14:
                                ChangerCarteJouee("Fin limite vitesse");
                                SoundManager.PlaySoound("finlimite");
                                break;
                            case 15:
                                SelectionIncrevable();
                                break;
                            case 16:
                                SelectionCiterne();
                                break;
                            case 17:
                                SelectionAsDuVolant();
                                break;
                            case 18:
                                SelectionPrioritaire();
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
                                ChangerCarteJouee("Roulez");
                                SoundManager.PlaySoound("roulez");
                                break;
                            case 6:
                                AfficherJoueursSelectionStop();
                                break;
                            case 7:
                                AfficherJoueursSelectionAccident();
                                break;
                            case 8:
                                ChangerCarteJouee("Reparations");
                                SoundManager.PlaySoound("pub-carglass-1");
                                break;
                            case 9:
                                AfficherJoueursSelectionPanneEssence();
                                break;
                            case 10:
                                ChangerCarteJouee("Essence");
                                SoundManager.PlaySoound("essence");
                                break;
                            case 11:
                                ChangerCarteJouee("Roue de secours");
                                SoundManager.PlaySoound("feu-vert");
                                break;
                            case 12:
                                AfficherJoueursSelectionCrevaison();
                                break;
                            case 13:
                                AfficherJoueursSelectionLimite();
                                break;
                            case 14:
                                ChangerCarteJouee("Fin limite vitesse");
                                SoundManager.PlaySoound("finlimite");
                                break;
                            case 15:
                                SelectionIncrevable();
                                break;
                            case 16:
                                SelectionCiterne();
                                break;
                            case 17:
                                SelectionAsDuVolant();
                                break;
                            case 18:
                                SelectionPrioritaire();
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }
            ChangerCarte(effetCarteId);
            if (GameManager.carteJouée != "KM")
            {
                photonView.RPC("ChangerIdTour", PhotonTargets.AllBufferedViaServer);
            }
        }
    }

    
    public void Selection25()
    {
        GameManager.KM_1 += 1;
        if (GameManager.KM_1 > 40)
            GameManager.KM_1 = 40;
        GameManager.carteJouée = "KM";
        GameManager.KM_restant = 0;
        SoundManager.PlaySoound("25km");
        UpdateEachRound();
    }

    public void Selection50()
    {
        GameManager.KM_1 += 2;
        if (GameManager.KM_1 > 40)
            GameManager.KM_1 = 40;
        GameManager.carteJouée = "KM";
        GameManager.KM_restant = 1;
        SoundManager.PlaySoound("50km");
        UpdateEachRound();
    }

    public void Selection75()
    {
        GameManager.KM_1 += 3;
        if (GameManager.KM_1 > 40)
            GameManager.KM_1 = 40;
        GameManager.carteJouée = "KM";
        GameManager.KM_restant = 2;
        SoundManager.PlaySoound("75km");
        UpdateEachRound();
    }

    public void Selection100()
    {
        GameManager.KM_1 += 4;
        if (GameManager.KM_1 > 40)
            GameManager.KM_1 = 40;
        GameManager.carteJouée = "KM";
        GameManager.KM_restant = 3;
        SoundManager.PlaySoound("100km");
        UpdateEachRound();
    }

    public void Selection200()
    {
        GameManager.KM_1 += 8;
        if (GameManager.KM_1 > 40)
            GameManager.KM_1 = 40;
        GameManager.carteJouée = "KM";
        GameManager.KM_restant = 7;
        SoundManager.PlaySoound("deja-vu");
        UpdateEachRound();
    }


    public void AfficherJoueursSelectionStop()
    {
        GameManager.selectionJoueursPanel.SetActive(true);
        GameManager.carteJouée = "Stop";
        SoundManager.PlaySoound("stop");
    }

    public void AfficherJoueursSelectionAccident()
    {
        GameManager.selectionJoueursPanel.SetActive(true);
        GameManager.carteJouée = "Accident";
        SoundManager.PlaySoound("crash");
    }

    public void AfficherJoueursSelectionPanneEssence()
    {
        GameManager.selectionJoueursPanel.SetActive(true);
        GameManager.carteJouée = "PanneEssence";
        SoundManager.PlaySoound("panne");
    }

    public void AfficherJoueursSelectionCrevaison()
    {
        GameManager.selectionJoueursPanel.SetActive(true);
        GameManager.carteJouée = "Crevaison";
        SoundManager.PlaySoound("creve");
    }

    public void AfficherJoueursSelectionLimite()
    {
        GameManager.selectionJoueursPanel.SetActive(true);
        GameManager.carteJouée = "LimiteVitesse";
        SoundManager.PlaySoound("limite");
    }

    public void SelectionIncrevable()
    {
        GameManager.carteJouée = "Increvable";
        SoundManager.PlaySoound("increvable");
    }

    public void SelectionCiterne()
    {
        GameManager.carteJouée = "Citerne";
        SoundManager.PlaySoound("citerne");
    }

    public void SelectionAsDuVolant()
    {
        GameManager.carteJouée = "AsDuVolant";
        SoundManager.PlaySoound("fastfurious");
    }

    public void SelectionPrioritaire()
    {
        GameManager.carteJouée = "Prioritaire";
        SoundManager.PlaySoound("prioritaire");
    }

    public void ChangerCarteJouee(string cartejouee)
    {
        GameManager.carteJouée = cartejouee;
    }


}
