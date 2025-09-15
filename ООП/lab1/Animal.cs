using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Animal
    {
        private string name;
        private int age;
        private int limbs;
        private AnimalType type;
        private Habitat habitat;
        private Continent continent;

        public Animal()
        {
            this.name = "Nameless";
            this.age = 0;
            this.limbs = 0;
            this.type = AnimalType.Predator;
            this.habitat = Habitat.Land;
            this.continent = Continent.Eurasia;
        }

        public Animal(string name, int age, int limbs, AnimalType type, Habitat habitat, Continent continent)
        {
            this.name = name;
            this.age = age;
            this.limbs = limbs;
            this.type = type;
            this.habitat = habitat;
            this.continent = continent;
        }

        public static bool operator ==(Animal a1, Animal a2)
        {
            if (ReferenceEquals(a1, null) && ReferenceEquals(a2, null))
                return true;
            if (ReferenceEquals(a1, null) || ReferenceEquals(a2, null))
                return false;
            return (a1.age == a2.age) && (a1.limbs == a2.limbs) && (a1.type == a2.type);
        }

        public static bool operator !=(Animal a1, Animal a2)
        {
            return !(a1 == a2);
        }

        public string GetSound()
        {
            return $"{name} pronounce sound!";
        }

        public bool CanFly()
        {
            return habitat == Habitat.Air;
        }

        public bool CanSwim()
        {
            return habitat == Habitat.Water;
        }

        public bool ExistsTail()
        {
            return habitat == Habitat.Land && limbs > 0;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public int Age
        {
            set
            {
                age = value;
            }
        }
    }
}
