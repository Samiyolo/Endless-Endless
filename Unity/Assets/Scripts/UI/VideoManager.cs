using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.UI;

public class VideoManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown VOptions;
    [SerializeField] private TMP_Dropdown ROptions;
    [SerializeField] private Button ApplyB;
    [SerializeField] private TMP_Dropdown DOptions;

    Resolution[] res;

    void Start()
    {
        ApplyB.onClick.AddListener(ApplyOptions);

        DOptions.onValueChanged.AddListener(delegate { GetRes(); });

        /*List<string> options = new List<string>();
        //res = Screen.resolutions;
        //int currentresi = 0;

        //ROptions.ClearOptions();
        //for (int i = 0; i < res.Length; i++)
        //{
        //    string option = res[i].width + " x " + res[i].height;
        //    options.Add(option);
        //    if (res[i].width == Screen.width && res[i].height == Screen.height)
        //    {
        //        currentresi = i;
        //    }
        //}

        //ROptions.AddOptions(options);
        //ROptions.value = currentresi;
        //ROptions.RefreshShownValue();//credit to https://answers.unity.com/questions/1680457/how-to-change-resolution-in-dropdown.html*/

        GetRes();

        List<string> disop = new List<string>();

        for (int i = 0; i < Display.displays.Length; i++)
        {
            disop.Add("Display " + i);
        }

        DOptions.ClearOptions();
        DOptions.AddOptions(disop);
        DOptions.RefreshShownValue();
    }

    void GetRes()
    {
        List<string> options = new List<string>();
        res = Screen.resolutions;
        int currentresi = 0;

        ROptions.ClearOptions();
        for (int i = 0; i < res.Length; i++)
        {
            string option = res[i].width + " x " + res[i].height;
            options.Add(option);
            if (res[i].width == Screen.width && res[i].height == Screen.height)
            {
                currentresi = i;
            }
        }

        ROptions.AddOptions(options);
        ROptions.value = currentresi;
        ROptions.RefreshShownValue();//credit to https://answers.unity.com/questions/1680457/how-to-change-resolution-in-dropdown.html
    }
    //to do: update res dropdown when changing full drop, remove disp drop...
    void SetResolution(int resolutionIndex)
    {
        Camera car = FindObjectOfType<Camera>();
        car.targetDisplay = DOptions.value;

        Resolution resolution = res[resolutionIndex]; Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode);

        switch (VOptions.value)//0= excl full 1= windowed 2= windowed full
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                break;

            case 1:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;

            case 2:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                break;

            default:
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                break;
        }
    }

    void ApplyOptions()
    {
        SetResolution(ROptions.value);
    }
}