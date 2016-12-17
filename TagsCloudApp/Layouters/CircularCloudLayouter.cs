using System;
using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudApp.Layouters
{
    public class CircularCloudLayouter : IRectangleLayouter
    {
        public Point Center { get; set; }

        private readonly Random random;

        private int radiusSetting;

        private const int StepRadiusSetting = 5;

        private const double StepDeflectionAngle = Math.PI / 36;

        private readonly List<Rectangle> existingRectangles;

        public CircularCloudLayouter()
        {
            random = new Random();
            existingRectangles = new List<Rectangle>();
            Center = new Point();
        }

        public void Clear()
        {
            existingRectangles.Clear();
        }

        public Rectangle PutNextRectangle(Size rectangleSize)
        {
            var deflectionAngle = 2 * Math.PI * random.NextDouble();
            while (true)
            {
                while (deflectionAngle > 0)
                {
                    var x = Center.X + (int)(radiusSetting * Math.Cos(deflectionAngle)) - rectangleSize.Width / 2;
                    var y = Center.Y + (int)(radiusSetting * Math.Sin(deflectionAngle)) - rectangleSize.Height / 2;
                    var newRectangle = new Rectangle(new Point(x, y), rectangleSize);
                    if (!newRectangle.IntersectsWith(existingRectangles))
                    {
                        var resultRectangle = ShiftToCenter(newRectangle);
                        existingRectangles.Add(resultRectangle);
                        return resultRectangle;
                    }
                    deflectionAngle -= StepDeflectionAngle;
                }
                deflectionAngle = 2 * Math.PI * random.NextDouble();
                radiusSetting += StepRadiusSetting;
            }
        }



        private bool TryShiftToDirection(int directionX, int directionY, Rectangle rectangle, out Rectangle resultRectangle)
        {
            var newLocation = new Point(rectangle.X + directionX, rectangle.Y + directionY);
            resultRectangle = new Rectangle(newLocation, rectangle.Size);
            return !resultRectangle.IntersectsWith(existingRectangles);
        }

        private Rectangle ShiftToCenter(Rectangle rectangle)
        {
            var currentRectangle = rectangle;
            var rectengleCenter = new Point(rectangle.X + rectangle.Width / 2, rectangle.Y + rectangle.Height / 2);
            var directionX = Math.Sign(Center.X - rectengleCenter.X);
            var directionY = Math.Sign(Center.Y - rectengleCenter.Y);
            while (directionY != 0 || directionX != 0)
            {
                Rectangle newRectangle;
                if (directionY != 0 && TryShiftToDirection(0, directionY, currentRectangle, out newRectangle))
                {
                    currentRectangle = newRectangle;
                }
                else
                {
                    if (directionX != 0 && TryShiftToDirection(directionX, 0, currentRectangle, out newRectangle))
                    {
                        currentRectangle = newRectangle;
                    }
                    else
                    {
                        break;
                    }
                }
                rectengleCenter = new Point(
                    currentRectangle.X + currentRectangle.Width / 2,
                    currentRectangle.Y + currentRectangle.Height / 2);
                directionY = Math.Sign(Center.Y - rectengleCenter.Y);
                directionX = Math.Sign(Center.X - rectengleCenter.X);
            }
            return currentRectangle;
        }
    }
}
