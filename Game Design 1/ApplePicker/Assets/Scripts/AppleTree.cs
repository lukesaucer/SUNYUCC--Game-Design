using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
	[Header("Inscribed")]
	//prefab for instantiating apples
	public GameObject applePrefab;
	
	// Speed at which the AppleTree moves
	public float speed = 1f;
	
	// Distance where AppleTree turns around
	public float leftAndRightEdge = 10f;
	
	// Chance that the AppleTree will change directions
	public float changeDirChance = 0.1f;
	
	// Seconds between Apple Instantiation
	public float appleDropDelay = 1f;
	
    // Start is called before the first frame update
    void Start()
    {
        // Start dropping apples
		Invoke("DropApple", 2f);
    }
	
	void DropApple(){
		GameObject apple = Instantiate<GameObject>(applePrefab);
		apple.transform.position = transform.position;
		Invoke("DropApple", appleDropDelay);
	}

    // Update is called once per frame
    void Update()
    {
        //Basic Movement
		Vector3 pos = transform.position; // gets tree position
		pos.x += speed * Time.deltaTime; // calculates new position
		transform.position = pos;        // move the tree
		
		if (pos.x < -leftAndRightEdge){
			speed = Mathf.Abs(speed);  // Move right
		} else if (pos.x > leftAndRightEdge){
			speed = -Mathf.Abs(speed); // Move leftAndRightEdge
		} //else if (Random.value < changeDirChance){
		//	speed *= -1;
		//}
    }
	
	void FixedUpdate(){
		if (Random.value < changeDirChance){
			speed *= -1;
		}
	}
}
