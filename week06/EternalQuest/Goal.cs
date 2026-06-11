using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        // Encapsulation: private/protected fields
        protected string _shortName;
        protected string _description;
        protected int _points;

        // Constructor
        public Goal(string name, string description, int points)
        {
            _shortName = name;
            _description = description;
            _points = points;
        }

        // Polymorphism: abstract methods to override
        public abstract int RecordEvent();
        public abstract bool IsComplete();
        public abstract string GetStringRepresentation();

        // Shared behavior (Inheritance of methods)
        public virtual string GetDetailsString()
        {
            string checkbox = IsComplete() ? "[X]" : "[ ]";
            return $"{checkbox} {_shortName} ({_description})";
        }

        public int GetPoints()
        {
            return _points;
        }
    }
}
