using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Sound_Speed : MonoBehaviour
{
    public ToggleGroup toggleGroup;
    public float selectedSpeed = 1.0f;

    public void ToggleGroupSelection()
    {
        Toggle selectedToggle = toggleGroup.ActiveToggles().FirstOrDefault();

        if (selectedToggle != null)
        {
            switch (selectedToggle.name)
            {
                case "0.5":
                    selectedSpeed = 0.5f;
                    //Debug.Log(selectedSpeed);
                    break;

                case "0.75":
                    selectedSpeed = 0.75f;
                    //Debug.Log(selectedSpeed);
                    break;

                case "1.0":
                    selectedSpeed = 1.0f;
                    //Debug.Log(selectedSpeed);
                    break;

                default:
                    selectedSpeed = 1.0f; // 기본값은 1.0
                    break;
            }
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    
    public float GetSelectedSpeed()
    {
       return selectedSpeed;
    }
    
}
