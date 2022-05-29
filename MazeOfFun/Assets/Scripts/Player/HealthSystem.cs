using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public int health = 10;
    public GameObject cube;
    public Material damageMat, normalMat;
    private int countDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(countDown <= 0)
        {
            Material[] newMaterials = new Material[] { normalMat};
            cube.GetComponent<MeshRenderer>().materials = newMaterials;
        } else{
            countDown -= 1;
        }

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            health -= 1;
            countDown = 120;
            Material[] newMaterials = new Material[] { damageMat};
            cube.GetComponent<MeshRenderer>().materials = newMaterials;
            if (health <= 0)
            {
            SceneManager.LoadScene("MenuScene");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            countDown = 120;
            Material[] newMaterials = new Material[] { damageMat};
            cube.GetComponent<MeshRenderer>().materials = newMaterials;
            health -= 1;
            if (health <= 0)
            {
                SceneManager.LoadScene("MenuScene");
            }
        }
    }
}
