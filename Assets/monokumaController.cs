using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class monokumaController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 movement;
    public float speed;
    public float stopDistance;
    public float retreatDistance;

    GameObject bullet;

    float bulletCooldown = 0f;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bullet = transform.GetChild(0).gameObject;
        player = GameObject.Find("galaOmega").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) > stopDistance){
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stopDistance && Vector2.Distance(transform.position, player.position) > retreatDistance){

        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance){
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if(bulletCooldown <= 0){
            FireBullet();
            bulletCooldown = 3;
        }
        else if (bulletCooldown > 0){
        bulletCooldown -= Time.deltaTime;
        }
    
    }
    void MoveKuma(Vector2 vel){
        rb.velocity = vel * speed;
    }

    void FireBullet(){
        GameObject temp = Instantiate(bullet, transform.position, transform.rotation);
        temp.GetComponent<SpriteRenderer>().enabled = true;
        temp.GetComponent<kumaBulletController>().enabled = true;
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.name == "galaOmegaBullet(Clone)" && this.name=="monokumaHead"){
            SceneManager.LoadScene(0);
        }
    }

}
