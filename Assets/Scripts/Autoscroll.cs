using UnityEngine;

public class Autoscroll : MonoBehaviour
{
    public float speed = 1;


    // Update is called once per frame
    void Update()
    {
        this.transform.position = this.transform.position + Vector3.up * speed * Time.deltaTime;
    }
}
