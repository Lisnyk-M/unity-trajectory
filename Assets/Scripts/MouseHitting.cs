using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHitting : MonoBehaviour
{
    public Camera camera;

    void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        float drawLength = 50.0f;
        Debug.DrawRay(ray.origin, ray.direction * drawLength, color: Color.green);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 pos = hit.point;
                GameObject s = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                s.transform.position = pos;
                s.transform.localScale = new Vector3(.2f, .2f, .2f);
                Debug.Log($"Point: {pos}");
            }
        }
    }
}
