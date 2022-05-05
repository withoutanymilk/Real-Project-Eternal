using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KilledBoss : MonoBehaviour
{
    public GameObject boss;

    // Update is called once per frame
    public void endGAME()
    {
        boss = GameObject.Find("finBoss");
        boss.SetActive(false);
        return;
    }
}
