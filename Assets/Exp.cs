using System;
using UnityEngine;

public class CharacterLevelSystem : MonoBehaviour
{
    public int Level { get; private set; } = 1;
    public int Experience { get; private set; } = 0;
    public int ExperienceToNextLevel { get; private set; } = 100;

    private System.Random random = new System.Random();

    [SerializeField] private UpgradeSystem upgradeSystem;

    void Start()
    {

    }

    
    public void AddExperience(int amount)
    {
        if (amount <= 0)
        {
            Debug.LogWarning("Tylko nieujemne.");
            return;
        }

        Experience += amount;
        Debug.Log($"Zdoby³eœ {amount} EXP. Twój EXP: {Experience}/{ExperienceToNextLevel}");
        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        while (Experience >= ExperienceToNextLevel)
        {
            Experience -= ExperienceToNextLevel;
            Level++;
            ExperienceToNextLevel = CalculateExperienceToNextLevel(Level);

            Debug.Log($"Nowy poziom: {Level}");

            PickRandomNumbers();
        }
    }

    private int CalculateExperienceToNextLevel(int level)
    {
        return 100 + (level - 1) * 50; 
    }

    private void PickRandomNumbers()
    {
        int num1 = random.Next(1, 11);
        int num2 = random.Next(1, 11);
        int num3 = random.Next(1, 11);

        string randomNumbers = $"{num1}, {num2}, {num3}";
        Debug.Log($"Ulepszenia do wyboru: {randomNumbers}");

        if (upgradeSystem != null)
        {
            string[] selectedUpgrades = upgradeSystem.GetRandomUpgrades();
            if (selectedUpgrades != null)
            {
                Debug.Log($"Choose an Upgrade: {string.Join(", ", selectedUpgrades)}");
            }
        }
        else
        {
            Debug.LogWarning("UpgradeSystem is not assigned!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            AddExperience(50);
        }
    }
}

