using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shipController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 movement;
    public float speed;
    public float rotationSpeed;
    float direction;
    GameObject bullet;

    float bulletCooldown = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bullet = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(0, Input.GetAxisRaw("Vertical"));

        if(Input.GetKey(KeyCode.A)){
            direction = 1;
        }
        else if((Input.GetKey(KeyCode.D))){
            direction = -1;
        }
        else{
            direction = 0;
        }

        if(Input.GetKey(KeyCode.LeftShift) && bulletCooldown <=0 ){
            FireBullet();
            bulletCooldown = 15;
        }
    }

    void FixedUpdate(){
        MoveShip(movement);
        if (bulletCooldown > 0f){
        bulletCooldown -= 1;
        }
    }

    void MoveShip(Vector2 vel){
        rb.AddRelativeForce(vel * speed);
        rb.AddTorque(direction * rotationSpeed);
    }

    void FireBullet(){  
        GameObject temp = Instantiate(bullet, transform.position, transform.rotation);
        temp.GetComponent<Rigidbody2D>().isKinematic = false;
        temp.GetComponent<bulletController>().enabled = true;
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.name == "monokumaBullet(Clone)" && this.name=="galaOmega"){
            SceneManager.LoadScene(0);
        }
    }    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.name == "monokumaHead" && this.name=="galaOmega"){
            SceneManager.LoadScene(0);
        }
    }
}
