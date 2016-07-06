using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour {

    public class PlayerEvent : UnityEvent
    {

    }
    public static PlayerEvent playerDeath = new PlayerEvent();
    public static PlayerEvent collectPickUp = new PlayerEvent();

    public float speed;

	private Rigidbody rb;
    private Vector3 origin;

	void Start() 
	{
		rb = GetComponent<Rigidbody>();
        origin = gameObject.transform.position;
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}


    void OnCollisionEnter(Collision other) {       
        if (other.gameObject.CompareTag("Enemy"))
        {
            playerDeath.Invoke();
            gameObject.transform.position = origin;
            rb.velocity = new Vector3();
        }	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            collectPickUp.Invoke();
        }
    }
}
