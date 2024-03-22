using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightChangeHandler : MonoBehaviour
{
    private bool dayChanged = false;
    private bool sunActived = true;
    public DayNightChange daynight;
    public KukkaPlatformScript kukkaplatform;
    public SaniaisSiltaScript saniaissilta;
    public VineScript vine;
    public GameObject[] kukat;
    public GameObject[] sillat;
    public GameObject[] vines;
    // Start is called before the first frame update
    void Start()
    {
        //daynight.GetComponent<DayNightChange>().DayChange(sunActived);
        kukat = GameObject.FindGameObjectsWithTag("KukkaPlatform");
        sillat = GameObject.FindGameObjectsWithTag("SaniaisSilta");
        vines = GameObject.FindGameObjectsWithTag("Vine");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dayChanged = true;
        }
    }

    private void FixedUpdate()
    {
        if (dayChanged)
        {
            Debug.Log("Day changed!");
            sunActived = !sunActived;

            foreach (GameObject gameObject in sillat)
            {
                gameObject.GetComponent<SaniaisSiltaScript>().BridgeChange(sunActived);
            }

            foreach (GameObject gameObject in kukat)
            {
                gameObject.GetComponent<KukkaPlatformScript>().FlowerChange(sunActived);
                Debug.Log(gameObject.transform.position);
            }

            foreach (GameObject gameObject in vines)
            {
                gameObject.GetComponent<VineScript>().VineActivation(sunActived);
            }
            
            daynight.GetComponent<DayNightChange>().DayChange(sunActived);
            dayChanged = false;
        }
    }
}