using System;
using System.Collections.Generic;
using System.IO;

namespace GRLib
{
    public class Parser
    {
        public Record LoadRow(string raw)
        {
            var cells = raw.Split(new char[] { '|', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            DateTime dob;
            DateTime.TryParse(TryGetValueAt(4, cells), out dob);

            var result = new Record()
            {
                LastName = TryGetValueAt(0, cells),
                FirstName = TryGetValueAt(1, cells),
                Gender = TryGetValueAt(2, cells),
                FavouriteColor = TryGetValueAt(3, cells),
                DOB = dob
            };

            return result;
        }

        public IEnumerable<Record> LoadFile(string fileName)
        {
            using (var reader = new StreamReader(new FileStream(fileName, FileMode.Open)))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                    yield return LoadRow(line);
            }
        }

        private T TryGetValueAt<T>(int index, T[] array)
        {
            return array.Length > index ? array[index] : default(T);
        }
    }
}
