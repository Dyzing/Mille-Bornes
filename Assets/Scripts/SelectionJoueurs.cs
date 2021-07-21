using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionJoueurs : MonoBehaviour
{
    public PhotonView photonView;
    public void SelectionJ1()
    {
        //photonView.RPC("ChangerJoueurSelectionneJ1", PhotonTargets.AllBufferedViaServer);
        GameManager.joueurSelectionne = 1;
        OnClickMalus(GameManager.joueurSelectionne);
    }

    [PunRPC]
    private void ChangerJoueurSelectionneJ1()
    {
        GameManager.joueurSelectionne = 1;
    }

    public void SelectionJ2()
    {
        //photonView.RPC("ChangerJoueurSelectionneJ2", PhotonTargets.AllBufferedViaServer);
        GameManager.joueurSelectionne = 2;
        OnClickMalus(GameManager.joueurSelectionne);
    }

    [PunRPC]
    private void ChangerJoueurSelectionneJ2()
    {
        GameManager.joueurSelectionne = 2;
    }

    public void SelectionJ3()
    {
        //photonView.RPC("ChangerJoueurSelectionneJ3", PhotonTargets.AllBufferedViaServer);
        GameManager.joueurSelectionne = 3;
        OnClickMalus(GameManager.joueurSelectionne);
    }

    [PunRPC]
    private void ChangerJoueurSelectionneJ3()
    {
        GameManager.joueurSelectionne = 3;
    }

    public void SelectionJ4()
    {
        //photonView.RPC("ChangerJoueurSelectionneJ4", PhotonTargets.AllBufferedViaServer);
        GameManager.joueurSelectionne = 4;
        OnClickMalus(GameManager.joueurSelectionne);
    }

    [PunRPC]
    private void ChangerJoueurSelectionneJ4()
    {
        GameManager.joueurSelectionne = 4;
    }

    public void OnClickMalus(int joueurSelect)
    {
        switch (GameManager.carteJouée)
        {
            case "Stop":
                photonView.RPC("Stop", PhotonTargets.AllBufferedViaServer,joueurSelect);
                break;
            case "Accident":
                photonView.RPC("Accident", PhotonTargets.AllBufferedViaServer,joueurSelect);
                break;
            default:
                break;
        }
        GameManager.carteJouée = "";
        GameManager.selectionJoueursPanel.SetActive(false);
        GameManager.joueurSelectionne = 0;
    }


    [PunRPC]
    private void Stop(int joueurSelect)
    {
        if (joueurSelect <= PhotonNetwork.room.PlayerCount)
        {
            switch (joueurSelect)
            {
                case 1:
                    if (GameManager.move_yes_no1)
                    {
                        GameManager.peutRouler1 = false;
                        GameManager.move_yes_no1 = false;
                        GameManager.etatJoueur1.text = "Joueur 1 Stop";
                    }
                    break;
                case 2:
                    if (GameManager.move_yes_no2)
                    {
                        GameManager.peutRouler2 = false;
                        GameManager.move_yes_no2 = false;
                        GameManager.etatJoueur2.text = "Joueur 2 Stop";
                    }
                    break;
                case 3:
                    if (GameManager.move_yes_no3)
                    {
                        GameManager.peutRouler3 = false;
                        GameManager.move_yes_no3 = false;
                        GameManager.etatJoueur3.text = "Joueur 3 Stop";
                    }
                    break;
                case 4:
                    if (GameManager.move_yes_no4)
                    {
                        GameManager.peutRouler4 = false;
                        GameManager.move_yes_no4 = false;
                        GameManager.etatJoueur4.text = "Joueur 4 Stop";
                    }
                    break;
                default:
                    break;
            }
        }
    }

    [PunRPC]
    private void Accident(int joueurSelect)
    {
        if (joueurSelect <= PhotonNetwork.room.PlayerCount)
        {
            switch (joueurSelect)
            {
                case 1:
                    if (GameManager.move_yes_no1)
                    {
                        GameManager.hasNotAccident1 = false;
                        GameManager.move_yes_no1 = false;
                        GameManager.etatJoueur1.text = "Joueur 1 Accident";
                    }
                    break;
                case 2:
                    if (GameManager.move_yes_no2)
                    {
                        GameManager.hasNotAccident2 = false;
                        GameManager.move_yes_no2 = false;
                        GameManager.etatJoueur2.text = "Joueur 2 Accident";
                    }
                    break;
                case 3:
                    if (GameManager.move_yes_no3)
                    {
                        GameManager.hasNotAccident3 = false;
                        GameManager.move_yes_no3 = false;
                        GameManager.etatJoueur3.text = "Joueur 3 Accident";
                    }
                    break;
                case 4:
                    if (GameManager.move_yes_no4)
                    {
                        GameManager.hasNotAccident4 = false;
                        GameManager.move_yes_no4 = false;
                        GameManager.etatJoueur4.text = "Joueur 4 Accident";
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
    