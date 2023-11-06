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
    private AudioSource Explosion;
    public float delay = 0f;
    float timer;
    [SerializeField]
    private float cutscenetime = 3f;

    public void Start()
    {
        Explosion = GetComponent<AudioSource>();
    }

    void Update()
    {
        timer += Time.deltaTime;
       
    }
    private void ExecuteFireCracker()
    {
        Debug.Log("Bomb Executing!!");
        if (!used) {
            if (timer > delay)
            {
                OnExEvent.Invoke(); 
                Invoke("PlaySoundEffect", 0.5f);
                used = true;
            }
            
        }
       
    }
    private void PlaySoundEffect()
    {
       Explosion.Play();
       Invoke("PlayCustscen", cutscenetime);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Firecracker")) ExecuteFireCracker();

    }

    void IFireCracackerBurst.ExecuteFireCracker()
    {
       
    }

    void PlayCustscen()
    {
        FindObjectOfType<FireCrackerManager>()?.PlayCutsctScene(); // complex line just finds object check if its null using ?. operation if not null then calls function
    }
}
