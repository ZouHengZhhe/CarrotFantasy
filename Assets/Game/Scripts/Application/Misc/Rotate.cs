using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float Speed = 360;

    private void Update()
    {
        transform.Rotate(Vector3.forward, Time.deltaTime * Speed, Space.Self);
    }
}