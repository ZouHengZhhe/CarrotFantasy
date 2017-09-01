using UnityEngine;

public class TestOnDrawDizmos : MonoBehaviour
{
    private void OnGUI()
    {
        print("OnGUI");
    }

    private void OnDrawGizmos()
    {
        print("OnDrawGizmos");
    }
}