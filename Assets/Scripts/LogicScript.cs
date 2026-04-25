using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    [SerializeField] 
    private GameObject target;
    [SerializeField]
    private Camera cam;

    public GameObject winObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isVisible())
        {
            //Debug.Log("In Camera");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //https://youtu.be/kn7rL8Jeexo?si=8dglj940CHcyF67s
            //Debug.Log("Outside Camera");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Win")
        {
            SceneManager.LoadScene("Win");
        }

    }

    private bool isVisible()
    {
        //Get every single plane of the camera frustrum
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);
        //Return true if the object is inside every single plane of the frustrum
            if (planes[2].GetDistanceToPoint(target.transform.position) >= 0) 
            {
                return true;
            }
        else
        {
            return false;
        }
            
        //https://youtu.be/38BtpQWEct4?si=TkqhBBqhTodTv0j- 
    }
/**
 * Non lambda alternative:
 * foreach (var plane in planes){
 *      if (plane.GetDistanceToPoint(target.transform.position) >= 0){
 *          return false;
 *      }
 *      
 * }
 * return true;
}
**/

    //Lambda alternative:
    //return planes.All(plane => plane.GetDistanceToPoint(target.transform.position) >= 0);
}
