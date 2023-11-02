using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprinler : MonoBehaviour, IFireCracackerBurst
{
    public int type { get => type; set => type=0; }

    

    void IFireCracackerBurst.ExecuteFireCracker()
    {
        Debug.Log("Sprinkler Executing!!");
        //implementation here
    }
    private void ExecuteFireCracker()
    {
        Debug.Log("Sprinkler Executing!!");
        //implementation here
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Firecracker")) ExecuteFireCracker();

    }
}
