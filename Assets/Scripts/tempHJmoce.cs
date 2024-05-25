using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempHJmoce : MonoBehaviour
{
    public Rigidbody2D rigit;
    public int oxygen;
    const int MAX_OXYGEN = 100;



    public void gasTaken()
    {
        oxygen = MAX_OXYGEN;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 1, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position = new Vector3(this.transform.position.x - 1, this.transform.position.y, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y, 0);
        }
    }
}
