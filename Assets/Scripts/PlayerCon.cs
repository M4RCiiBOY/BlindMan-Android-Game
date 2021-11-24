using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour {

    public GameObject Player;

    public float speed;
    public float velocity;
    public float time;
    float gravity;
    public float distance;

	bool onFloor;


	// Use this for initialization
	void Start ()
    {
        distance = .55f;
        gravity = 0f;

    }
	
	// Update is called once per frame
	void Update ()
    {
       // MoveLeft();
        OnGround();
	}


    void OnGround()
    {

        if (Physics.Raycast(Player.transform.position,-Player.transform.up,distance))
        {
            Debug.DrawRay(Player.transform.position, -Player.transform.up, Color.red);
            Debug.Log("hiT");
            gravity = 0f;
            if (Player.transform.position.y >= -0.35f)
            {
                Player.transform.position = new Vector3(Player.transform.position.x,-.35f,Player.transform.position.z);
            }
            

        }
        else
        {
            
            Player.transform.position -= new Vector3( 0, gravity += velocity * Time.deltaTime, 0) * Time.deltaTime;
            Debug.DrawRay(Player.transform.position, -Player.transform.up, Color.green,distance);
        }
       
    }


    void MoveLeft()
    {
        RaycastHit hit;

        if (Physics.Raycast(Player.transform.position,Player.transform.right, out hit,distance))
        {
            Debug.DrawRay(Player.transform.position,Player.transform.right, Color.red);
        }

        else
        {
            Player.transform.position += new Vector3(speed, Player.transform.position.y, Player.transform.position.z);
            Debug.DrawRay(Player.transform.position, -Player.transform.up, Color.green, distance);
        }
    }



}
