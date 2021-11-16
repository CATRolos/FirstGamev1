using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class monokumaController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 movement;
    public float speed;
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = new Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f));
        MoveKuma(movement);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    
    }
    void MoveKuma(Vector2 vel){
        rb.velocity = vel * speed;
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.name == "galaOmegaBullet(Clone)" && this.name=="monokumaHead"){
            SceneManager.LoadScene(0);
        }
    }

}
