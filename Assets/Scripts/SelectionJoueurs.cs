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
        /*        if (photonView.isMine)
                {*/
        Debug.Log("***AVANT peutRouler2 : " + GameManager.peutRouler1);
        Debug.Log("***AVANT move_yes_no2 : " + GameManager.peutRouler1);
        switch (GameManager.carteJouée)
            {
                case "Stop":
                    photonView.RPC("Stop", PhotonTargets.AllBufferedViaServer);
                    Debug.Log("***APRES peutRouler2 : " + GameManager.peutRouler1);
                    Debug.Log("***APRES move_yes_no2 : " + GameManager.peutRouler1);
                break;
                default:
                    break;
            }
            GameManager.carteJouée = "";
            GameManager.joueurSelectionne = 0;
            GameManager.selectionJoueursPanel.SetActive(false);
        //}
    }


    [PunRPC]
    private void Stop()
    {
        Debug.Log("***STOP AVANT peutRouler2 : " + GameManager.peutRouler1);
        Debug.Log("***STOP AVANT move_yes_no2 : " + GameManager.peutRouler1);
        Debug.Log("GameManager.joueurSelectionne : " + GameManager.joueurSelectionne);
        Debug.Log("PhotonNetwork.room.PlayerCount : " + PhotonNetwork.room.PlayerCount);
        if (GameManager.joueurSelectionne <= PhotonNetwork.room.PlayerCount)
        {
            switch (GameManager.joueurSelectionne)
            {
                case 1:
                    if (GameManager.move_yes_no1)
                    {
                        Debug.Log("case 1");
                        GameManager.peutRouler1 = false;
                        GameManager.move_yes_no1 = false;
                    }
                    break;
                case 2:
                    if (GameManager.move_yes_no2)
                    {
                        Debug.Log("case 2");
                        GameManager.peutRouler2 = false;
                        GameManager.move_yes_no2 = false;
                    }
                    break;
                default:
                    break;
            }
        }
        Debug.Log("***STOP APRES peutRouler2 : " + GameManager.peutRouler1);
        Debug.Log("***STOP APRES move_yes_no2 : " + GameManager.peutRouler1);
    }
}
