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


    private Text etatJoueur1;
    private Text etatJoueur2;
    private Text etatJoueur3;
    private Text etatJoueur4;

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
    }

    void Start()
    {
        voiturepos = playerPrefab.transform.position;

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

        photonView.RPC("ResetEtatStart", PhotonTargets.AllBufferedViaServer);

        joueurSelectionne = 0;

    }


    [PunRPC]
    private void ResetEtatStart()
    {
        etatJoueur1.text = "Player 1";
        etatJoueur2.text = "Player 2";
        etatJoueur3.text = "Player 3";
        etatJoueur4.text = "Player 4";
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
                case "Roulez":
                    Roulez();
                    break;
                case "Reparations":
                    Reparations();
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
        Debug.Log("*** Stop AVANT ***");
        Debug.Log("*** peutRouler1 : " + peutRouler1);
        Debug.Log("*** peutRouler2 : " + peutRouler2);
        Debug.Log("*** peutRouler3 : " + peutRouler3);
        Debug.Log("*** peutRouler4 : " + peutRouler4);

        Debug.Log("*** etatJoueur1 : " + etatJoueur1.text);
        Debug.Log("*** etatJoueur2 : " + etatJoueur2.text);
        Debug.Log("*** etatJoueur3 : " + etatJoueur3.text);
        Debug.Log("*** etatJoueur4 : " + etatJoueur4.text);

        if (joueurSelectionne <= PhotonNetwork.room.PlayerCount)
        {
            switch (joueurSelectionne)
            {
                case 1:
                    if (move_yes_no1)
                    {
                        photonView.RPC("ChangeStateMasterStop", PhotonTargets.AllBuffered, 1, false, false, "Joueur 1 Stop");
                    }
                    break;
                case 2:
                    if (move_yes_no2)
                    {
                        photonView.RPC("ChangeStateMasterStop", PhotonTargets.AllBuffered, 2, false, false, "Joueur 2 Stop");
                    }
                    break;
                case 3:
                    if (move_yes_no3)
                    {
                        photonView.RPC("ChangeStateMasterStop", PhotonTargets.AllBuffered, 3, false, false, "Joueur 3 Stop");
                    }
                    break;
                case 4:
                    if (move_yes_no4)
                    {
                        photonView.RPC("ChangeStateMasterStop", PhotonTargets.AllBuffered, 4, false, false, "Joueur 4 Stop");
                    }
                    break;
                default:
                    break;
            }
        }

        Debug.Log("*** Stop APRES ***");
        Debug.Log("*** peutRouler1 : " + peutRouler1);
        Debug.Log("*** peutRouler2 : " + peutRouler2);
        Debug.Log("*** peutRouler3 : " + peutRouler3);
        Debug.Log("*** peutRouler4 : " + peutRouler4);

        Debug.Log("*** etatJoueur1 : " + etatJoueur1.text);
        Debug.Log("*** etatJoueur2 : " + etatJoueur2.text);
        Debug.Log("*** etatJoueur3 : " + etatJoueur3.text);
        Debug.Log("*** etatJoueur4 : " + etatJoueur4.text);
    }

    [PunRPC]
    private void ChangeStateMasterStop(int joueur, bool peutRouler, bool moveYesNo, string text)
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
        Debug.Log("*** Accident AVANT ***");
        Debug.Log("*** hasNotAccident1 : " + hasNotAccident1);
        Debug.Log("*** hasNotAccident2 : " + hasNotAccident2);
        Debug.Log("*** hasNotAccident3 : " + hasNotAccident3);
        Debug.Log("*** hasNotAccident4 : " + hasNotAccident4);

        Debug.Log("*** etatJoueur1 : " + etatJoueur1.text);
        Debug.Log("*** etatJoueur2 : " + etatJoueur2.text);
        Debug.Log("*** etatJoueur3 : " + etatJoueur3.text);
        Debug.Log("*** etatJoueur4 : " + etatJoueur4.text);

        if (joueurSelectionne <= PhotonNetwork.room.PlayerCount)
        {
            switch (joueurSelectionne)
            {
                case 1:
                    if (move_yes_no1)
                    {
                        photonView.RPC("ChangeStateMasterAccident", PhotonTargets.AllBuffered, 1, false, false, "Joueur 1 Accident");
                    }
                    break;
                case 2:
                    if (move_yes_no2)
                    {
                        photonView.RPC("ChangeStateMasterAccident", PhotonTargets.AllBuffered, 2, false, false, "Joueur 2 Accident");
                    }
                    break;
                case 3:
                    if (move_yes_no3)
                    {
                        photonView.RPC("ChangeStateMasterAccident", PhotonTargets.AllBuffered, 3, false, false, "Joueur 3 Accident");
                    }
                    break;
                case 4:
                    if (move_yes_no4)
                    {
                        photonView.RPC("ChangeStateMasterAccident", PhotonTargets.AllBuffered, 4, false, false, "Joueur 4 Accident");
                    }
                    break;
                default:
                    break;
            }
        }

        Debug.Log("*** Accident APRES ***");
        Debug.Log("*** hasNotAccident1 : " + hasNotAccident1);
        Debug.Log("*** hasNotAccident2 : " + hasNotAccident2);
        Debug.Log("*** hasNotAccident3 : " + hasNotAccident3);
        Debug.Log("*** hasNotAccident4 : " + hasNotAccident4);

        Debug.Log("*** etatJoueur1 : " + etatJoueur1.text);
        Debug.Log("*** etatJoueur2 : " + etatJoueur2.text);
        Debug.Log("*** etatJoueur3 : " + etatJoueur3.text);
        Debug.Log("*** etatJoueur4 : " + etatJoueur4.text);
    }

    [PunRPC]
    private void ChangeStateMasterAccident(int joueur, bool hasNotAccident, bool moveYesNo, string text)
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

    [PunRPC]
    private void ChangerEtatBonJoueur1()
    {
        peutRouler1 = true;
        move_yes_no1 = true;
        hasNotAccident1 = true;
        etatJoueur1.text = "Joueur 1 ";
    }

    [PunRPC]
    private void ChangerEtatBonJoueur2()
    {
        peutRouler2 = true;
        move_yes_no2 = true;
        hasNotAccident2 = true;
        etatJoueur2.text = "Joueur 2 ";
    }

    [PunRPC]
    private void ChangerEtatBonJoueur3()
    {
        peutRouler3 = true;
        move_yes_no3 = true;
        hasNotAccident3 = true;
        etatJoueur3.text = "Joueur 3 ";
    }

    [PunRPC]
    private void ChangerEtatBonJoueur4()
    {
        peutRouler4 = true;
        move_yes_no4 = true;
        hasNotAccident4 = true;
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


}
