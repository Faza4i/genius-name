using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class супермагакактусмашина : MonoBehaviour
{
    private Rigidbody suprmachinasastus;
    public float Hspeed;
    public float Vspeed;
    public float jumpforse;
    public int cofactor;
    public bool isGrounded;
    public Vector3 ToSpawn;
    void Start()
    {
        suprmachinasastus = GetComponent <Rigidbody> ();
    }

    void FixedUpdate()
    {
        suprmachinasastus.velocity = new Vector3 (Input.GetAxis("Vertical")*-Vspeed*Time.fixedDeltaTime, suprmachinasastus.velocity.y , Input.GetAxis("Horizontal")*Hspeed*Time.fixedDeltaTime);
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)&& STOYAK ){
            suprmachinasastus.AddForce(0,jumpforse, 0);
            isGrounded = false;
        }
        if(this.gameObject.GetComponent<Transform>().position.y <= -30)
            this.gameObject.GetComponent<Transform>().position = ToSpawn;
     
    }
    void OnCollisionStay(Collision other){
        if(other.gameObject.tag == "XYI")//переименуй тег в юнити
            isGrounded = true;
            // стояк включен
    }
}
