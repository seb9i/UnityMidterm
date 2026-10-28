using UnityEngine;

public class BulletScript : MonoBehaviour
{
	public Rigidbody2D RB;
	public float xLimit = 14.0f;
	public float yLimit = 6.0f;
	public Vector2 velocity = new Vector2(0f, 0f);
	
	

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		RB = GetComponent<Rigidbody2D>();
		

    }
	
	public void launchBullet(Vector2 direction, float speed){
		velocity = direction * speed;
		
	}

    // Update is called once per frame
    void Update()
    {
		RB.linearVelocity = velocity;

        if (Mathf.Abs(transform.position.x) >= xLimit || Mathf.Abs(transform.position.y) >= yLimit){
			Destroy(gameObject);
		}
    }
}
