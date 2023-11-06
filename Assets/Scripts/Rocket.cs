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


    [SerializeField]
    public UnityEvent OnTxtExEvent = new UnityEvent();
    [SerializeField]
    private float cutscenetime = 0.1f;
    private AudioSource RocketSound;



    bool IsPlaying = false;
    private bool used =false;

    public void Start()
    {
        RocketSound = GetComponent<AudioSource>();
      
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
            Invoke("PlaySoundEffect", 0f);

        }
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Firecracker")) ExecuteFireCracker();

    }

    void PlayRocketEffect()
    {
       // effect.Stop();
        Invoke("PlayCustscen", cutscenetime);
    }
    private void PlaySoundEffect()
    {
        RocketSound.Play();
    }
    void PlayCustscen()
    {
        FindObjectOfType<FireCrackerManager>()?.PlayCutsctScene(); // complex line just finds object check if its null using ?. operation if not null then calls function
    }

}
