using UnityEngine;

public class ShowShelterModel : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        Debug.Log("A collider is in contact with the DoorObject Collider");
    }
}
