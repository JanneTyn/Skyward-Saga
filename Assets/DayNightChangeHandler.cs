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
    // Start is called before the first frame update
    void Start()
    {
        //daynight.GetComponent<DayNightChange>().DayChange(sunActived);
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
            //daynight.DayChange(sunActived);
            daynight.GetComponent<DayNightChange>().DayChange(sunActived);
            kukkaplatform.FlowerChange(sunActived);
            saniaissilta.BridgeChange(sunActived);
            dayChanged = false;
        }
    }
}
