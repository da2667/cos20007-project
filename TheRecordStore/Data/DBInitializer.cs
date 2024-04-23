using TheRecordStore.Models;
using System;
using System.Diagnostics;
using System.Linq;

namespace TheRecordStore.Data
{
    public static class DbInitializer
    {
        public static void Initialize(RecordStoreContext context)
        {
            context.Database.EnsureCreated();

            if (context.Records.Any())
            {
                return;
            }

            
            List<Record> records = new List<Record>()
            {
            new Record { Artist="Pink Floyd",Album="The Wall",Price=65.5,Stock=3 },
            new Record { Artist="Pink Floyd",Album="Dark Side of the Moon",Price=60,Stock=4 },
            new Record { Artist="Pixies",Album="Trompe Le Monde",Price=47.9,Stock=3 },
            new Record { Artist="The Beatles",Album="Sgt Peppers Lonely Hearts Club Band",Price=66.5,Stock=2 },
            new Record { Artist="Oasis",Album="Definetly Maybe",Price=72.5,Stock=1 },
            new Record { Artist="Nirvana",Album="In Utero",Price=71.5,Stock=9 }
            };

            foreach (Record r in records)
            {
                context.Records.Add(r);
            }

            context.SaveChanges();
        }
    }
}