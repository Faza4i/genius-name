using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class супермагакактусмашина : MonoBehaviour
{
    private Rigidbody suprmachinasastus;
    public float Hspeed;
    public float Vspeed;
    public float jumpforse;
    public bool STOYAK;
    public Vector3 SydaNahyi;
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
            STOYAK = false;
        }
        if(this.gameObject.GetComponent<Transform>().position.y <= -30)
            this.gameObject.GetComponent<Transform>().position = SydaNahyi;
    }
    void OnCollisionStay(Collision BIGDICK){
        if(BIGDICK.gameObject.tag == "XYI")
            STOYAK = true;
            // стояк включен
    }
}
