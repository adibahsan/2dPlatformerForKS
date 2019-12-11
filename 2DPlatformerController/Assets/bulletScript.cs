using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
	// Start is called before the first frame update
	[SerializeField]
	Rigidbody2D rigidbody;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void FixedUpdate()
	{
		rigidbody.velocity = new Vector2(3, rigidbody.velocity.y);
	}
}
