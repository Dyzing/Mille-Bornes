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

    private bool estArrive;

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
        ChangerNameColor();

        estArrive = true;
        playerPrefab.transform.eulerAngles = new Vector3(playerPrefab.transform.eulerAngles.x, playerPrefab.transform.eulerAngles.y -90f, playerPrefab.transform.eulerAngles.z);
    }


    [PunRPC]
    private void ResetEtatStart()
    {
        etatJoueur1.text = "";
        etatJoueur2.text = "";
        etatJoueur3.text = "";
        etatJoueur4.text = "";

        int nb_player = PhotonNetwork.room.PlayerCount;
        int i = 1;
        etatJoueur1.text = PhotonNetwork.player.Get(i).NickName;
        if (i < nb_player)
        {
            i++;
            etatJoueur2.text = PhotonNetwork.player.Get(i).NickName;
        }
        if (i < nb_player)
        {
            i++;
            etatJoueur3.text = PhotonNetwork.player.Get(i).NickName;
        }
        if (i < nb_player)
        {
            i++;
            etatJoueur4.text = PhotonNetwork.player.Get(i).NickName;
        }
    }

    public void ChangerNameColor()
    {
        if (photonView.isMine)
        {
            switch (photonView.owner.ID)
            {
                case 1:
                    etatJoueur1.color = Color.green;
                    insensibiliteJoueur1.color = Color.green;
                    break;
                case 2:
                    etatJoueur2.color = Color.green;
                    insensibiliteJoueur2.color = Color.green;
                    break;
                case 3:
                    etatJoueur3.color = Color.green;
                    insensibiliteJoueur3.color = Color.green;
                    break;
                case 4:
                    etatJoueur4.color = Color.green;
                    insensibiliteJoueur4.color = Color.green;
                    break;
                default:
                    break;
            }
        }
    }


    private void Update()
    {
        if (photonView.isMine)
        {
            switch (GameManager.carteJouée)
            {
                case "KM":
                    Vector3 destination;
                    if (GameManager.KM_1 - GameManager.KM_restant <= 39)
                    {
                        destination = GameObject.Find("Node" + (GameManager.KM_1 - GameManager.KM_restant)).transform.position;
                    }
                    else
                    {
                        destination = GameObject.Find("Node40").transform.position;
                        StartCoroutine(CoroutineLeaveOnWin());
                    }
                    if (playerPrefab.transform.position != destination)//(!(playerPrefab.transform.position.x > destination.x - 10 && playerPrefab.transform.position.x < destination.x + 10) || !(playerPrefab.transform.position.z > destination.z - 10 && playerPrefab.transform.position.z < destination.z + 10))
                    {
                        estArrive = false;
                        MoveVoiture();
                    }
                    else
                    {
                        if (GameManager.KM_restant > 0)
                        {
                            GameManager.KM_restant--;
                        }
                        else
                        {
                            CleanCarteJouee();
                        }
                    }
                    break;
                case "Stop":
                    if (joueurSelectionne != 0)
                    {
                        Stop();
                        CleanCarteJouee();
                        photonView.RPC("DeselectJoueur", PhotonTargets.AllBuffered);
                    }
                    break;
                case "Accident":
                    if (joueurSelectionne != 0)
                    {
                        Accident();
                        CleanCarteJouee();
                        photonView.RPC("DeselectJoueur", PhotonTargets.AllBuffered);
                    }
                    break;
                case "PanneEssence":
                    if (joueurSelectionne != 0)
                    {
                        PanneEssence();
                        CleanCarteJouee();
                        photonView.RPC("DeselectJoueur", PhotonTargets.AllBuffered);
                    }
                    break;
                case "Crevaison":
                    if (joueurSelectionne != 0)
                    {
                        Crevaison();
                        CleanCarteJouee();
                        photonView.RPC("DeselectJoueur", PhotonTargets.AllBuffered);
                    }
                    break;
                case "LimiteVitesse":
                    if (joueurSelectionne != 0)
                    {
                        LimiteVitesse();
                        CleanCarteJouee();
                        photonView.RPC("DeselectJoueur", PhotonTargets.AllBuffered);
                    }
                    break;
                case "Increvable":
                    Increvable();
                    CleanCarteJouee();
                    break;
                case "Citerne":
                    CiterneEssence();
                    CleanCarteJouee();
                    break;
                case "AsDuVolant":
                    AsDuVolant();
                    CleanCarteJouee();
                    break;
                case "Prioritaire":
                    Prioritaire();
                    CleanCarteJouee();
                    break;
                case "Roulez":
                    Roulez();
                    CleanCarteJouee();
                    break;
                case "Reparations":
                    Reparations();
                    CleanCarteJouee();
                    break;
                case "Essence":
                    Essence();
                    CleanCarteJouee();
                    break;
                case "Roue de secours":
                    RoueDeSecours();
                    CleanCarteJouee();
                    break;
                case "Fin limite vitesse":
                    FinLimitteVitesse();
                    CleanCarteJouee();
                    break;
                default:
                    break;
            }
        }
    }

    public void CleanCarteJouee()
    {
        GameManager.carteJouée = "";
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
        if (GameManager.KM_1 - GameManager.KM_restant <= 39)
        {
            destination = GameObject.Find("Node" + (GameManager.KM_1 - GameManager.KM_restant)).transform.position;
        }
        else
        {
            destination = GameObject.Find("Node40").transform.position;
            StartCoroutine(CoroutineLeaveOnWin());
        }

        voiturepos = destination;
        /*float coeffdir = (destination.z - playerPrefab.transform.position.z) / (destination.x - playerPrefab.transform.position.x);
        float newZ = coeffdir * (playerPrefab.transform.forward.x) + (playerPrefab.transform.position.z * playerPrefab.transform.position.x);*/
        playerPrefab.transform.position = Vector3.MoveTowards(playerPrefab.transform.position, voiturepos, 50 * Time.deltaTime); 
        //playerPrefab.transform.position += playerPrefab.transform.forward * Time.deltaTime * 10 ;
        //playerPrefab.transform.position = new Vector3(playerPrefab.transform.forward.x, destination.y, newZ);
        //voiturepos.y += 4f;

        photonView.RPC("VoitureNewPos", PhotonTargets.AllBuffered);
        

        if (GameManager.KM_1 - GameManager.KM_restant <= 38)
        {
            GameObject nextNode = GameObject.Find("Node" + (GameManager.KM_1 - GameManager.KM_restant));
            playerPrefab.transform.eulerAngles = new Vector3(nextNode.transform.eulerAngles.x, nextNode.transform.eulerAngles.y, nextNode.transform.eulerAngles.z);
        }
        else
        {
            playerPrefab.transform.eulerAngles = GameObject.Find("Node40").transform.eulerAngles;
        }

    }

    private IEnumerator CoroutineLeaveOnWin()
    {
        yield return new WaitForSeconds(1.5f);
        photonView.RPC("LeaveOnWin", PhotonTargets.AllBuffered);
    }

    [PunRPC]
    private void VoitureNewPos()
    {
        //playerPrefab.transform.position = voiturepos;
        //playerPrefab.transform.position += Time.deltaTime * GameObject.Find("Node" + GameManager.KM_1).transform.forward;
        playerPrefab.transform.position = Vector3.MoveTowards(playerPrefab.transform.position, voiturepos, 50 * Time.deltaTime); 
    }

    [PunRPC]
    private void LeaveOnWin()
    {
        GameManager.disconnectUI.SetActive(true);
        GameManager.Off = true;
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
                            photonView.RPC("ChangeStateStop", PhotonTargets.AllBuffered, 1, false, false, " Stop");
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
                            photonView.RPC("ChangeStateStop", PhotonTargets.AllBuffered, 2, false, false, " Stop");
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
                            photonView.RPC("ChangeStateStop", PhotonTargets.AllBuffered, 3, false, false, " Stop");
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
                            photonView.RPC("ChangeStateStop", PhotonTargets.AllBuffered, 4, false, false, " Stop");
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
                etatJoueur1.text += System.Environment.NewLine + text;
                break;
            case 2:
                peutRouler2 = peutRouler;
                move_yes_no2 = moveYesNo;
                etatJoueur2.text += System.Environment.NewLine + text;
                break;
            case 3:
                peutRouler3 = peutRouler;
                move_yes_no3 = moveYesNo;
                etatJoueur3.text += System.Environment.NewLine + text;
                break;
            case 4:
                peutRouler4 = peutRouler;
                move_yes_no4 = moveYesNo;
                etatJoueur4.text += System.Environment.NewLine + text;
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
                            photonView.RPC("ChangeStateAccident", PhotonTargets.AllBuffered, 1, false, false, " Accident");
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
                            photonView.RPC("ChangeStateAccident", PhotonTargets.AllBuffered, 2, false, false, " Accident");
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
                            photonView.RPC("ChangeStateAccident", PhotonTargets.AllBuffered, 3, false, false, " Accident");
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
                            photonView.RPC("ChangeStateAccident", PhotonTargets.AllBuffered, 4, false, false, " Accident");
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
                etatJoueur1.text += System.Environment.NewLine + text;
                break;
            case 2:
                hasNotAccident2 = hasNotAccident;
                move_yes_no2 = moveYesNo;
                etatJoueur2.text += System.Environment.NewLine + text;
                break;
            case 3:
                hasNotAccident3 = hasNotAccident;
                move_yes_no3 = moveYesNo;
                etatJoueur3.text += System.Environment.NewLine + text;
                break;
            case 4:
                hasNotAccident4 = hasNotAccident;
                move_yes_no4 = moveYesNo;
                etatJoueur4.text += System.Environment.NewLine + text;
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
                            photonView.RPC("ChangeStateEssence", PhotonTargets.AllBuffered, 1, false, false, " Panne d'essence");
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
                            photonView.RPC("ChangeStateEssence", PhotonTargets.AllBuffered, 2, false, false, " Panne d'essence");
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
                            photonView.RPC("ChangeStateEssence", PhotonTargets.AllBuffered, 3, false, false, " Panne d'essence");
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
                            photonView.RPC("ChangeStateEssence", PhotonTargets.AllBuffered, 4, false, false, " Panne d'essence");
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
                etatJoueur1.text += System.Environment.NewLine + text;
                break;
            case 2:
                hasEssence2 = newStatusMalus;
                move_yes_no2 = moveYesNo;
                etatJoueur2.text += System.Environment.NewLine + text;
                break;
            case 3:
                hasEssence3 = newStatusMalus;
                move_yes_no3 = moveYesNo;
                etatJoueur3.text += System.Environment.NewLine + text;
                break;
            case 4:
                hasEssence4 = newStatusMalus;
                move_yes_no4 = moveYesNo;
                etatJoueur4.text += System.Environment.NewLine + text;
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
                            photonView.RPC("ChangeStateCrevaison", PhotonTargets.AllBuffered, 1, false, false, " Crevaison");
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
                            photonView.RPC("ChangeStateCrevaison", PhotonTargets.AllBuffered, 2, false, false, " Crevaison");
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
                            photonView.RPC("ChangeStateCrevaison", PhotonTargets.AllBuffered, 3, false, false, " Crevaison");
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
                            photonView.RPC("ChangeStateCrevaison", PhotonTargets.AllBuffered, 4, false, false, " Crevaison");
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
                etatJoueur1.text += System.Environment.NewLine + text;
                break;
            case 2:
                hasNotCrevaison2 = newStatusMalus;
                move_yes_no2 = moveYesNo;
                etatJoueur2.text += System.Environment.NewLine + text;
                break;
            case 3:
                hasNotCrevaison3 = newStatusMalus;
                move_yes_no3 = moveYesNo;
                etatJoueur3.text += System.Environment.NewLine + text;
                break;
            case 4:
                hasNotCrevaison4 = newStatusMalus;
                move_yes_no4 = moveYesNo;
                etatJoueur4.text += System.Environment.NewLine + text;
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
                            photonView.RPC("ChangeStateLimiteVitesse", PhotonTargets.AllBuffered, 1, false, " Limite vitesse");
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
                            photonView.RPC("ChangeStateLimiteVitesse", PhotonTargets.AllBuffered, 2, false, " Limite vitesse");
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
                            photonView.RPC("ChangeStateLimiteVitesse", PhotonTargets.AllBuffered, 3, false, " Limite vitesse");
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
                            photonView.RPC("ChangeStateLimiteVitesse", PhotonTargets.AllBuffered, 4, false, " Limite vitesse");
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
                etatJoueur1.text += System.Environment.NewLine + text;
                break;
            case 2:
                hasNotLimite2 = newStatusMalus;
                etatJoueur2.text += System.Environment.NewLine + text;
                break;
            case 3:
                hasNotLimite3 = newStatusMalus;
                etatJoueur3.text += System.Environment.NewLine + text;
                break;
            case 4:
                hasNotLimite4 = newStatusMalus;
                etatJoueur4.text += System.Environment.NewLine + text;
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
        etatJoueur1.text = PhotonNetwork.player.Get(1).NickName;
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
        etatJoueur2.text = PhotonNetwork.player.Get(2).NickName;
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
        etatJoueur3.text = PhotonNetwork.player.Get(3).NickName;
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
        etatJoueur4.text = PhotonNetwork.player.Get(4).NickName;
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
