using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float xInitialForce;
    public float yInitialForce;

    // Start is called before the first frame update
    void Start()
    {   
        rb2D = GetComponent<Rigidbody2D>();
        Restart_Game();
    }

    void Restart_Game(){
        Reset_Ball();
        Invoke("Push_Ball", 2);
    }

    void Reset_Ball(){
        transform.position = Vector2.zero;
        rb2D.velocity = Vector2.zero;           
    }

    void Push_Ball(){
        // no 1 memasukan y force kedalam array, agar random tidak berjarak antara -y dan y namun random memilih antara kedua -y atau y
        float[] array = {-yInitialForce, yInitialForce};
        int index = Random.Range(0, array.Length);

        float yRandomInitialForce = array[index];
        float randomDirection = Random.Range(0,2);

        if (randomDirection < 1f){
            rb2D.AddForce(new Vector2(-xInitialForce, yRandomInitialForce));
        }else{
            rb2D.AddForce(new Vector2(xInitialForce, yRandomInitialForce));
        }
    }

}
