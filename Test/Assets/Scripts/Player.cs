using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private Transform groundCheckTransform = null;
	[SerializeField] private LayerMask playerMask;
	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private Inventory bag;

	bool jumpKey = false;
	float horizontalInput;
	Collider2D activeTree = null;
	
    // Start is called before the first frame update
    void Start()
    {
		

	}

    // Update is called once per frame
    void Update()
    {
        // Check if space is pressed
		if (Input.GetKeyDown(KeyCode.Space))
		{
			jumpKey = true;
		}
		
		// Check if E is pressed
		if (Input.GetKeyDown (KeyCode.E))
		{
			if (activeTree != null)
			{
				Destroy (activeTree.gameObject);
				activeTree = null;
				bag.numWood++;
				Debug.Log("Wood Count = " + bag.numWood);
			}
		}
		
		horizontalInput = Input.GetAxis("Horizontal");
    }
	
	// FixedUpdate is called once per phsyics update
	void FixedUpdate()
	{
		rb.velocity = new Vector2(horizontalInput * 3, rb.velocity.y);
		
		if (Physics2D.OverlapCircleAll(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
		{
			jumpKey = false;
			return;
		}
		
		//Make the player jump
		if (jumpKey == true)
		{
			rb.AddForce(Vector2.up * 7, ForceMode2D.Impulse);
			jumpKey = false;
		}
	}
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		// Tree Layer is 7 pog
		if (collision.gameObject.layer == 7)
		{
			activeTree = collision;
		}
	}
	
	private void OnTriggerExit2D(Collider2D collision)
	{
		// Tree Layer is 7 pog
		if (collision.gameObject.layer == 7)
		{
			activeTree = null;
		}
	}
}
