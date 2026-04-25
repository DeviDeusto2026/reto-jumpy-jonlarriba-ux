using UnityEngine;

public class LogicScript : MonoBehaviour
{
    public Transform spawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Void"))
        {
            gameObject.transform.position = spawn.position;
        }
    }
}
