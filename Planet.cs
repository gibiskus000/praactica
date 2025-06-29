using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PlanetSimulation
{
    public class CelestialBody
    {
        public string Name { get; init; }
        public double Mass { get; init; }
        public double PositionX { get; private set; }
        public double PositionY { get; private set; }
        public double VelocityX { get; private set; }
        public double VelocityY { get; private set; }
        public Color BodyColor { get; init; }
        public int Radius { get; init; }
        public List<PointF> MovementHistory { get; } = new List<PointF>();

        private double _netForceX;
        private double _netForceY;

        public CelestialBody(string name, double mass, double x, double y,
                            double velocityX, double velocityY, Color color, int radius)
        {
            Name = name;
            Mass = mass;
            PositionX = x;
            PositionY = y;
            VelocityX = velocityX;
            VelocityY = velocityY;
            BodyColor = color;
            Radius = radius;
        }

        public void ComputeGravitationalForce(CelestialBody otherBody, double gravitationalConstant)
        {
            var deltaX = otherBody.PositionX - PositionX;
            var deltaY = otherBody.PositionY - PositionY;

            var distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            distance = Math.Max(distance, 0.1); // Минимальное расстояние для избежания деления на ноль

            var force = (gravitationalConstant * Mass * otherBody.Mass)
                      / (distance * distance);

            _netForceX += force * deltaX / distance;
            _netForceY += force * deltaY / distance;
        }

        public void UpdateState(double timeStep)
        {
            var accelerationX = _netForceX / Mass;
            var accelerationY = _netForceY / Mass;

            VelocityX += accelerationX * timeStep;
            VelocityY += accelerationY * timeStep;

            PositionX += VelocityX * timeStep;
            PositionY += VelocityY * timeStep;

            MovementHistory.Add(new PointF((float)PositionX, (float)PositionY));

            ResetForces();
        }

        private void ResetForces()
        {
            _netForceX = 0;
            _netForceY = 0;
        }

        public void ClearMovementHistory()
        {
            MovementHistory.Clear();
        }
    }
}