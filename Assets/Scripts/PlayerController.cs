using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float horizontal;
    public float vertical;
    public Vector3 velocity;

    public Animator anim;
    public Camera cam;
    public Rigidbody rb;
    public GameObject mario;

	void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
	}
	
	void Update () {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector3(horizontal * 3, 0, vertical * 3);

        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)) {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
        velocity = transform.InverseTransformDirection(rb.velocity);

        anim.SetFloat("Vertical", velocity.z);
        anim.SetFloat("Horizontal", velocity.x);
	}
}
