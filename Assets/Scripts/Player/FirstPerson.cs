using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FirstPerson : MonoBehaviour
{
    private Rigidbody rb;

    float currentCamRotX = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Movement(float speed, Vector3 velocity)
    {
        bool move = velocity != Vector3.zero;

        if (move)
        {
            rb.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
            speed += 0.2f;
        }
        else
        {
            speed = Mathf.Lerp(speed, 0f, 20 * Time.deltaTime);
        }
        speed = Mathf.Clamp(speed, -5, 5);
    }

    public void Rotation(Vector3 rotation, float cameraRotationX, float camRotLimit)
    {
        rb.MoveRotation(transform.rotation * Quaternion.Euler(rotation));
        if (this.GetComponentInChildren<Camera>() != null)
        {
            currentCamRotX -= cameraRotationX;
            currentCamRotX = Mathf.Clamp(currentCamRotX, -camRotLimit, camRotLimit);

            this.GetComponentInChildren<Camera>().transform.localEulerAngles = new Vector3(currentCamRotX, 0f, 0f);
        }
    }
}
