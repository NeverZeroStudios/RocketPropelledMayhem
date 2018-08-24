using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket_Propelled_Mayhem.Launcher
{
    public class Projectile : MonoBehaviour
    {

        Rigidbody rigi;
        public int distTraveled;
        public bool onGround;
        bool OnGround()
        {
            Vector3 origin = transform.position;
            Vector3 dir =  -transform.up;
            float dis = 1;
            RaycastHit hit;
            Debug.DrawRay(origin, dir, Color.red);
            if(Physics.Raycast(origin, dir, out hit, dis))
            {
                return true;
            }
            return false;
        }
        public void OnEnable()
        {
            rigi = GetComponent<Rigidbody>();

            LauncherController l = FindObjectOfType<LauncherController>();
            rigi.AddForce(l.launchPoint.forward * l.power * 10, ForceMode.Impulse);

            FollowProjectile p = l._camera;
            p.target = this.transform;
        }

        private void Update()
        {
            onGround = OnGround();
            if (!onGround)
            {
                distTraveled += Mathf.RoundToInt(((GameManager.singleton.baseUnitValue * GameManager.singleton.bonusUnitMultiplier) * Time.deltaTime)* 10);
            }
        }
    }
}
