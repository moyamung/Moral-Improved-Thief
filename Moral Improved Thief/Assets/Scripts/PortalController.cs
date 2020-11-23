using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    [SerializeField]private PortalController _connectedPortal;
    [SerializeField]private bool _isConnected;

    private void Start()
    {
        //IsConnected = false;
        SetRender();
    }

    public PortalController ConnectedPortal
    {
        get
        {
            return _connectedPortal;
        }
        set
        {
            _connectedPortal = value;
        }
    }

    public bool IsConnected
    {
        get
        {
            return _isConnected;
        }
        set
        {
            _isConnected = value;
        }
    }

    public void SetRender()
    {
        GetComponent<MeshRenderer>().enabled = IsConnected;
    }

    public void Connect(PortalController other)
    {
        //Debug.Log("connecting...");
        IsConnected = true;
        SetRender();
        ConnectedPortal = other;
        //IsConnected = true;
        //if (connectedPortal == null) IsConnected = false;
        //SetRender();
    }

    public void Unconnect()
    {
        IsConnected = false;
        SetRender();
        ConnectedPortal = null;
    }

    public void UsePortal(GameObject Player)
    {
        if (!IsConnected) return;
        Player.transform.position = _connectedPortal.gameObject.transform.position;
    }
}
