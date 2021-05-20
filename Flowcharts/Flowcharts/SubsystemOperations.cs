using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    public static class SubsystemOperations
    {
        public static List<Subsystem> IdentifySubsystems(Element[,] ElementArray)
        {
            return new IdentifiedSubsystems(ElementArray).IdentifySubsystems();
        }

        public static List<Subsystem> ColorSubsystems(List<Subsystem> subsystems)
        {
            return new ColoredSubsystems(subsystems).Subsystems;
        }

        public static (double xPos, double yPos) GetSubsystemTextPosition(Element[,] ElementArray, Subsystem subsystem)
        {
            return new SubsystemPosition(ElementArray, subsystem).GetCoordinates().TextPosition;
        }

        public static string GetSubsystemPosition(Element[,] ElementArray, Subsystem subsystem)
        {
            return new SubsystemPosition(ElementArray, subsystem).GetCoordinates().Coordinates;
        }

        public static bool DrawSubsystem (Subsystem subsystem, Element[,] ElementArray) 
        {
            new DrawnSubsystem(subsystem, ElementArray).Draw();
            return true;
        }
    }
}
