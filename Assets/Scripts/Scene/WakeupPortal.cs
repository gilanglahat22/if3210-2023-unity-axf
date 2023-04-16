using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeupPortal : MonoBehaviour
{
    public GameObject wakeUpPortal;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.isLevel4completed)
        {
            wakeUpPortal.SetActive(true);
        }
    }
}
