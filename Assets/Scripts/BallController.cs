using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float xInitialForce;
    public float yInitialForce;

    private Vector2 trajectoryOrigin;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trajectoryOrigin = transform.position;
        RestartGame();
    }

    void ResetBall()
    {
        transform.position = Vector2.zero; //reset posisi menjadi (0,0)
        rb.velocity = Vector2.zero; //reset kecepatan menjadi 0
    }

    void PushBall()
    {
        //Tentukan nilai komponen y dari gaya dorong antara -yInitialForce dan yInitialForce
        float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);

        //Tentukan nilai acak antara 0 (inklusif) dan 2 (eksklusif)
        float randomDirection = Random.Range(0, 2);

        // jika nilai < 1 = ke kiri | jika nilai > 1 = ke kanan
        if (randomDirection < 1f)
        {
            rb.AddForce(new Vector2(-xInitialForce, yRandomInitialForce));
        }
        else
        {
            rb.AddForce(new Vector2(xInitialForce, yRandomInitialForce));
        }
    }

    void RestartGame()
    {
        ResetBall();

        Invoke("PushBall", 2);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }

    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }
}
