using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    public Player plMove;
    public PhotonView photonView;
    //private GameObject BubbleSpeechObject;
    //private Text UpdatedText;

    public GameObject chatFeed;
    private GameObject messageFeedGrid;

    private InputField ChatInputField;
    private bool disableSend;

    private void Awake()
    {
        ChatInputField = GameObject.Find("ChatInputField").GetComponent<InputField>();
        //BubbleSpeechObject = GameObject.Find("FondDeMessage");
        //UpdatedText = GameObject.Find("MessageText").GetComponent<Text>();
        messageFeedGrid = GameObject.Find("MessageGrid");
    }

    private void Update()
    {
        if(photonView.isMine)
        {
            if (ChatInputField.text != "" && ChatInputField.text.Length > 0 && Input.GetKeyDown(KeyCode.Return))
            {
                ChatInputField.text = photonView.owner.NickName + " : " + ChatInputField.text;
                photonView.RPC("SendMessage", PhotonTargets.AllBuffered, ChatInputField.text);
                //BubbleSpeechObject.SetActive(true);

                ChatInputField.text = "";
                disableSend = true;
            }
        }
    }

    [PunRPC]
    private void SendMessage(string message)
    {
        GameObject obj = Instantiate(chatFeed, new Vector2(0, 0), Quaternion.identity);
        obj.transform.SetParent(messageFeedGrid.transform, false);
        //UpdatedText.text = message;
        obj.GetComponent<Text>().text = message;

        StartCoroutine("Remove");
    }

    IEnumerator Remove()
    {
        yield return new WaitForSeconds(4f);
        //BubbleSpeechObject.SetActive(false);
        disableSend = false;
    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.isWriting)
        {
            //stream.SendNext(BubbleSpeechObject.active);

        }
        else if (stream.isReading)
        {
            //BubbleSpeechObject.SetActive((bool)stream.ReceiveNext()); 
        }
    }


}
