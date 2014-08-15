using UnityEngine;
using System.Collections;

public class GodzillaBounceAround : MonoBehaviour
{
    private bool GoLeft = true;
    private bool GoRight = false;

    // Use this for initialization
    void Start()
    {
    
    }
    
    // Update is called once per frame
    void Update()
    {
        if (GoLeft)
        {   
            rigidbody.velocity = new Vector3(0, 0, 0);
            Quaternion newRotation = Quaternion.AngleAxis(90, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 0.1f);
        } 
        else if (GoRight)
        {   
            rigidbody.velocity = new Vector3(0, 0, 0);
            Quaternion newRotation = Quaternion.AngleAxis(270, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 0.1f);
        }

        if (Mathf.Abs(transform.rotation.eulerAngles.y - 90) < 1)
        {
            rigidbody.velocity = new Vector3(-10, 0, 0);
        } else if (Mathf.Abs(transform.rotation.eulerAngles.y - 270) < 1)
        {
            rigidbody.velocity = new Vector3(10, 0, 0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Terrain")
        {
        }

        else if (collision.gameObject.name == "Wall1")
        {
            GoLeft = false;
            GoRight = true;
        }

        else if (collision.gameObject.name == "Wall2")
        {
            GoLeft = true;
            GoRight = false;
        }
    }
}
