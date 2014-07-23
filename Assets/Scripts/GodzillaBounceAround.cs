using UnityEngine;
using System.Collections;

public class GodzillaBounceAround : MonoBehaviour
{

    private bool onTheGround = false;

    // Use this for initialization
    void Start()
    {
    
    }
    
    // Update is called once per frame
    void Update()
    {
        if (onTheGround)
        {
            rigidbody.velocity = new Vector3(Random.Range(-25,25), 25, Random.Range(-25,25));
            onTheGround = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Terrain")
        {
            onTheGround = true;
        }
    }
}
