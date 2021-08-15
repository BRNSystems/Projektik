using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chytac : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody hrac;

    public Vector3 rozdiel;

    public Pohybovac mover;

    public GameObject chytene;

    bool caught = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            //rozdiel = hrac.position - 
            RaycastHit[] hits = Physics.RaycastAll(transform.position, new Vector3(mover.xrot, 0f, mover.zrot));
            float mindist = 15f;

            foreach (RaycastHit hit in hits){
                if (hit.collider.gameObject.name != "Bean"){
                    Debug.Log(hit.distance);
                    if (hit.distance < mindist){
                        mindist = hit.distance;
                        if(hit.collider.gameObject.tag == "NotToRoot"){
                            chytene = hit.collider.gameObject;
                        }
                        else{
                            chytene = hit.collider.gameObject.transform.root.gameObject;
                        }
                        rozdiel = hrac.position - chytene.GetComponent<Rigidbody>().position;
                        caught = true;
                    }
                }
            }
        }
        if (Input.GetButton("Fire1")){
            if(caught){
                chytene.GetComponent<Rigidbody>().position = new Vector3(hrac.position.x + rozdiel.x, hrac.position.y + 4, hrac.position.z + rozdiel.z);
            }
        }   
    }
}
