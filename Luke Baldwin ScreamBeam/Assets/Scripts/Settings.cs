﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{


 public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }


          }

        
   
