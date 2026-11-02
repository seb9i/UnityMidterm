using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class HazardScript : MonoBehaviour
{
    
	
	public Rigidbody2D myRB;
	public GameObject player;
	public float delay;
	public float time = 0f;
	public float speed;
	public float bulletSpeed;
	public Vector2 direction;
	public Vector3 playerCoord;
	public GameObject bulletPrefab;

	public ParticleSystem smokeParticles;
	public bool knockBack;
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
		smokeParticles = GetComponentInChildren<ParticleSystem>();
		if (RoundManager.currentRound == 1)
		{
			StartCoroutine(roundOne());
		}

		if (RoundManager.currentRound == 2)
		{
			StartCoroutine(roundTwo());
		}

		if (RoundManager.currentRound == 3)
		{
			StartCoroutine(roundThree());
		}
    }
	
	
	void launchBullet(Vector2 direction, float speed){

		myRB.AddForce(-direction.normalized * 1.2f, ForceMode2D.Impulse);
		GameObject spawnedBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
		spawnedBullet.name = "Active Bullet";
		spawnedBullet.GetComponent<BulletScript>().launchBullet(direction, speed);
		smokeParticles.Play();

	}
	
	private IEnumerator sprayVolley(float delay, int length, float speed){
		for (int i = 0; i < length; i++) {
			launchBullet(direction, speed);
			yield return new WaitForSeconds(delay);
		}
	}

	void shotgunBlast(float speed){
		launchBullet(direction, speed);
		launchBullet(direction + new Vector2(0, -0.4f), speed);
		launchBullet(direction + new Vector2(0, 0.4f), speed);
	}

	private IEnumerator roundOne()
	{
		while (true)
		{
			yield return new WaitForSeconds(1f);

			launchBullet(direction, bulletSpeed);
			yield return new WaitForSeconds(2f);
			yield return null;
		}
		
	}

	private IEnumerator roundTwo()
	{
		bulletSpeed *= 1.05f;
		while (true)
		{
			yield return new WaitForSeconds(1f);
			launchBullet(direction, bulletSpeed);
			yield return new WaitForSeconds(1f);
			launchBullet(direction, bulletSpeed);
			yield return new WaitForSeconds(1f);
			StartCoroutine(sprayVolley(0.3f, 4, bulletSpeed));
			yield return new WaitForSeconds(1f);
			yield return null;
		}
	}

	private IEnumerator roundThree()
	{
		bulletSpeed *= 1.05f;
		while (true)
		{
			yield return new WaitForSeconds(1f);
			StartCoroutine(sprayVolley(0.3f, 4, bulletSpeed));
			yield return new WaitForSeconds(1f);
			launchBullet(direction, bulletSpeed);
			yield return new WaitForSeconds(1f);
			StartCoroutine(sprayVolley(0.3f, 4, bulletSpeed));
			yield return new WaitForSeconds(2f);
			shotgunBlast(bulletSpeed);
			
			yield return null;
		}
	}
	
	void FixedUpdate(){
		time += Time.fixedDeltaTime;
		
		
		if (myRB.transform.position == playerCoord){
			playerCoord = player.transform.position;
		}

		smokeParticles.transform.rotation = Quaternion.LookRotation(direction);
		playerCoord = player.transform.position;
		direction = (playerCoord - transform.position).normalized;
		myRB.AddForce(direction * speed);
		

	
	}

    // Update is called once per frame
    void Update()
	
	
    {
		
      

    }
}
