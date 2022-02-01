using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 4.0f))
            {
                if (hit.transform != null)
                {
                    IClicked click = hit.transform.gameObject.GetComponent<IClicked>();
                    if(click != null)
                    {
                        click.OnClickAction();
                    }

                }
            }
        }
    }

}
