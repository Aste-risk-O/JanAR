using UnityEngine;

public class Billboard : MonoBehaviour
{
    void Update()
    {
        if (Camera.main != null)
        {
            // Поворачиваем текст к камере
            transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
                             Camera.main.transform.rotation * Vector3.up);
        }
    }
}