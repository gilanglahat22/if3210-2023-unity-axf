using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SlotNameData
{
    public string slot1Name;
    public string slot2Name;
    public string slot3Name;
    public SlotNameData(){
        this.slot1Name = "UNKNOWN";
        this.slot2Name = "UNKNOWN";
        this.slot3Name = "UNKNOWN";
    }
}