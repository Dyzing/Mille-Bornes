using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : Photon.MonoBehaviour
{
    public GameObject playerPrefab;

    public Rigidbody rb;
    public GameObject playerCamera;
    public PhotonView photonView;
    public TextMeshProUGUI playerNameText;


    public bool isGrounded = false;
    public bool isFinished = false;

    private Vector3 voiturepos;

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
    }

    void Start()
    {
        voiturepos = playerPrefab.transform.position;

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
                    isFinished = true;
                    break;
                default:
                    break;
            }
        }
    }

    public void MoveVoiture()
    {
        isFinished = false;
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
        voiturepos.y += 2f;

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
}
