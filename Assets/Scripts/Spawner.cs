using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private bool lmbPressed = false;
    public TrajectoryRenderer Trajectory;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!lmbPressed)
            {
                ShutI(bullet, 10f);
            }
            lmbPressed = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            lmbPressed = false;
        }
    }
    public void ShutI(GameObject prefab, float force)
    {      
        Vector3 rotate;
        rotate = transform.rotation.eulerAngles;

        GameObject bullet = Instantiate(prefab) as GameObject;
        bullet.transform.position = transform.position;

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        Vector3 velocity = new Vector3(-Mathf.Cos((rotate.z) * Mathf.PI / 180),
            -Mathf.Sin((rotate.z ) * Mathf.PI / 180), 0);        

        Debug.Log($"Velocity: {velocity}");
        velocity *= force;
        rb.velocity = velocity;
       
        //Trajectory.Show_trajectory(Vector3.zero, velocity);
    }
}
