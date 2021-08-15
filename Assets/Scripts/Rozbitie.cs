using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rozbitie : MonoBehaviour

{
    public bool broken = false;
    public GameObject rozbite;
    // Start is called before the first frame update

    void OnCollisionEnter(Collision coll) {
        Debug.Log(coll.relativeVelocity.magnitude);
        if(!broken && coll.gameObject.name != "Bean"){
            if(coll.relativeVelocity.magnitude > 3f || coll.relativeVelocity.magnitude < -3f){
                Instantiate(rozbite, transform.position, transform.rotation);
                Destroy(transform.gameObject);
                broken = true;
            }
        }
    }

}
