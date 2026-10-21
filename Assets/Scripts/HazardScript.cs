using UnityEngine;

public class HazardScript : MonoBehaviour
{
    
	
	public Rigidbody2D myRB;
	public GameObject player;
	public float delay = 1.5f;
	public float time = 0f;
	public float speed = 5f;
	public Vector3 playerCoord;
	
	
	
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }
	
	void FixedUpdate(){
		time += Time.deltaTime;
		if (time > delay){
			time = 0f;
			playerCoord = player.transform.position;
		}
		float step = speed * Time.fixedDeltaTime;
		Vector3 newPosition = Vector3.MoveTowards(myRB.position, playerCoord, step);
		myRB.MovePosition(newPosition);
		
	}

    // Update is called once per frame
    void Update()
	
	
    {
		
      

    }
}
