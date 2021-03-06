using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chytac : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 rozdiel;

    public Pohybovac mover;


    public float offsetx;

    public float offsety;
    public GameObject chytene;

    bool caught = false;

    // Update is called once per frame


    void Update()
    {
        Debug.Log(new Vector3(mover.zrot, 10f, mover.xrot));
        if(Input.GetButtonDown("Fire1")){
            caught = false;
            RaycastHit[] hits = Physics.SphereCastAll(transform.position, 30f, new Vector3(mover.xrot + offsetx, mover.zrot + offsety, 0f), 30f);
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
                            Debug.Log(transform.position);
                            Debug.Log(rbx.position);
                            Debug.Log("Chytene");
                            rozdiel = transform.position - rbx.position;
                            caught = true;
                        }
                    }
                }
            }
        }
        if (Input.GetButton("Fire1")){
            if(caught){
                chytene.GetComponent<Rigidbody>().position = new Vector3(transform.position.x + rozdiel.x, transform.position.y + 4f, transform.position.z + rozdiel.z);
            }
        }   
    }
}
