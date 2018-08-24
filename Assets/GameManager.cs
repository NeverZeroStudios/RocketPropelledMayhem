using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rocket_Propelled_Mayhem.Launcher;

namespace Rocket_Propelled_Mayhem
{
    public class GameManager : MonoBehaviour
    {

        public LauncherController launcher;
        public static GameManager singleton;
        public float baseUnitValue = 10;
        public float bonusUnitMultiplier = 1;
        private void Awake()
        {
            singleton = this;
        }
    }
}
