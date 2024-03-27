using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightChangeHandler : MonoBehaviour
{
    private bool dayChanged = false;
    private bool dayChanging = false;
    private bool sunActived = true;
    public DayNightChange daynight;
    public KukkaPlatformScript kukkaplatform;
    public NightKukkaPlatformScript nightkukkaplatform;
    public SaniaisSiltaScript saniaissilta;
    public VineScript vine;
    public GameObject[] kukat;
    public GameObject[] nightKukat;
    public GameObject[] sillat;
    public GameObject[] vines;
    public GameObject[] peikko;
    // Start is called before the first frame update
    void Start()
    {
        //daynight.GetComponent<DayNightChange>().DayChange(sunActived);
        kukat = GameObject.FindGameObjectsWithTag("KukkaPlatform");
        nightKukat = GameObject.FindGameObjectsWithTag("NightKukkaPlatform");
        sillat = GameObject.FindGameObjectsWithTag("SaniaisSilta");
        vines = GameObject.FindGameObjectsWithTag("Vine");
        peikko = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dayChanging == false)
        {
            dayChanged = true;
            dayChanging = true;
            StartCoroutine(WaitDayChange());
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
            }

            foreach (GameObject gameObject in nightKukat)
            {
                Debug.Log("nightkukka flowechange");
                gameObject.GetComponent<NightKukkaPlatformScript>().FlowerChange(sunActived);
            }

            foreach (GameObject gameObject in vines)
            {
                gameObject.GetComponent<VineScript>().VineActivation(sunActived);
            }

            foreach (GameObject gameObject in peikko)
            {
                gameObject.GetComponent<PeikkoScript>().PeikkoFreeze(sunActived);
            }

            daynight.GetComponent<DayNightChange>().DayChange(sunActived);
            dayChanged = false;
        }
    }

    IEnumerator WaitDayChange()
    {
        yield return new WaitForSeconds(1);
        dayChanging = false;
    }
}
