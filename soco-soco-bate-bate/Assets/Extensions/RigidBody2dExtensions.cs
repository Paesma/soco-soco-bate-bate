using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions
{
    public static class RigidBody2dExtensions
    {
        public static void AddVelocity(this Rigidbody2D rb, Vector2 vector2)
        {
            var currentVelocity = rb.velocity;

            currentVelocity = currentVelocity + vector2;

            rb.velocity = currentVelocity;
        }
    }
}
