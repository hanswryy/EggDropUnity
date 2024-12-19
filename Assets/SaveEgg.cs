using UnityEngine;

public class SaveEgg : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "egg")
        {
            Debug.Log("Egg Saved");
            Destroy(other.gameObject);
        }
    }
}
