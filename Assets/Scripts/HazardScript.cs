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
		GameObject spawnedBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
		spawnedBullet.GetComponent<BulletScript>().launchBullet(player.transform.position - transform.position, 0.5f);
    }
	
	void FixedUpdate(){
		time += Time.deltaTime;
		if (time > delay){
			time = 0f;
			playerCoord = player.transform.position;
			direction = (playerCoord - transform.position);
				
			
		}
		if (myRB.transform.position == playerCoord){
			playerCoord = player.transform.position;
		}
		myRB.linearVelocity = direction * speed;
		
	}

    // Update is called once per frame
    void Update()
	
	
    {
		
      

    }
}
