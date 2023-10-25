using UnityEngine;

public class RotateOnClick : MonoBehaviour
{
    [SerializeField] private float turnSpeed = 1f;
    [SerializeField] private Camera cam;

    void Awake()
    {
        if (cam == null)
            cam = FindObjectOfType<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            
            // Used to store info about what the ray hits
            RaycastHit hit;
        
            float clickPosX = 0f;
            // Raycast -> to shoot the ray
            if (Physics.Raycast(ray, out hit))
            {
                clickPosX = hit.point.x;
            }
        
            if (clickPosX < this.transform.position.x)
            {
                transform.Rotate(-90f * turnSpeed * Vector3.up, Space.World);
            }
            else if (clickPosX > this.transform.position.x)
            {
                transform.Rotate(90f * turnSpeed * Vector3.up, Space.World);
            }
        }
    }
}
