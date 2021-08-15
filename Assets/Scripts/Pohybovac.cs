using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pohybovac : MonoBehaviour
{
    public Rigidbody rb;
    public Transform kamera;

    public float look_speed = 50f;

    public float walk_speed = 100f;
    public float zrot = 0f;
    public float xrot = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        zrot += Input.GetAxisRaw("Mouse Y") * Time.deltaTime * look_speed;
        zrot = Mathf.Clamp(zrot, -10f, 10f);
        kamera.localRotation = Quaternion.AngleAxis(zrot, new Vector3(-1f, 0f, 0f));
        xrot += Input.GetAxisRaw("Mouse X") * Time.deltaTime * look_speed;
        if (xrot >= 180 || xrot <= -180){
            xrot = 0;
        }
        rb.rotation = Quaternion.AngleAxis(xrot, new Vector3(0f, 1f, 0f));

        float xmove = Input.GetAxisRaw("Horizontal") * Time.deltaTime * walk_speed * 5000f;
        float zmove = Input.GetAxisRaw("Vertical") * Time.deltaTime * walk_speed * 10000f;
        rb.AddRelativeForce(new Vector3(xmove, 0f, zmove));
    }
}