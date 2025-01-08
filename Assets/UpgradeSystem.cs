using System;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    private List<string> upgrades = new List<string>
    {
        "Increase Health",
        "Increase Damage",
        "Increase Speed",
        "Increase Defense",
        "Increase Stamina",
        "Increase Mana",
        "Critical Hit Boost",
        "Life Steal",
        "Faster Cooldowns",
        "Extra Gold from Enemies"
    };

    private System.Random random = new System.Random();

    public string[] GetRandomUpgrades()
    {
        if (upgrades.Count < 3)
        {
            Debug.LogError("Not enough upgrades to select from!");
            return null;
        }

        HashSet<int> selectedIndices = new HashSet<int>();
        while (selectedIndices.Count < 3)
        {
            int randomIndex = random.Next(upgrades.Count);
            selectedIndices.Add(randomIndex);
        }

        string[] selectedUpgrades = new string[3];
        int i = 0;
        foreach (int index in selectedIndices)
        {
            selectedUpgrades[i++] = upgrades[index];
        }

        Debug.Log($"Upgrades Selected: {string.Join(", ", selectedUpgrades)}");
        return selectedUpgrades;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            GetRandomUpgrades();
        }
    }
}

