using System;
using System.Collections.Generic;

namespace FridayWorkshop2
{
    class Program
    {

        static void Main()
        {
            //Person person = new Person("duncan", 22, 9000);
            //Console.WriteLine(person.age);

            Person player = new Person();
            Person shopkeeper = new Person();
            Item sword = new Item();

            sword.value = 5;

            shopkeeper.money = 5000;
            player.money = 1000;

            shopkeeper.inventory.Add(sword);

            player.inventory.Add(shopkeeper.inventory[0]);
            player.money += shopkeeper.inventory[0].value;

            Console.WriteLine(player.money);

        }
    }

    class Person
    {
        public string name;
        public int age;
        public int money;
        public List<Item> inventory = new List<Item>();


        //public Person(string n, int a, int m)
        //{
        //    name = n;
        //    age = a;
        //    money = m;
        //}


    }

    class Item
    {
        public string name;
        public int value;

    }
}
