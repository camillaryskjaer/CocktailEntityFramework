using CocktailEntityFramework.interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailEntityFramework.classes
{
    class IngredientContext : DbContext
    {

        public IngredientContext() : base()
        {
        }

        public DbSet<Mixer> Mixer { get; set; }
       
        public DbSet<Liqour> Liqour { get; set; }

        public DbSet<Accessory> Accessory { get; set; }

        public DbSet<IngredientBase> IngredientBase { get; set; }



        public bool AddMixer(Mixer mixerToAdd)
        {
            try
            {
                Mixer.Add(mixerToAdd);
                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
            //Hvad laver den herinde......
                Console.WriteLine(e.Message);
                return false;

            }
        }

        public bool AddIngridientBase(IngredientBase basei)
        {
            try
            {
                IngredientBase.Add(basei);
                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;

            }
        }

        public List<IIngredient> LoadEverything()
        {
            List<IIngredient> ingredients = new List<IIngredient>();
            ingredients.AddRange(LoadMixers());
            ingredients.AddRange(LoadAlcoholics());
            ingredients.AddRange(LoadAccessories());
            return ingredients;
        }

        public List<IIngredient> LoadMixers()
        {
            var mixer = Mixer.Where(s => s.IngredientID != -1);
            List<IIngredient> list = mixer.ToList<IIngredient>();
            return list;
        }

        public List<IIngredient> LoadAlcoholics()
        {
            var liquour = Liqour.Where(s => s.IngredientID != -1);
            List<IIngredient> list = liquour.ToList<IIngredient>();
            return list;
        }
        public List<IIngredient> LoadAccessories()
        {
            var accessory = Accessory.Where(s => s.IngredientID != -1);
            List<IIngredient> list = accessory.ToList<IIngredient>();
            return list;
        }


    }

}
