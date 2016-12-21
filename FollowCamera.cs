using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour
{

    public Transform Ninio;
    public float separacion = 6f;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Ninio.position.x + separacion, transform.position.y, transform.position.z);
    }
}
