using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.XR;

[System.Serializable]
public class BowlingGameData
{
    public List<Vector3> leftControllerPositions;
    public List<Vector3> leftControllerVelocities;
    public List<Vector3> rightControllerPositions;
    public List<Vector3> rightControllerVelocities;
}

public class GameData : MonoBehaviour
{
    private BowlingGameData bowlingGameData;

    // Start is called before the first frame update
    void Start()
    {
        bowlingGameData = new BowlingGameData();
    }

    // Update is called once per frame
    void Update()
    {
        RecordControllerData(XRNode.LeftHand, bowlingGameData.leftControllerPositions, bowlingGameData.leftControllerVelocities);
        RecordControllerData(XRNode.RightHand, bowlingGameData.rightControllerPositions, bowlingGameData.rightControllerVelocities);
        
    }

    void RecordControllerData(XRNode controllerNode, List<Vector3> positions, List<Vector3> velocities)
    {
        InputDevices.GetDevicesAtXRNode(controllerNode, new List<InputDevice>());
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(controllerNode, devices);

        if (devices.Count > 0)
        {
            InputDevice device = devices[0];

            Vector3 position;
            if (device.TryGetFeatureValue(CommonUsages.devicePosition, out position))
            {
                positions.Add(position);
            }

            Vector3 velocity;
            if (device.TryGetFeatureValue(CommonUsages.deviceVelocity, out velocity))
            {
                velocities.Add(velocity);
            }
        }
    }

    void SaveDataToJson()
    {
        string username = PlayerPrefs.GetString("Username", "DefaultUsername"); // Retrieve the username from PlayerPrefs
        string json = JsonUtility.ToJson(bowlingGameData);
        File.WriteAllText($"Assets/Script_file/User_Data/{username}_bowlingData.json", json);
        Debug.Log("Bowling game data saved.");
    }

    // You might want to call this method when the game ends or when you want to save the recorded data.
    public void EndRecording()
    {
        SaveDataToJson();
    }
}