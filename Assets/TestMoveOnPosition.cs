using UnityEngine;

public class TestMoveOnPosition : MonoBehaviour
{
    [SerializeField]
    private Transform destination;

    void Update()
    {
        transform.position = destination.position;
    }
}
