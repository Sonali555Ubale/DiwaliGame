using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour, IFireCracackerBurst
{
    public int type { get => type; set => type = 2; }



    private void ExecuteFireCracker()
    {
        Debug.Log("Bomb Executing!!");
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
