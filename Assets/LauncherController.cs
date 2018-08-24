using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket_Propelled_Mayhem.Launcher
{
    public class LauncherController : MonoBehaviour
    {
        public float rotateSpeed;
        public float angle;
        public float power;
        public Transform pivot;
        public Transform launchPoint;
        public Projectile objToLaunch;
        public FollowProjectile _camera;
        private void Update()
        {
            HandleRotations();
            power = FindObjectOfType<UIManager>().powerSlider.value;
        }
        public void Launch()
        {
                Instantiate(objToLaunch);
                objToLaunch.transform.position = launchPoint.position;
            
            
        }
     
        void HandleRotations()
        {
            float x = Input.GetAxis("Vertical");

            if (x == 1)
            {
                angle += rotateSpeed * Time.deltaTime;
            }
            else if (x == -1)
            {
                angle -= rotateSpeed * Time.deltaTime;
            }

            angle = Mathf.Clamp(angle, 0, 90);

            pivot.transform.localEulerAngles = new Vector3(0, 0, angle);
        }
    }
}
