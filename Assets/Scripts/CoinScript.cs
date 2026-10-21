using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CoinScript : MonoBehaviour
{
    //The player calls this function on the coin whenever they bump into it
    //You can change its contents if you want something different to happen on collection
    //For example, what if the coin teleported to a new location instead of being destroyed?
	
	void Start() {
	}
	
	
    public void GetBumped()
	
    {
		Vector3 randomCoord = new Vector3(Random.Range(-7.0f, 10f), Random.Range(-2, 4.5f), Random.Range(1.0f, 10f));
        Instantiate(gameObject, randomCoord, Quaternion.identity);
        Destroy(gameObject);
    }
	
	private void OnCollisionEnter2D(Collision2D other) {
		
		
	}
	

}
