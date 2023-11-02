using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCrackerManager : MonoBehaviour
{
    [Range(0,2)]
    private int FireCrackerType;
    private GameObject CurretFireCracker;
    [SerializeField]
    private Transform SpawnPoint;
    [SerializeField]
    private GameObject[] FireCrackers;

    void Start()
    {
        FireCrackerType = PlayerPrefs.GetInt("FireCrackerType", 0);
        SpawnFireCracker();
    }

   private void SpawnFireCracker()
    {
        if (FireCrackerType < 0 || FireCrackerType > FireCrackers.Length - 1) FireCrackerType = 0;

        CurretFireCracker = GameObject.Instantiate(FireCrackers[FireCrackerType], SpawnPoint);
    }
}
