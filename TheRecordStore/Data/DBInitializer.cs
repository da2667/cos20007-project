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
            new() { id=0,artist="Pink Floyd",album="The Wall",price=65.5,quantity=1,available=true }
            };

            foreach (Record r in records)
            {
                context.Records.Add(r);
            }
            context.SaveChanges();
        }
    }
}