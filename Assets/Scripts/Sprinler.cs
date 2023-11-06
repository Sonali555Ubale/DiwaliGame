using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sprinler : MonoBehaviour, IFireCracackerBurst
{
    public int type { get => type; set => type=0; }
    private bool used = false;

    private AudioSource Sprinkler;

    [SerializeField]
    public UnityEvent OnExEvent = new UnityEvent();
    [SerializeField]
    private float cutscenetime = 3f;

    public void Start()
    {
        Sprinkler = GetComponent<AudioSource>();
    }
    void IFireCracackerBurst.ExecuteFireCracker()
    {
        Debug.Log("Sprinkler Executing!!");
        //implementation here
    }
    private void ExecuteFireCracker()
    {
        Debug.Log("Sprinkler Executing!!");

        if (!used) {
            OnExEvent.Invoke(); used = true;
            Invoke("PlaySprinkler", 0f);

        }
        
    }
    private void PlaySprinkler()
    {
        Sprinkler.Play();
        Invoke("PlayCustscen", cutscenetime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.tag.Equals("Firecracker")) ExecuteFireCracker();
    }

    void PlayCustscen()
    {
        FindObjectOfType<FireCrackerManager>()?.PlayCutsctScene(); // complex line just finds object check if its null using ?. operation if not null then calls function
    }
}
