using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public GameObject playerPrefab;

    public GameObject playerCamera;
    public PhotonView photonView;
    public TextMeshProUGUI playerNameText;

    private Vector3 voiturepos;


    public static bool move_yes_no1;
    public static bool peutRouler1;
    public static bool hasNotAccident1;
    public static bool hasEssence1;
    public static bool hasNotCrevaison1;
    public static bool hasNotLimite1;
    public static bool hasNotIncrevable1;
    public static bool hasNotCiterneEssence1;
    public static bool hasNotAsDuVolant1;
    public static bool hasNotPrioritaire1;

    public static bool move_yes_no2;
    public static bool peutRouler2;
    public static bool hasNotAccident2;
    public static bool hasEssence2;
    public static bool hasNotCrevaison2;
    public static bool hasNotLimite2;
    public static bool hasNotIncrevable2;
    public static bool hasNotCiterneEssence2;
    public static bool hasNotAsDuVolant2;
    public static bool hasNotPrioritaire2;

    public static bool move_yes_no3;
    public static bool peutRouler3;
    public static bool hasNotAccident3;
    public static bool hasEssence3;
    public static bool hasNotCrevaison3;
    public static bool hasNotLimite3;
    public static bool hasNotIncrevable3;
    public static bool hasNotCiterneEssence3;
    public static bool hasNotAsDuVolant3;
    public static bool hasNotPrioritaire3;

    public static bool move_yes_no4;
    public static bool peutRouler4;
    public static bool hasNotAccident4;
    public static bool hasEssence4;
    public static bool hasNotCrevaison4;
    public static bool hasNotLimite4;
    public static bool hasNotIncrevable4;
    public static bool hasNotCiterneEssence4;
    public static bool hasNotAsDuVolant4;
    public static bool hasNotPrioritaire4;

    public static int joueurSelectionne;


    private Text etatJoueur1;
    private Text etatJoueur2;
    private Text etatJoueur3;
    private Text etatJoueur4;

    private Text insensibiliteJoueur1;
    private Text insensibiliteJoueur2;
    private Text insensibiliteJoueur3;
    private Text insensibiliteJoueur4;

    private void Awake()
    {
        if(photonView.isMine)
        {
            playerCamera.SetActive(true);
            playerNameText.text = PhotonNetwork.playerName;
        }
        else
        {
            playerNameText.text = photonView.owner.name;
            playerNameText.color = Color.red;
        }

        etatJoueur1 = GameObject.Find("Joueur1Etat").GetComponent<Text>();
        etatJoueur2 = GameObject.Find("Joueur2Etat").GetComponent<Text>();
        etatJoueur3 = GameObject.Find("Joueur3Etat").GetComponent<Text>();
        etatJoueur4 = GameObject.Find("Joueur4Etat").GetComponent<Text>();

        insensibiliteJoueur1 = GameObject.Find("Joueur1Insensibilite").GetComponent<Text>();
        insensibiliteJoueur2 = GameObject.Find("Joueur2Insensibilite").GetComponent<Text>();
        insensibiliteJoueur3 = GameObject.Find("Joueur3Insensibilite").GetComponent<Text>();
        insensibiliteJoueur4 = GameObject.Find("Joueur4Insensibilite").GetComponent<Text>();
    }

    void Start()
    {
        voiturepos = playerPrefab.transform.position;

        move_yes_no1 = true;
        peutRouler1 = true;
        hasNotAccident1 = true;
        hasEssence1 = true;
        hasNotCrevaison1 = true;
        hasNotLimite1 = true;
        hasNotIncrevable1 = true;
        hasNotCiterneEssence1 = true;
        hasNotAsDuVolant1 = true;
        hasNotPrioritaire1 = true;

        move_yes_no2 = true;
        peutRouler2 = true;
        hasNotAccident2 = true;
        hasEssence2 = true;
        hasNotCrevaison2 = true;
        hasNotLimite2 = true;
        hasNotIncrevable2 = true;
        hasNotCiterneEssence2 = true;
        hasNotAsDuVolant2 = true;
        hasNotPrioritaire2 = true;

        move_yes_no3 = true;
        peutRouler3 = true;
        hasNotAccident3 = true;
        hasEssence3 = true;
        hasNotCrevaison3 = true;
        hasNotLimite3 = true;
        hasNotIncrevable3 = true;
        hasNotCiterneEssence3 = true;
        hasNotAsDuVolant3 = true;
        hasNotPrioritaire3 = true;

        move_yes_no4 = true;
        peutRouler4 = true;
        hasNotAccident4 = true;
        hasEssence4 = true;
        hasNotCrevaison4 = true;
        hasNotLimite4 = true;
        hasNotIncrevable4 = true;
        hasNotCiterneEssence4 = true;
        hasNotAsDuVolant4 = true;
        hasNotPrioritaire4 = true;

        photonView.RPC("ResetEtatStart", PhotonTargets.AllBufferedViaServer);

        joueurSelectionne = 0;

    }


    [PunRPC]
    private void ResetEtatStart()
    {
        etatJoueur1.text = "Joueur 1";
        etatJoueur2.text = "Joueur 2";
        etatJoueur3.text = "Joueur 3";
        etatJoueur4.text = "Joueur 4";
    }


    private void Update()
    {
        if (photonView.isMine)
        {
            switch (GameManager.carteJouée)
            {
                case "KM":
                    MoveVoiture();
                    GameManager.carteJouée = "";
                    break;
                case "Stop":
                    if (joueurSelectionne != 0)
                    {
                        Stop();
                        GameManager.carteJouée = "";
                        photonView.RPC("DeselectJoueur", PhotonTargets.AllBuffered);
                    }
                    break;
                case "Accident":
                    if (joueurSelectionne != 0)
                    {
                        Accident();
                        GameManager.carteJouée = "";
                        photonView.RPC("DeselectJoueur", PhotonTargets.AllBuffered);
                    }
                    break;
                case "PanneEssence":
                    if (joueurSelectionne != 0)
                    {
                        PanneEssence();
                        GameManager.carteJouée = "";
                        photonView.RPC("DeselectJoueur", PhotonTargets.AllBuffered);
                    }
                    break;
                case "Crevaison":
                    if (joueurSelectionne != 0)
                    {
                        Crevaison();
                        GameManager.carteJouée = "";
                        photonView.RPC("DeselectJoueur", PhotonTargets.AllBuffered);
                    }
                    break;
                case "LimiteVitesse":
                    if (joueurSelectionne != 0)
                    {
                        LimiteVitesse();
                        GameManager.carteJouée = "";
                        photonView.RPC("DeselectJoueur", PhotonTargets.AllBuffered);
                    }
                    break;
                case "Increvable":
                    Increvable();
                    GameManager.carteJouée = "";
                    break;
                case "Citerne":
                    CiterneEssence();
                    GameManager.carteJouée = "";
                    break;
                case "AsDuVolant":
                    AsDuVolant();
                    GameManager.carteJouée = "";
                    break;
                case "Prioritaire":
                    Prioritaire();
                    GameManager.carteJouée = "";
                    break;
                case "Roulez":
                    Roulez();
                    break;
                case "Reparations":
                    Reparations();
                    break;
                case "Essence":
                    Essence();
                    break;
                case "Roue de secours":
                    RoueDeSecours();
                    break;
                case "Fin limite vitesse":
                    FinLimitteVitesse();
                    break;
                default:
                    break;
            }
        }
    }


    [PunRPC]
    private void DeselectJoueur()
    {
        joueurSelectionne = 0;
    }

    public void MoveVoiture()
    {
        voiturepos = playerPrefab.transform.position;
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
        voiturepos.y += 4f;

        photonView.RPC("VoitureNewPos", PhotonTargets.AllBuffered);

        if (GameManager.KM_1 <= 38)
        {
            GameObject nextNode = GameObject.Find("Node" + (GameManager.KM_1 + 1));
            playerPrefab.transform.eulerAngles = new Vector3(nextNode.transform.eulerAngles.x, nextNode.transform.eulerAngles.y + 90f, nextNode.transform.eulerAngles.z);
        }
        else
        {
            playerPrefab.transform.eulerAngles = GameObject.Find("Node40").transform.eulerAngles;
        }
    }

    [PunRPC]
    private void VoitureNewPos()
    {
        playerPrefab.transform.position = voiturepos;
    }


    public void OnClickMalus()
    {
        switch (GameManager.carteJouée)
        {
            case "Stop":
                photonView.RPC("Stop", PhotonTargets.AllViaServer);
                break;
            case "Accident":
                photonView.RPC("Accident", PhotonTargets.AllViaServer);
                break;
            default:
                break;
        }
        GameManager.carteJouée = "";
        GameManager.selectionJoueursPanel.SetActive(false);
        joueurSelectionne = 0;
    }


    public void Stop()
    {

        if (joueurSelectionne <= PhotonNetwork.room.PlayerCount)
        {
            switch (joueurSelectionne)
            {
                case 1:
                    if (move_yes_no1 && hasNotLimite1)
                    {
                        if (hasNotPrioritaire1)
                        {
                            photonView.RPC("ChangeStateStop", PhotonTargets.AllBuffered, 1, false, false, "Joueur 1 Stop");
                        }
                        else
                        {
                            photonView.RPC("RemovePrioritaire", PhotonTargets.AllBuffered, 1, true, "");
                        }
                    }
                    break;
                case 2:
                    if (move_yes_no2 && hasNotLimite2)
                    {
                        if (hasNotPrioritaire2)
                        {
                            photonView.RPC("ChangeStateStop", PhotonTargets.AllBuffered, 2, false, false, "Joueur 2 Stop");
                        }
                        else
                        {
                            photonView.RPC("RemovePrioritaire", PhotonTargets.AllBuffered, 2, true, "");
                        }
                    }
                    break;
                case 3:
                    if (move_yes_no3 && hasNotLimite3)
                    {
                        if (hasNotPrioritaire3)
                        {
                            photonView.RPC("ChangeStateStop", PhotonTargets.AllBuffered, 3, false, false, "Joueur 3 Stop");
                        }
                        else
                        {
                            photonView.RPC("RemovePrioritaire", PhotonTargets.AllBuffered, 3, true, "");
                        }
                    }
                    break;
                case 4:
                    if (move_yes_no4 && hasNotLimite4)
                    {
                        if (hasNotPrioritaire4)
                        {
                            photonView.RPC("ChangeStateStop", PhotonTargets.AllBuffered, 4, false, false, "Joueur 4 Stop");
                        }
                        else
                        {
                            photonView.RPC("RemovePrioritaire", PhotonTargets.AllBuffered, 4, true, "");
                        }
                    }
                    break;
                default:
                    break;
            }
        }

    }

    [PunRPC]
    private void RemovePrioritaire(int joueur, bool newStateInsensibilite, string text)
    {
        switch (joueur)
        {
            case 1:
                hasNotPrioritaire1 = newStateInsensibilite;
                insensibiliteJoueur1.text = text;
                break;
            case 2:
                hasNotPrioritaire2 = newStateInsensibilite;
                insensibiliteJoueur2.text = text;
                break;
            case 3:
                hasNotPrioritaire3 = newStateInsensibilite;
                insensibiliteJoueur3.text = text;
                break;
            case 4:
                hasNotPrioritaire4 = newStateInsensibilite;
                insensibiliteJoueur4.text = text;
                break;
            default:
                break;
        }
    }

    [PunRPC]
    private void ChangeStateStop(int joueur, bool peutRouler, bool moveYesNo, string text)
    {
        switch (joueur)
        {
            case 1:
                peutRouler1 = peutRouler;
                move_yes_no1 = moveYesNo;
                etatJoueur1.text = text;
                break;
            case 2:
                peutRouler2 = peutRouler;
                move_yes_no2 = moveYesNo;
                etatJoueur2.text = text;
                break;
            case 3:
                peutRouler3 = peutRouler;
                move_yes_no3 = moveYesNo;
                etatJoueur3.text = text;
                break;
            case 4:
                peutRouler4 = peutRouler;
                move_yes_no4 = moveYesNo;
                etatJoueur4.text = text;
                break;

        }
    }


    public void Accident()
    {
        if (joueurSelectionne <= PhotonNetwork.room.PlayerCount)
        {
            switch (joueurSelectionne)
            {
                case 1:
                    if (move_yes_no1 && hasNotLimite1)
                    {
                        if (hasNotAsDuVolant1)
                        {
                            photonView.RPC("ChangeStateAccident", PhotonTargets.AllBuffered, 1, false, false, "Joueur 1 Accident");
                        }
                        else
                        {
                            photonView.RPC("RemoveAsDuVolant", PhotonTargets.AllBuffered, 1, true, "");
                        }
                    }
                    break;
                case 2:
                    if (move_yes_no2 && hasNotLimite2)
                    {
                        if (hasNotAsDuVolant2)
                        {
                            photonView.RPC("ChangeStateAccident", PhotonTargets.AllBuffered, 2, false, false, "Joueur 2 Accident");
                        }
                        else
                        {
                            photonView.RPC("RemoveAsDuVolant", PhotonTargets.AllBuffered, 2, true, "");
                        }
                    }
                    break;
                case 3:
                    if (move_yes_no3 && hasNotLimite3)
                    {
                        if (hasNotAsDuVolant3)
                        {
                            photonView.RPC("ChangeStateAccident", PhotonTargets.AllBuffered, 3, false, false, "Joueur 3 Accident");
                        }
                        else
                        {
                            photonView.RPC("RemoveAsDuVolant", PhotonTargets.AllBuffered, 3, true, "");
                        }
                    }
                    break;
                case 4:
                    if (move_yes_no4 && hasNotLimite4)
                    {
                        if (hasNotAsDuVolant4)
                        {
                            photonView.RPC("ChangeStateAccident", PhotonTargets.AllBuffered, 4, false, false, "Joueur 4 Accident");
                        }
                        else
                        {
                            photonView.RPC("RemoveAsDuVolant", PhotonTargets.AllBuffered, 4, true, "");
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }

    [PunRPC]
    private void RemoveAsDuVolant(int joueur, bool newStateInsensibilite, string text)
    {
        switch (joueur)
        {
            case 1:
                hasNotAsDuVolant1 = newStateInsensibilite;
                insensibiliteJoueur1.text = text;
                break;
            case 2:
                hasNotAsDuVolant2 = newStateInsensibilite;
                insensibiliteJoueur2.text = text;
                break;
            case 3:
                hasNotAsDuVolant3 = newStateInsensibilite;
                insensibiliteJoueur3.text = text;
                break;
            case 4:
                hasNotAsDuVolant4 = newStateInsensibilite;
                insensibiliteJoueur4.text = text;
                break;
            default:
                break;
        }
    }


    [PunRPC]
    private void ChangeStateAccident(int joueur, bool hasNotAccident, bool moveYesNo, string text)
    {
        switch (joueur)
        {
            case 1:
                hasNotAccident1 = hasNotAccident;
                move_yes_no1 = moveYesNo;
                etatJoueur1.text = text;
                break;
            case 2:
                hasNotAccident2 = hasNotAccident;
                move_yes_no2 = moveYesNo;
                etatJoueur2.text = text;
                break;
            case 3:
                hasNotAccident3 = hasNotAccident;
                move_yes_no3 = moveYesNo;
                etatJoueur3.text = text;
                break;
            case 4:
                hasNotAccident4 = hasNotAccident;
                move_yes_no4 = moveYesNo;
                etatJoueur4.text = text;
                break;

        }
    }


    public void PanneEssence()
    {
        if (joueurSelectionne <= PhotonNetwork.room.PlayerCount)
        {
            switch (joueurSelectionne)
            {
                case 1:
                    if (move_yes_no1 && hasNotLimite1)
                    {
                        if (hasNotCiterneEssence1)
                        {
                            photonView.RPC("ChangeStateEssence", PhotonTargets.AllBuffered, 1, false, false, "Joueur 1 Panne d'essence");
                        }
                        else
                        {
                            photonView.RPC("RemoveCiterne", PhotonTargets.AllBuffered, 1, true, "");
                        }
                    }
                    break;
                case 2:
                    if (move_yes_no2 && hasNotLimite2)
                    {
                        if (hasNotCiterneEssence2)
                        {
                            photonView.RPC("ChangeStateEssence", PhotonTargets.AllBuffered, 2, false, false, "Joueur 2 Panne d'essence");
                        }
                        else
                        {
                            photonView.RPC("RemoveCiterne", PhotonTargets.AllBuffered, 2, true, "");
                        }
                    }
                    break;
                case 3:
                    if (move_yes_no3 && hasNotLimite3)
                    {
                        if (hasNotCiterneEssence3)
                        {
                            photonView.RPC("ChangeStateEssence", PhotonTargets.AllBuffered, 3, false, false, "Joueur 3 Panne d'essence");
                        }
                        else
                        {
                            photonView.RPC("RemoveCiterne", PhotonTargets.AllBuffered, 3, true, "");
                        }
                    }
                    break;
                case 4:
                    if (move_yes_no4 && hasNotLimite4)
                    {
                        if (hasNotCiterneEssence4)
                        {
                            photonView.RPC("ChangeStateEssence", PhotonTargets.AllBuffered, 4, false, false, "Joueur 4 Panne d'essence");
                        }
                        else
                        {
                            photonView.RPC("RemoveCiterne", PhotonTargets.AllBuffered, 4, true, "");
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }

    [PunRPC]
    private void RemoveCiterne(int joueur, bool newStateInsensibilite, string text)
    {
        switch (joueur)
        {
            case 1:
                hasNotCiterneEssence1 = newStateInsensibilite;
                insensibiliteJoueur1.text = text;
                break;
            case 2:
                hasNotCiterneEssence2 = newStateInsensibilite;
                insensibiliteJoueur2.text = text;
                break;
            case 3:
                hasNotCiterneEssence3 = newStateInsensibilite;
                insensibiliteJoueur3.text = text;
                break;
            case 4:
                hasNotCiterneEssence4 = newStateInsensibilite;
                insensibiliteJoueur4.text = text;
                break;
            default:
                break;
        }
    }

    [PunRPC]
    private void ChangeStateEssence(int joueur, bool newStatusMalus, bool moveYesNo, string text)
    {
        switch (joueur)
        {
            case 1:
                hasEssence1 = newStatusMalus;
                move_yes_no1 = moveYesNo;
                etatJoueur1.text = text;
                break;
            case 2:
                hasEssence2 = newStatusMalus;
                move_yes_no2 = moveYesNo;
                etatJoueur2.text = text;
                break;
            case 3:
                hasEssence3 = newStatusMalus;
                move_yes_no3 = moveYesNo;
                etatJoueur3.text = text;
                break;
            case 4:
                hasEssence4 = newStatusMalus;
                move_yes_no4 = moveYesNo;
                etatJoueur4.text = text;
                break;

        }
    }


    public void Crevaison()
    {
        if (joueurSelectionne <= PhotonNetwork.room.PlayerCount)
        {
            switch (joueurSelectionne)
            {
                case 1:
                    if (move_yes_no1 && hasNotLimite1)
                    {
                        if (hasNotIncrevable1)
                        {
                            photonView.RPC("ChangeStateCrevaison", PhotonTargets.AllBuffered, 1, false, false, "Joueur 1 Crevaison");
                        }
                        else
                        {
                            photonView.RPC("RemoveIncrevable", PhotonTargets.AllBuffered, 1, true, "");
                        }
                    }
                    break;
                case 2:
                    if (move_yes_no2 && hasNotLimite2)
                    {
                        if (hasNotIncrevable2)
                        {
                            photonView.RPC("ChangeStateCrevaison", PhotonTargets.AllBuffered, 2, false, false, "Joueur 2 Crevaison");
                        }
                        else
                        {
                            photonView.RPC("RemoveIncrevable", PhotonTargets.AllBuffered, 2, true, "");
                        }
                    }
                    break;
                case 3:
                    if (move_yes_no3 && hasNotLimite3)
                    {
                        if (hasNotIncrevable3)
                        {
                            photonView.RPC("ChangeStateCrevaison", PhotonTargets.AllBuffered, 3, false, false, "Joueur 3 Crevaison");
                        }
                        else
                        {
                            photonView.RPC("RemoveIncrevable", PhotonTargets.AllBuffered, 3, true, "");
                        }
                    }
                    break;
                case 4:
                    if (move_yes_no4 && hasNotLimite4)
                    {
                        if (hasNotIncrevable4)
                        {
                            photonView.RPC("ChangeStateCrevaison", PhotonTargets.AllBuffered, 4, false, false, "Joueur 4 Crevaison");
                        }
                        else
                        {
                            photonView.RPC("RemoveIncrevable", PhotonTargets.AllBuffered, 4, true, "");
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }

    [PunRPC]
    private void RemoveIncrevable(int joueur, bool newStateInsensibilite, string text)
    {
        switch(joueur)
        {
            case 1:
                hasNotIncrevable1 = newStateInsensibilite;
                insensibiliteJoueur1.text = text;
                break;
            case 2:
                hasNotIncrevable2 = newStateInsensibilite;
                insensibiliteJoueur2.text = text;
                break;
            case 3:
                hasNotIncrevable3 = newStateInsensibilite;
                insensibiliteJoueur3.text = text;
                break;
            case 4:
                hasNotIncrevable4 = newStateInsensibilite;
                insensibiliteJoueur4.text = text;
                break;
            default:
                break;
        }
    }

    [PunRPC]
    private void ChangeStateCrevaison(int joueur, bool newStatusMalus, bool moveYesNo, string text)
    {
        switch (joueur)
        {
            case 1:
                hasNotCrevaison1 = newStatusMalus;
                move_yes_no1 = moveYesNo;
                etatJoueur1.text = text;
                break;
            case 2:
                hasNotCrevaison2 = newStatusMalus;
                move_yes_no2 = moveYesNo;
                etatJoueur2.text = text;
                break;
            case 3:
                hasNotCrevaison3 = newStatusMalus;
                move_yes_no3 = moveYesNo;
                etatJoueur3.text = text;
                break;
            case 4:
                hasNotCrevaison4 = newStatusMalus;
                move_yes_no4 = moveYesNo;
                etatJoueur4.text = text;
                break;

        }
    }

    public void LimiteVitesse()
    {
        if (joueurSelectionne <= PhotonNetwork.room.PlayerCount)
        {
            switch (joueurSelectionne)
            {
                case 1:
                    if (move_yes_no1)
                    {
                        if (hasNotPrioritaire1)
                        {
                            photonView.RPC("ChangeStateLimiteVitesse", PhotonTargets.AllBuffered, 1, false, "Joueur 1 Limite vitesse");
                        }
                        else
                        {
                            photonView.RPC("RemovePrioritaire", PhotonTargets.AllBuffered, 1, true, "");
                        }
                    }
                    break;
                case 2:
                    if (move_yes_no2)
                    {
                        if (hasNotPrioritaire2)
                        {
                            photonView.RPC("ChangeStateLimiteVitesse", PhotonTargets.AllBuffered, 2, false, "Joueur 2 Limite vitesse");
                        }
                        else
                        {
                            photonView.RPC("RemovePrioritaire", PhotonTargets.AllBuffered, 2, true, "");
                        }

                    }
                    break;
                case 3:
                    if (move_yes_no3)
                    {
                        if (hasNotPrioritaire3)
                        {
                            photonView.RPC("ChangeStateLimiteVitesse", PhotonTargets.AllBuffered, 3, false, "Joueur 3 Limite vitesse");
                        }
                        else
                        {
                            photonView.RPC("RemovePrioritaire", PhotonTargets.AllBuffered, 3, true, "");
                        }
                    }
                    break;
                case 4:
                    if (move_yes_no4)
                    {
                        if (hasNotPrioritaire4)
                        {
                            photonView.RPC("ChangeStateLimiteVitesse", PhotonTargets.AllBuffered, 4, false, "Joueur 4 Limite vitesse");
                        }
                        else
                        {
                            photonView.RPC("RemovePrioritaire", PhotonTargets.AllBuffered, 4, true, "");
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }

    [PunRPC]
    private void ChangeStateLimiteVitesse(int joueur, bool newStatusMalus, string text)
    {
        switch (joueur)
        {
            case 1:
                hasNotLimite1 = newStatusMalus;
                etatJoueur1.text = text;
                break;
            case 2:
                hasNotLimite2 = newStatusMalus;
                etatJoueur2.text = text;
                break;
            case 3:
                hasNotLimite3 = newStatusMalus;
                etatJoueur3.text = text;
                break;
            case 4:
                hasNotLimite4 = newStatusMalus;
                etatJoueur4.text = text;
                break;

        }
    }

    public void Increvable()
    {
        RoueDeSecours();
        switch (PhotonNetwork.player.ID)
        {
            case 1:
                photonView.RPC("ChangeStateIncrevable", PhotonTargets.AllBuffered, 1, false, "Increvable");
                break;
            case 2:
                photonView.RPC("ChangeStateIncrevable", PhotonTargets.AllBuffered, 2, false, "Increvable");
                break;
            case 3:
                photonView.RPC("ChangeStateIncrevable", PhotonTargets.AllBuffered, 3, false, "Increvable");
                break;
            case 4:
                photonView.RPC("ChangeStateIncrevable", PhotonTargets.AllBuffered, 4, false, "Increvable");
                break;
            default:
                break;
        }
    }

    [PunRPC]
    private void ChangeStateIncrevable(int joueur, bool newStatusMalus, string text)
    {
        switch (joueur)
        {
            case 1:
                hasNotIncrevable1 = newStatusMalus;
                insensibiliteJoueur1.text = text;
                hasNotCiterneEssence1 = true;
                hasNotPrioritaire1 = true;
                hasNotAsDuVolant1 = true;
                break;
            case 2:
                hasNotIncrevable2 = newStatusMalus;
                insensibiliteJoueur2.text = text;
                hasNotCiterneEssence2 = true;
                hasNotPrioritaire2 = true;
                hasNotAsDuVolant2 = true;
                break;
            case 3:
                hasNotIncrevable3 = newStatusMalus;
                insensibiliteJoueur3.text = text;
                hasNotCiterneEssence3 = true;
                hasNotPrioritaire3 = true;
                hasNotAsDuVolant3 = true;
                break;
            case 4:
                hasNotIncrevable4 = newStatusMalus;
                insensibiliteJoueur4.text = text;
                hasNotCiterneEssence4 = true;
                hasNotPrioritaire4 = true;
                hasNotAsDuVolant4 = true;
                break;
        }
    }

    public void CiterneEssence()
    {
        Essence();
        switch (PhotonNetwork.player.ID)
        {
            case 1:
                photonView.RPC("ChangeStateCiterneEssence", PhotonTargets.AllBuffered, 1, false, "Citerne essence");
                break;
            case 2:
                photonView.RPC("ChangeStateCiterneEssence", PhotonTargets.AllBuffered, 2, false, "Citerne essence");
                break;
            case 3:
                photonView.RPC("ChangeStateCiterneEssence", PhotonTargets.AllBuffered, 3, false, "Citerne essence");
                break;
            case 4:
                photonView.RPC("ChangeStateCiterneEssence", PhotonTargets.AllBuffered, 4, false, "Citerne essence");
                break;
            default:
                break;
        }       
    }

    [PunRPC]
    private void ChangeStateCiterneEssence(int joueur, bool newStatusMalus, string text)
    {
        switch (joueur)
        {
            case 1:
                hasNotCiterneEssence1 = newStatusMalus;
                insensibiliteJoueur1.text = text;
                hasNotIncrevable1 = true;
                hasNotPrioritaire1 = true;
                hasNotAsDuVolant1 = true;
                break;
            case 2:
                hasNotCiterneEssence2 = newStatusMalus;
                insensibiliteJoueur2.text = text;
                hasNotIncrevable2 = true;
                hasNotPrioritaire2 = true;
                hasNotAsDuVolant2 = true;
                break;
            case 3:
                hasNotCiterneEssence3 = newStatusMalus;
                insensibiliteJoueur3.text = text;
                hasNotIncrevable3 = true;
                hasNotPrioritaire3 = true;
                hasNotAsDuVolant3 = true;
                break;
            case 4:
                hasNotCiterneEssence4 = newStatusMalus;
                insensibiliteJoueur4.text = text;
                hasNotIncrevable4 = true;
                hasNotPrioritaire4 = true;
                hasNotAsDuVolant4 = true;
                break;
        }
    }

    public void AsDuVolant()
    {
        Reparations();
        switch (PhotonNetwork.player.ID)
        {
            case 1:
                photonView.RPC("ChangeStateAsDuVolant", PhotonTargets.AllBuffered, 1, false, "Fast & Furious");
                break;
            case 2:
                photonView.RPC("ChangeStateAsDuVolant", PhotonTargets.AllBuffered, 2, false, "Fast & Furious");
                break;
            case 3:
                photonView.RPC("ChangeStateAsDuVolant", PhotonTargets.AllBuffered, 3, false, "Fast & Furious");
                break;
            case 4:
                photonView.RPC("ChangeStateAsDuVolant", PhotonTargets.AllBuffered, 4, false, "Fast & Furious");
                break;
            default:
                break;
        }
    }

    [PunRPC]
    private void ChangeStateAsDuVolant(int joueur, bool newStatusMalus, string text)
    {
        switch (joueur)
        {
            case 1:
                hasNotAsDuVolant1 = newStatusMalus;
                insensibiliteJoueur1.text = text;
                hasNotIncrevable1 = true;
                hasNotCiterneEssence1 = true;
                hasNotPrioritaire1 = true;
                break;
            case 2:
                hasNotAsDuVolant2 = newStatusMalus;
                insensibiliteJoueur2.text = text;
                hasNotIncrevable2 = true;
                hasNotCiterneEssence2 = true;
                hasNotPrioritaire2 = true;
                break;
            case 3:
                hasNotAsDuVolant3 = newStatusMalus;
                insensibiliteJoueur3.text = text;
                hasNotIncrevable3 = true;
                hasNotCiterneEssence3 = true;
                hasNotPrioritaire3 = true;
                break;
            case 4:
                hasNotAsDuVolant4 = newStatusMalus;
                insensibiliteJoueur4.text = text;
                hasNotIncrevable4 = true;
                hasNotCiterneEssence4 = true;
                hasNotPrioritaire4 = true;
                break;

        }
    }

    public void Prioritaire()
    {
        Roulez();
        FinLimitteVitesse();
        switch (PhotonNetwork.player.ID)
        {
            case 1:
                photonView.RPC("ChangeStatePrioritaire", PhotonTargets.AllBuffered, 1, false, "Prioritaire");
                break;
            case 2:
                photonView.RPC("ChangeStatePrioritaire", PhotonTargets.AllBuffered, 2, false, "Prioritaire");
                break;
            case 3:
                photonView.RPC("ChangeStatePrioritaire", PhotonTargets.AllBuffered, 3, false, "Prioritaire");
                break;
            case 4:
                photonView.RPC("ChangeStatePrioritaire", PhotonTargets.AllBuffered, 4, false, "Prioritaire");
                break;
            default:
                break;
        }
    }

    [PunRPC]
    private void ChangeStatePrioritaire(int joueur, bool newStatusMalus, string text)
    {
        switch (joueur)
        {
            case 1:
                hasNotPrioritaire1 = newStatusMalus;
                insensibiliteJoueur1.text = text;
                hasNotIncrevable1 = true;
                hasNotCiterneEssence1 = true;
                hasNotAsDuVolant1 = true;
                break;
            case 2:
                hasNotPrioritaire2 = newStatusMalus;
                insensibiliteJoueur2.text = text;
                hasNotIncrevable2 = true;
                hasNotCiterneEssence2 = true;
                hasNotAsDuVolant2 = true;
                break;
            case 3:
                hasNotPrioritaire3 = newStatusMalus;
                insensibiliteJoueur3.text = text;
                hasNotIncrevable3 = true;
                hasNotCiterneEssence3 = true;
                hasNotAsDuVolant3 = true;
                break;
            case 4:
                hasNotPrioritaire4 = newStatusMalus;
                insensibiliteJoueur4.text = text;
                hasNotIncrevable4 = true;
                hasNotCiterneEssence4 = true;
                hasNotAsDuVolant4 = true;
                break;

        }
    }

    [PunRPC]
    private void ChangerEtatBonJoueur1()
    {
        peutRouler1 = true;
        move_yes_no1 = true;
        hasNotAccident1 = true;
        hasEssence1 = true;
        hasNotCrevaison1 = true;
        hasNotLimite1 = true;
        etatJoueur1.text = "Joueur 1 ";
    }

    [PunRPC]
    private void ChangerEtatBonJoueur2()
    {
        peutRouler2 = true;
        move_yes_no2 = true;
        hasNotAccident2 = true;
        hasEssence2 = true;
        hasNotCrevaison2 = true;
        hasNotLimite2 = true;
        etatJoueur2.text = "Joueur 2 ";
    }

    [PunRPC]
    private void ChangerEtatBonJoueur3()
    {
        peutRouler3 = true;
        move_yes_no3 = true;
        hasNotAccident3 = true;
        hasEssence3 = true;
        hasNotCrevaison3 = true;
        hasNotLimite3 = true;
        etatJoueur3.text = "Joueur 3 ";
    }

    [PunRPC]
    private void ChangerEtatBonJoueur4()
    {
        peutRouler4 = true;
        move_yes_no4 = true;
        hasNotAccident4 = true;
        hasEssence4 = true;
        hasNotCrevaison4 = true;
        hasNotLimite4 = true;
        etatJoueur4.text = "Joueur 4 ";
    }

    public void Roulez()
    {
        switch (PhotonNetwork.player.ID)
        {
            case 1:
                if (!peutRouler1)
                {
                    photonView.RPC("ChangerEtatBonJoueur1", PhotonTargets.AllViaServer);
                }
                break;
            case 2:
                if (!peutRouler2)
                {
                    photonView.RPC("ChangerEtatBonJoueur2", PhotonTargets.AllViaServer);
                }
                break;
            case 3:
                if (!peutRouler3)
                {
                    photonView.RPC("ChangerEtatBonJoueur3", PhotonTargets.AllViaServer);
                }
                break;
            case 4:
                if (!peutRouler4)
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
                if (!hasNotAccident1)
                {
                    photonView.RPC("ChangerEtatBonJoueur1", PhotonTargets.AllViaServer);
                }
                break;
            case 2:
                if (!hasNotAccident2)
                {
                    photonView.RPC("ChangerEtatBonJoueur2", PhotonTargets.AllViaServer);
                }
                break;
            case 3:
                if (!hasNotAccident3)
                {
                    photonView.RPC("ChangerEtatBonJoueur3", PhotonTargets.AllViaServer);
                }
                break;
            case 4:
                if (!hasNotAccident4)
                {
                    photonView.RPC("ChangerEtatBonJoueur4", PhotonTargets.AllViaServer);
                }
                break;
            default:
                break;
        }
    }

    public void Essence()
    {
        switch (PhotonNetwork.player.ID)
        {
            case 1:
                if (!hasEssence1)
                {
                    photonView.RPC("ChangerEtatBonJoueur1", PhotonTargets.AllViaServer);
                }
                break;
            case 2:
                if (!hasEssence2)
                {
                    photonView.RPC("ChangerEtatBonJoueur2", PhotonTargets.AllViaServer);
                }
                break;
            case 3:
                if (!hasEssence3)
                {
                    photonView.RPC("ChangerEtatBonJoueur3", PhotonTargets.AllViaServer);
                }
                break;
            case 4:
                if (!hasEssence4)
                {
                    photonView.RPC("ChangerEtatBonJoueur4", PhotonTargets.AllViaServer);
                }
                break;
            default:
                break;
        }
    }

    public void RoueDeSecours()
    {
        switch (PhotonNetwork.player.ID)
        {
            case 1:
                if (!hasNotCrevaison1)
                {
                    photonView.RPC("ChangerEtatBonJoueur1", PhotonTargets.AllViaServer);
                }
                break;
            case 2:
                if (!hasNotCrevaison2)
                {
                    photonView.RPC("ChangerEtatBonJoueur2", PhotonTargets.AllViaServer);
                }
                break;
            case 3:
                if (!hasNotCrevaison3)
                {
                    photonView.RPC("ChangerEtatBonJoueur3", PhotonTargets.AllViaServer);
                }
                break;
            case 4:
                if (!hasNotCrevaison4)
                {
                    photonView.RPC("ChangerEtatBonJoueur4", PhotonTargets.AllViaServer);
                }
                break;
            default:
                break;
        }
    }

    public void FinLimitteVitesse()
    {
        switch (PhotonNetwork.player.ID)
        {
            case 1:
                if (!hasNotLimite1)
                {
                    photonView.RPC("ChangerEtatBonJoueur1", PhotonTargets.AllViaServer);
                }
                break;
            case 2:
                if (!hasNotLimite2)
                {
                    photonView.RPC("ChangerEtatBonJoueur2", PhotonTargets.AllViaServer);
                }
                break;
            case 3:
                if (!hasNotLimite3)
                {
                    photonView.RPC("ChangerEtatBonJoueur3", PhotonTargets.AllViaServer);
                }
                break;
            case 4:
                if (!hasNotLimite4)
                {
                    photonView.RPC("ChangerEtatBonJoueur4", PhotonTargets.AllViaServer);
                }
                break;
            default:
                break;
        }
    }


}
