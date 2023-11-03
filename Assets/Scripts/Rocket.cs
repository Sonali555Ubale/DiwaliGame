using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.VFX;
using UnityEngine.VFX;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class Rocket : MonoBehaviour, IFireCracackerBurst
{
    public int type { get => type; set => type = 1; }
    [SerializeField]
    public UnityEvent OnExEvent = new UnityEvent();
    [SerializeField]
    private VisualEffect effect;


    bool IsPlaying = false;
    private bool used =false;

    public void Start()
    {
        
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
        if (!used) {
            OnExEvent.Invoke();
            Invoke("PlayRocketEffect", 1f);
            used = true;
        }
        //implementation here
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Firecracker")) ExecuteFireCracker();

    }

    void PlayRocketEffect()
    {

       effect.Stop();
    }
   
}
