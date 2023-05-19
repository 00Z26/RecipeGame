using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "OpenDoorTimes", menuName = "SO_Door")]
public class OpenDoorTimes : ScriptableObject
{
    [SerializeField]
    public List<string> doors;
    public List<int> openTimes;
    
    public int GetDoorTimes(string doorName)
    {
        return openTimes[GetDoorIndex(doorName)];
    }
    public void SetDoorTimes(string doorName)
    {
        openTimes[GetDoorIndex(doorName)] = openTimes[GetDoorIndex(doorName)] + 1;
    }

    public int GetDoorIndex(string doorName)
    {
        return doors.IndexOf(doorName);
    }


}