using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class ResolutionManager : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;

    private List<Resolution> resolutions = new List<Resolution>
    {
        new Resolution { width = 1920, height = 1080 },
        new Resolution { width = 1280, height = 720 },
        new Resolution { width = 4096, height = 2160 },

    };

    void Start()
    {
        FillDropdown();
        resolutionDropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    void FillDropdown()
    {
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        foreach (var resolution in resolutions)
        {
            options.Add($"{resolution.width}x{resolution.height}");
        }

        resolutionDropdown.AddOptions(options);
    }

    void OnDropdownValueChanged(int index)
    {
        // Obtiene la resolución seleccionada del Dropdown
        Resolution selectedResolution = resolutions[index];

        // Establece la resolución con la tasa de actualización actual
        if(index == 1)
        {
            Screen.SetResolution(selectedResolution.width, selectedResolution.height, FullScreenMode.Windowed, new RefreshRate());
        }
        else
        {
            Screen.SetResolution(selectedResolution.width, selectedResolution.height, false);
        }
        
        //Screen.SetResolution(selectedResolution.width, selectedResolution.height, FullScreenMode.Windowed, new RefreshRate());

        Debug.Log($"Resolución cambiada a {selectedResolution.width}x{selectedResolution.height} correctamente.");
    }
}
