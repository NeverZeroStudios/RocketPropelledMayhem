using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rocket_Propelled_Mayhem.Launcher;

namespace Rocket_Propelled_Mayhem
{
    public class UIManager : MonoBehaviour
    {

        public Text angleText;
        public Text distText;
        public Slider powerSlider;
        public float sliderCurveMultiplier;
        bool power;
        bool fire;
        bool powerFull;
        void Update()
        {
            angleText.text = GameManager.singleton.launcher.angle.ToString();

            Projectile p = FindObjectOfType<Projectile>();

            if(p != null)
            {
                distText.text = p.distTraveled.ToString() + "-Units";
            }

            HandlePowerBar();
        }
        bool hasFired;
        void HandlePowerBar()
        {


            power = Input.GetKey(KeyCode.Space);
            fire = Input.GetKeyUp(KeyCode.Space);
           
            if (fire)
            {
                Fire();
                hasFired = true;
                
            }
            if (hasFired)
            {
                powerSlider.value = Mathf.Lerp(powerSlider.value, powerSlider.minValue, 0.5f);
                if (powerSlider.value == powerSlider.minValue)
                    hasFired = false;
            }
            if (power && !powerFull)
            {


                if (powerSlider.value < powerSlider.maxValue)
                {
                    powerSlider.value += sliderCurveMultiplier * Time.deltaTime;

                }
                else if (powerSlider.value == powerSlider.maxValue)
                {
                    powerFull = true;
                }

            }
            else if(power && powerFull)
            {
                if (powerSlider.value > powerSlider.minValue)
                {
                    powerSlider.value -= sliderCurveMultiplier * Time.deltaTime;

                }
                else if (powerSlider.value == powerSlider.minValue)
                {
                    powerFull = false;
                }
            }

           
        }

        void Fire()
        {
            if (powerFull)
                powerFull = false;
           


            GameManager.singleton.launcher.Launch();
        }

       

    }
}
