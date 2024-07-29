using MelonLoader;
using UnityEngine;

namespace Hazelnut272.QualitySettings
{
    public class Main : MelonMod
    {
        public MelonPreferences_Category Preferences;
        public MelonPreferences_Entry<bool> DisableGrass;


        public override void OnInitializeMelon()
        {
            base.OnInitializeMelon();

            LoggerInstance.Msg("QualitySettings mod enabled.");
            Preferences = MelonPreferences.CreateCategory("Preferences");
            Preferences.SetFilePath("UserData/QualitySettings.cfg");
            DisableGrass = Preferences.CreateEntry<bool>("DisableGrass", false, "Disable Grass", "Disables rendering of grass objects");

            LoggerInstance.Msg($"Grass Disabled: {DisableGrass.Value}");
            Preferences.SaveToFile();
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            base.OnSceneWasLoaded(buildIndex, sceneName);
            if(buildIndex == 0)
            {
                if (DisableGrass.Value)
                {
                    DestroyGrass();
                }
            }
        }

        private void DestroyGrass()
        {
            GameObject grass = GameObject.Find("GameManager/LevelManager/Level/Grass");
            GameObject.Destroy(grass);
        }
    }
}