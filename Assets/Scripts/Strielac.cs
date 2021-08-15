using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strielac : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 0;
    public int run = 0;
    public int length = 10;
    public int cnt = 0;
    public Transform spawner;
    public GameObject naboj;

    public AudioSource vystrel;

    public AudioSource doraz;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (run == 1 && cnt == 0){
            vystrel.Play();
        }
        if(run == 1 && length > cnt){
            rb.AddTorque(new Vector3(force, 0, 0));
            cnt++;
        }
        if(length <= cnt){
            run = -1;
            doraz.Play();
        }
        if(run == -1 && 0 < cnt){
            rb.AddTorque(new Vector3(-force, 0, 0));
            cnt--;
        }
        if(0 == cnt){
            run = 1;
            Instantiate(naboj, spawner.position, spawner.rotation);
        }
    }
}