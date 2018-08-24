using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rocket_Propelled_Mayhem.Launcher;

namespace Rocket_Propelled_Mayhem
{
    public class FollowProjectile : MonoBehaviour
    {
        public Transform target;
        public Vector3 offsets;

        public float followSpeed = 8;
        public float damp = 0.1f;
        private void FixedUpdate()
        {

            if(target != null && target.tag == "Projectile")
            {
                offsets = new Vector3(0,6,-15);
                transform.position = Vector3.Lerp(transform.position, target.transform.position + offsets, followSpeed * damp);
            }
            else if(target != null && target.tag != "Projectile")
            {

                transform.position = Vector3.Lerp(transform.position, target.transform.position + offsets, followSpeed * damp);
                offsets = new Vector3(8, 6, -15);
            }
        }
    }
}
