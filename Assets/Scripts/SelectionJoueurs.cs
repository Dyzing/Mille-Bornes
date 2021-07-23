using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionJoueurs : MonoBehaviour
{
    public PhotonView photonView;
    public void SelectionJ1()
    {
        photonView.RPC("ChangerJoueurSelectionneJ1", PhotonTargets.AllBufferedViaServer);
        OnClickMalus();
    }

    [PunRPC]
    private void ChangerJoueurSelectionneJ1()
    {
        GameManager.joueurSelectionne = 1;
    }

    public void SelectionJ2()
    {
        photonView.RPC("ChangerJoueurSelectionneJ2", PhotonTargets.AllBufferedViaServer);
        OnClickMalus();
    }

    [PunRPC]
    private void ChangerJoueurSelectionneJ2()
    {
        GameManager.joueurSelectionne = 2;
    }

    public void SelectionJ3()
    {
        photonView.RPC("ChangerJoueurSelectionneJ3", PhotonTargets.AllBufferedViaServer);
        OnClickMalus();
    }

    [PunRPC]
    private void ChangerJoueurSelectionneJ3()
    {
        GameManager.joueurSelectionne = 3;
    }

    public void SelectionJ4()
    {
        photonView.RPC("ChangerJoueurSelectionneJ4", PhotonTargets.AllBufferedViaServer);
        OnClickMalus();
    }

    [PunRPC]
    private void ChangerJoueurSelectionneJ4()
    {
        GameManager.joueurSelectionne = 4;
    }

    public void OnClickMalus()
    {
        switch (GameManager.carteJouée)
        {
            case "Stop":
                photonView.RPC("Stop", PhotonTargets.AllBufferedViaServer);
                break;
            default:
                break;
        }
        GameManager.carteJouée = "";
        GameManager.joueurSelectionne = 0;
        GameManager.selectionJoueursPanel.SetActive(false);
    }


    [PunRPC]
    private void Stop()
    {
        if (GameManager.joueurSelectionne <= PhotonNetwork.room.PlayerCount)
        {
            switch (GameManager.joueurSelectionne)
            {
                case 1:
                    if (GameManager.move_yes_no1)
                    {
                        GameManager.peutRouler1 = false;
                        GameManager.move_yes_no1 = false;
                    }
                    break;
                case 2:
                    if (GameManager.move_yes_no2)
                    {
                        GameManager.peutRouler2 = false;
                        GameManager.move_yes_no2 = false;
                    }
                    break;
                case 3:
                    if (GameManager.move_yes_no3)
                    {
                        GameManager.peutRouler3 = false;
                        GameManager.move_yes_no3 = false;
                    }
                    break;
                case 4:
                    if (GameManager.move_yes_no4)
                    {
                        GameManager.peutRouler4 = false;
                        GameManager.move_yes_no4 = false;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
