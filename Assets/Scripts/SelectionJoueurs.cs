using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionJoueurs : MonoBehaviour
{
    public PhotonView photonView;
    public void SelectionJ1()
    {
        photonView.RPC("ChangerJoueurSelectionneJ1", PhotonTargets.AllViaServer);
        GameManager.selectionJoueursPanel.SetActive(false);

        //OnClickMalus();
    }

    [PunRPC]
    private void ChangerJoueurSelectionneJ1()
    {
        Player.joueurSelectionne = 1;
    }

    public void SelectionJ2()
    {
        photonView.RPC("ChangerJoueurSelectionneJ2", PhotonTargets.AllViaServer);
        GameManager.selectionJoueursPanel.SetActive(false);

        //OnClickMalus();
    }

    [PunRPC]
    private void ChangerJoueurSelectionneJ2()
    {
        Player.joueurSelectionne = 2;
    }

    public void SelectionJ3()
    {
        photonView.RPC("ChangerJoueurSelectionneJ3", PhotonTargets.AllViaServer);
        GameManager.selectionJoueursPanel.SetActive(false);

        //OnClickMalus();
    }

    [PunRPC]
    private void ChangerJoueurSelectionneJ3()
    {
        Player.joueurSelectionne = 3;
    }

    public void SelectionJ4()
    {
        photonView.RPC("ChangerJoueurSelectionneJ4", PhotonTargets.AllViaServer);
        GameManager.selectionJoueursPanel.SetActive(false);

        //OnClickMalus();
    }

    [PunRPC]
    private void ChangerJoueurSelectionneJ4()
    {
        Player.joueurSelectionne = 4;
    }

    
}
