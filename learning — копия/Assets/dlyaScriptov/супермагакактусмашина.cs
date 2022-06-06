using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class супермагакактусмашина : MonoBehaviour
{
    private Rigidbody suprmachinasastus;
    public float Hspeed;
    public float Vspeed;
    public float jumpforse;
    public float cofactor = 1;
    public bool isGrounded;
    public Vector3 ToSpawn;
    void Start()
    {
        suprmachinasastus = GetComponent <Rigidbody> ();
    }

    void FixedUpdate()
    {
        suprmachinasastus.velocity = new Vector3 (Input.GetAxis("Vertical")*-Vspeed*cofactor*Time.fixedDeltaTime, suprmachinasastus.velocity.y , Input.GetAxis("Horizontal")*Hspeed*cofactor*Time.fixedDeltaTime);
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)&& isGrounded){
            suprmachinasastus.AddForce(0,jumpforse, 0);
            isGrounded = false;
        }
        if(Input.GetKey(KeyCode.Shift))
            Cofactor = 2;
        else if(Input.GetKeyUp(KeyCode.Shift))
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
}
