using UnityEngine;

public class EggDrop : MonoBehaviour
{
    private Rigidbody rb;
    public float additionalForce = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the Rigidbody component attached to this GameObject
        rb = GetComponent<Rigidbody>();

        // If the Rigidbody component is not found, add one
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }

        // Ensure the Rigidbody uses gravity
        rb.useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Optionally, you can add additional downward force if needed
        rb.AddForce(Vector3.down * additionalForce);
    }
}