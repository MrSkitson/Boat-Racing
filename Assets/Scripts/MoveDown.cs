using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    private float zDestroy = -20;
    private Rigidbody objectRb;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody();// add method -Abstraction;
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy(); // add method -Abstraction;
    }

    void Rigidbody()
    {
      objectRb = GetComponent<Rigidbody>();
    }

    // Method add Force for Move and Destroy objects 
   public virtual  void MoveEnemy()
    {
      objectRb.AddForce(Vector3.forward * -speed);

        if (transform.position.z < zDestroy) // Destroy Enemy whose are in death position
        {
    
            Destroy(gameObject);
        }
    }
    
}
