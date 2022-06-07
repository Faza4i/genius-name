using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharecterController : MonoBehaviour
{
    private Rigidbody rb;
    public float Hspeed;
    public float Vspeed;
    public float jumpforse;
    public float Cofactor = 1;
    public bool isGrounded;
    public Vector3 ToSpawn;
    void Start()
    {
        rb = GetComponent <Rigidbody> ();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3 (Input.GetAxis("Vertical")*-Vspeed*Cofactor*Time.fixedDeltaTime, rb.velocity.y , Input.GetAxis("Horizontal")*Hspeed*Cofactor*Time.fixedDeltaTime);
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)&& isGrounded){
            rb.AddForce(0,jumpforse, 0);
            isGrounded = false;
        }
        if(Input.GetKey(KeyCode.LeftShift))
            Cofactor = 2;
        else if(Input.GetKeyUp(KeyCode.LeftShift))
            Cofactor = 1;

        if(Input.GetKey(KeyCode.C))
            Cofactor = 0.5f;
        else if(Input.GetKeyUp(KeyCode.C))
            Cofactor = 1;

        if(this.gameObject.GetComponent<Transform>().position.y <= -30)
            this.gameObject.GetComponent<Transform>().position = ToSpawn;
    }
    void OnCollisionStay(Collision other){
        if(other.gameObject.tag == "Ground")
            isGrounded = true;
    }
    void OnCollisionExit(Collision other){
        if (other.gameObject.tag == "Ground")
            isGrounded = false;
    }
}