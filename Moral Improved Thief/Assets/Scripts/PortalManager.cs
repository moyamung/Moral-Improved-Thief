using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PortalManager : MonoBehaviour
{
    [SerializeField]List<PortalController> portals;

    void Start()
    {
        portals = new List<PortalController>();
        Transform portalParent = this.transform.Find("Portals");
        for(int i = 0; i < portalParent.childCount; i++)
        {
            portals.Add(portalParent.GetChild(i).GetComponent<PortalController>());
        }
    }

    PortalController GetUnconnectedPortal()
    {
        if (portals.Count == 0)
        {
            Start();
        }
        foreach (PortalController portal in portals)
        {
            if (!portal.IsConnected) return portal;
        }
        return null;
    }

    void Connect(PortalManager other)
    {
        PortalController portal1 = GetUnconnectedPortal();
        PortalController portal2 = other.GetUnconnectedPortal();
        portal1.Connect(portal2);
        portal2.Connect(portal1);
    }

    public void Unconnect()
    {
        foreach (PortalController portal in portals)
        {
            portal.Unconnect();
        }
    }

    public static int Connect(PortalManager map1, PortalManager map2)
    {
        PortalController portal1 = map1.GetUnconnectedPortal();
        PortalController portal2 = map2.GetUnconnectedPortal();
        if (portal1 == null || portal2 == null) return -1;
        portal1.Connect(portal2);
        portal2.Connect(portal1);
        return 0;
    }
}
