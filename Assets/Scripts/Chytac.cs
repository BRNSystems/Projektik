using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chytac : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 rozdiel;

    public Pohybovac mover;

    public GameObject chytene;

    bool caught = false;

    // Update is called once per frame

    Rigidbody hrac;

    void start(){
        hrac = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            caught = false;
            RaycastHit[] hits = Physics.RaycastAll(transform.position, new Vector3(mover.xrot, 0f, mover.zrot), 100);
            float mindist = 30f;

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
                        if (chytene.TryGetComponent<Rigidbody>(out Rigidbody rbx)){
                            Debug.Log(hrac.position);
                            Debug.Log(rbx.position);
                            Debug.Log("Chytene");
                            rozdiel = hrac.position - rbx.position;
                            caught = true;
                        }
                    }
                }
            }
        }
        if (Input.GetButton("Fire1")){
            if(caught){
                chytene.GetComponent<Rigidbody>().position = new Vector3(hrac.position.x + rozdiel.x, hrac.position.y + 4f, hrac.position.z + rozdiel.z);
            }
        }   
    }
}
