using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public KeyCode upButton;
    public KeyCode downButton;
    public float speed = 10.0f;
    public float yBoundary = 9.0f;
    private Rigidbody2D rb2d;
    private int score;
    private Vector2 trajectoryOrigin;

    public Transform trans;
    
    private ContactPoint2D lastContactPoint;

    // Start is called before the first frame update
    void Start()
    {   
        rb2d = GetComponent<Rigidbody2D>();
        trajectoryOrigin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rb2d.velocity;
        if(Input.GetKey(upButton)){
            velocity.y = speed;
        }else if(Input.GetKey(downButton)) {
            velocity.y = -speed;
        }else{
            velocity.y = .0f;
        }
        rb2d.velocity = velocity;

        Vector3 position = transform.position;
        if (position.y > yBoundary){
            position.y = yBoundary;
        }else if (position.y < -yBoundary){
            position.y = -yBoundary;
        }
        transform.position = position;
    }

    public void Increment_Score(){
        score++;

        // No2 jika pemain mencetak score maka sizenya akan bertambah satu selama 15 detik
        trans.localScale += new Vector3(0, 1, 0);
        // setelah 15 detik akan memanggil method Scale_Normal untuk mengebalikan Scale ke 1,1,1
        Invoke("Scale_Normal", 15);
    }

    public void Reset_Score(){
        score = 0;
    }

    public int Score{
        get{return score;}
    }

    public ContactPoint2D LastContactPoint{
        get {return lastContactPoint;}
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Equals("Ball"))
        {
            lastContactPoint = collision.GetContact(0);
        }
    }    

    private void OnCollisionExit2D(Collision2D other) {
        trajectoryOrigin = transform.position;    
    }

    public Vector2 TrajectoryOrigin{
        get {return trajectoryOrigin;}
    }

    public void Scale_Normal(){
        trans.localScale = new Vector3(1,1,1);
    }

}
