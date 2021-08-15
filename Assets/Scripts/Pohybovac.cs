using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pohybovac : MonoBehaviour
{
    public Rigidbody rb;
    public Transform kamera;

    public float look_speed = 50f;

    public float walk_speed = 100f;
    public float xrot = 0f;
    public float zrot = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        xrot += Input.GetAxisRaw("Mouse Y") * Time.deltaTime * look_speed;
        xrot = Mathf.Clamp(xrot, -10f, 10f);
        kamera.localRotation = Quaternion.AngleAxis(xrot, new Vector3(-1f, 0f, 0f));
        zrot += Input.GetAxisRaw("Mouse X") * Time.deltaTime * look_speed;
        if (zrot >= 180 || zrot <= -180){
            zrot = 0;
        }
        rb.rotation = Quaternion.AngleAxis(zrot, new Vector3(0f, 1f, 0f));

        float xmove = Input.GetAxisRaw("Horizontal") * Time.deltaTime * walk_speed * 5000f;
        float zmove = Input.GetAxisRaw("Vertical") * Time.deltaTime * walk_speed * 10000f;
        rb.AddRelativeForce(new Vector3(xmove, 0f, zmove));
    }
}