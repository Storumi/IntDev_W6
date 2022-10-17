using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //for tuning
    public float speed;

    public float raycastDist;
    public float jumpForce;

    //for particles
    public ParticleBurst burstParticles;
    public ParticleTrail trailParticles;

    Rigidbody2D myBody;
    float moveX;
    bool jump = false;
    bool onGround = false;

    bool hasHit = false;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //inputs
        VerticalMovement();
        HorizontalMovement();

        HandleParticles();
    }

    void FixedUpdate(){
        //horizontal velocity
        myBody.velocity = new Vector3(moveX, myBody.velocity.y);    

        //vertical velocity aka jumping
        if(jump){
            myBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDist);
        if(hit.collider != null && hit.transform.tag == "Ground"){
            if(!onGround){
                Debug.Log("play parts");
                hasHit = true;
            } else{
                hasHit = false;
            }
            onGround = true;
        } else{
            onGround = false;
        }
    }

    void HorizontalMovement(){
        moveX = (Input.GetAxis("Horizontal") * speed) * Time.fixedDeltaTime;
    }

    void VerticalMovement(){
        if(Input.GetKeyDown(KeyCode.Space) && onGround){
            jump = true;
        }
    }

    void HandleParticles(){
        if(burstParticles != null && hasHit){
            burstParticles.Burst();
        }
        if(trailParticles != null){
            if(myBody.velocity.x != 0){
                Debug.Log("I should play!");
                trailParticles.StartTrail();
            } else{
                trailParticles.StopTrail();
            }
        }
    }
    
}
