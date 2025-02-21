using UnityEngine;

public class RotateToCamera : MonoBehaviour
{
    [SerializeField]
    private Transform obj;
    void Update() {
        obj.rotation = Quaternion.LookRotation(obj.position - Camera.main.transform.position);
    }
}
