using System;
using HomeWork3._1.Collection;
using HomeWork3._1.Collection.Abstractions;

namespace HomeWork3._1
{
	public class Startup
	{
        private readonly IPersonalisedCollection<string> _personalisedCollection = new PersonalisedCollection<string>();


        public void  Start()
		{
            PersonalisedCollection<string> personalisedCollection = new PersonalisedCollection<string>();

            personalisedCollection.Add("Lily");
            personalisedCollection.Add("Rose");
            personalisedCollection.Add("Tulip");
            personalisedCollection.Add("Daisy");
            personalisedCollection.Add("Dandelion");
            personalisedCollection.Add("Clover");


            personalisedCollection.Sort();

            Console.WriteLine("\nAfter sorting:");
            foreach (var item in personalisedCollection)
            {
                Console.WriteLine(item);
            }

            personalisedCollection.SetDefaultAt(2);

            Console.WriteLine("\nAfter deleting at index 2:");
            foreach (var item in personalisedCollection)
            {
                Console.WriteLine(item);
            }
        }
	}
}

