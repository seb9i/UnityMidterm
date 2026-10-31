using UnityEngine;

public class HazardScript : MonoBehaviour
{
    
	
	public Rigidbody2D myRB;
	public GameObject player;
	public float delay;
	public float time = 0f;
	public float speed = 5f;
	public Vector2 direction;
	public Vector3 playerCoord;
	public GameObject bulletPrefab;
	
	
	
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }
	
	void spawnBullet(Vector2 direction, float speed){
		GameObject spawnedBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
		spawnedBullet.name = "Active Bullet";
		spawnedBullet.GetComponent<BulletScript>().launchBullet(direction, speed);
	}
	
	void FixedUpdate(){
		time += Time.deltaTime;
		if (time > delay){
			time = 0f;
			spawnBullet(direction, 4f);
				
			
		}
		if (myRB.transform.position == playerCoord){
			playerCoord = player.transform.position;
		}
		playerCoord = player.transform.position;
		direction = (playerCoord - transform.position);
		myRB.linearVelocity = direction * speed;
		
	}

    // Update is called once per frame
    void Update()
	
	
    {
		
      

    }
}
