using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bomb : MonoBehaviour, IFireCracackerBurst
{
    public int type { get => type; set => type = 2; }
    [SerializeField]
    public UnityEvent OnExEvent = new UnityEvent();
    private bool used = false;
    private void ExecuteFireCracker()
    {
        Debug.Log("Bomb Executing!!");
        if (!used) { OnExEvent.Invoke(); used = true; }
        //implementation here
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Firecracker")) ExecuteFireCracker();

    }

    void IFireCracackerBurst.ExecuteFireCracker()
    {
       // if (collision.tag.Equals("Firecracker")) ExecuteFireCracker();
    }
}
