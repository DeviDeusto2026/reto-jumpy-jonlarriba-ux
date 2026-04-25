using UnityEngine;

public class PlatformSpawning : MonoBehaviour
{
    public Transform firstPlatform;
    public int numberOfPlatforms;
    public GameObject platformToInstantiate;
    public GameObject finalPlatform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetPlatNumber(StaticData.numberOfPlatforms);
        int i = 0;
        for (i = 0; i<numberOfPlatforms; i++)
        {
            float ran = Random.Range(-6f, 6f);
            Vector3 v3 = new Vector3(ran, firstPlatform.position.y * (i + 2), firstPlatform.position.z);
            GameObject plat = Object.Instantiate(platformToInstantiate, v3, Quaternion.identity);
            plat.transform.Rotate(90.0f, 0.0f, 0.0f, Space.World);
        }
        finalPlatform.SetActive(true);
        float rand = Random.Range(-6f, 6f);
        Vector3 v3f = new Vector3(rand, firstPlatform.position.y * (i + 2), firstPlatform.position.z);
        GameObject platf = Object.Instantiate(finalPlatform, v3f, Quaternion.identity);

    }

    public void SetPlatNumber(int numbeOfPlatforms)
    {
        numberOfPlatforms = numbeOfPlatforms;
    }

}
