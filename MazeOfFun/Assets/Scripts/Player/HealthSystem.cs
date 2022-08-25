using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 10;
    public int health = 10;
    public GameObject cube;
    public Material damageMat, normalMat;
    public Material regenMat;
    private int countDown;
    private int regenCount;
    int twoSec = 120;
    int tenSec = 1260;
    int dead = 0;
    int dmg = 1;
    int gainHealth = 60;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void awake() 
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if(countDown <= 0)
        {
            Material[] newMaterials = new Material[] { normalMat};
            cube.GetComponent<MeshRenderer>().materials = newMaterials;
        } else{
            countDown --;
        }

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            health -= dmg;
            countDown = twoSec;
            
            Material[] newMaterials = new Material[] { damageMat};
            cube.GetComponent<MeshRenderer>().materials = newMaterials;
            if (health <= dead)
            {
            SceneManager.LoadScene("MenuScene");
            }
        }

        if (health < maxHealth && regenCount == 0)
        {
            regenCount = tenSec;
        }

        if (health < maxHealth && regenCount > 0)
        {
            regenCount--;

            if (regenCount == gainHealth)
            {
                health++;
                Material[] newMaterials = new Material[] { regenMat};
                cube.GetComponent<MeshRenderer>().materials = newMaterials;
            }
        }
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            countDown = twoSec;
            Material[] newMaterials = new Material[] { damageMat};
            cube.GetComponent<MeshRenderer>().materials = newMaterials;
            health -= dmg;
            if (health <= dead)
            {
                SceneManager.LoadScene("MenuScene");
            }
        }
    }
    */
}
