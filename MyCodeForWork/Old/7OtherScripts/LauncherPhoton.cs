using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class LauncherPhoton : MonoBehaviour
{
    [SerializeField]  public GameObject btnPhoton;
    [SerializeField] public Text textPhoton;

    private bool isConnected = false;

    string gameVersion = "1";

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start()
    {
        Connect();
    }

    public void Connect()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();

            isConnected = true;
            textPhoton.text = $"Photon\nON";
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;

            isConnected = false;
            textPhoton.text = $"Photon\nOFF, error";
        }
    }

    public void OnButtonPhoton()
    {
        if (isConnected = false)
        {
            Connect();

            isConnected = true;
        }

        else if (isConnected = true)
        {
            PhotonNetwork.Disconnect();

            isConnected = false;
        }
    }
}
