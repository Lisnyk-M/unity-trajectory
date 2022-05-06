using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    public TrajectoryRenderer Trajectory;
    private Vector3 mousePos2D;
    private Vector3 eulerRotate = new Vector3(0, 0, 0);
    private Quaternion gunRotation = Quaternion.Euler(0, 0, 0);
    private Quaternion currentRotation = Quaternion.Euler(0, 0, 0);
    private UpdatingValue updatingValue;
    private RunMethod runMethod;
    private bool lmbPressed = false;
    private float bias;
    
    private void Awake()
    {
        runMethod = upd;
        updatingValue = new UpdatingValue();
    }
    private void Start()
    {
        bias = -Input.mousePosition.y;
    }
    public void upd()
    {
        transform.rotation = gunRotation;
    }

    void Update()
    {
        mousePos2D = Input.mousePosition;
        eulerRotate = transform.rotation.eulerAngles;
        eulerRotate.z = 2.0f * (mousePos2D.y);
        gunRotation = Quaternion.Euler(eulerRotate);
        updatingValue.CheckingValue(eulerRotate.z, 0.001f, upd);
    }
}
