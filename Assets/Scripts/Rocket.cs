using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;
using UnityEngine.VFX;

public class Rocket : MonoBehaviour, IFireCracackerBurst
{
    public int type { get => type; set => type = 1; }
    [SerializeField]
    private VisualEffect RocketEffect;
    bool IsPlaying = false;

    public void Start()
    {
        RocketEffect = GetComponent<VisualEffect>();
    }
    void IFireCracackerBurst.ExecuteFireCracker()
    {
        IsPlaying = true;
        PlayRocketEffect();
        Debug.Log("Rocket Executing!!"); 
        
        //implementation here
    }
    private void ExecuteFireCracker()
    {
        Debug.Log("Rocket Executing!!");
        //implementation here
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Firecracker")) ExecuteFireCracker();

    }

    void PlayRocketEffect()
    {
        if (IsPlaying == true) RocketEffect.Play();
       

    }
   
}
