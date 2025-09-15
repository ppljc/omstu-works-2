using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1
            Animal blankAnimal = new Animal();
            Animal cat = new Animal("Busyinka", 52, 5, AnimalType.Predator, Habitat.Land, Continent.Eurasia);

            Console.WriteLine($"First animal name: {blankAnimal.Name}.\n");
            Console.WriteLine($"Second animal name: {cat.Name}.\n");

            Console.WriteLine($"Is animals equals? {cat == blankAnimal}.\n");

            cat.Age = 42; // помолодел

            Console.WriteLine($"Can first animal fly? {blankAnimal.CanFly()}.\n");

            Console.WriteLine($"Does second animal have tail? {cat.ExistsTail()}.\n");

            // 2
            Figure circuit = new Figure(10);
            Figure square = new Figure(20, 20, false);
            Figure triangle = new Figure(10, 20, true);

            Console.WriteLine($"Circuit square: {circuit.Square}; square square: {square.Square}; triangle square: {triangle.Square}.\n");

            Console.ReadLine();
        }
    }
}
