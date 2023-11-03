﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sprinler : MonoBehaviour, IFireCracackerBurst
{
    public int type { get => type; set => type=0; }
    private bool used = false;

    [SerializeField]
    public UnityEvent OnExEvent = new UnityEvent();

    void IFireCracackerBurst.ExecuteFireCracker()
    {
        Debug.Log("Sprinkler Executing!!");
        //implementation here
    }
    private void ExecuteFireCracker()
    {
        Debug.Log("Sprinkler Executing!!");

        if (!used) { OnExEvent.Invoke(); used = true; }
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.tag.Equals("Firecracker")) ExecuteFireCracker();
    }
}
