using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Show a table of every item, both before and after changes to make sure changes work as expected
            Console.WriteLine(String.Format("{0,-15} {1,11} {2,4}", "Name",  "Quality", "SelIn"));
            foreach (var item in Items)
            {
                Console.WriteLine(String.Format("{0,-22} {1,-0} {2,3}", item.Name, item.Quality, item.SellIn));
            }
            UpdateQuality();
            foreach (var item in Items)
            {
                Console.WriteLine(String.Format("{0,-22} {1,-1} {2,3}", item.Name, item.Quality, item.SellIn));
            }

        }
        // Items can be static; there is only one inventory list
        static IList<Item> Items = new List<Item>
    {
        new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
        new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
        new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
        new Item { Name = "Sulfuras", SellIn = 0, Quality = 80 },
        new Item { Name = "Backstage passes", SellIn = 15, Quality = 20 },
        new Item { Name = "Conjured", SellIn = 3, Quality = 6 }
    };
        // Only change was adding "Conjured" to lose Qualtity twice as fast, both before and after the SellIn date =0 
        public static void UpdateQuality()
        {

            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage Passes")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "Sulfuras")
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                        if (Items[i].Name == "Conjured")
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;
                        if (Items[i].Name == " Backstage Passes")
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }
                if (Items[i].Name != "Sulfuras")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }
                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        if (Items[i].Name != "Backstage passes")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "Sulfuras")
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                                if (Items[i].Name == "Conjured")
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }
    }
}
