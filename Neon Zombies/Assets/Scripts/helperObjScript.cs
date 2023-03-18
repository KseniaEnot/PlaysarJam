using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helperObjScript : MonoBehaviour
{
    [SerializeField]
    float bufSize;
    [SerializeField]
    GameObject UIObj;
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        //dialog place;
        UIObj.GetComponent<GameCountdown>().currentTimer += bufSize;
        this.gameObject.SetActive(false);
    }
}
