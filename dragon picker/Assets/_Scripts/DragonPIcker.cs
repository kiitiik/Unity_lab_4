using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragonPIcker : MonoBehaviour
{
    public GameObject energyShieldPrefab;
    public int numEnergyShield = 3;
    public float energyShieldBottomY = -6f;
    public float energyShieldRadius = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        shieldList = new List<GameObject>();
        for (int i=1;i <= numEnergyShield;i++){
        GameObject tShieldGo = Instantiate<GameObject>(energyShieldPrefab);
        tShieldGo.transform.position = new Vector3(0, energyShieldBottomY, 0);
        tShieldGo.transform.localScale = new Vector3(1*i,1*i,1*i);
        shieldList.Add(tShieldGo);
        }
    }
    public List<GameObject> shieldList;

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DraggonEggDestroyed(){
        GameObject[] tDragonEggArray = GameObject.FindGameObjectsWithTag("Draggon egg");
        foreach (GameObject tGO in tDragonEggArray){
            Destroy (tGO);
        }
        int shieldIndex = shieldList.Count - 1;
        GameObject tShieldGo = shieldList[shieldIndex];
        shieldList.RemoveAt(shieldIndex);
        Destroy(tShieldGo);
        if (shieldList.Count ==0){
            SceneManager.LoadScene("_0Scene");
        }
    }
}
