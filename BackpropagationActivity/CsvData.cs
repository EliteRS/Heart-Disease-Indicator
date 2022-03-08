using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace BackpropagationActivity
{
    enum Genders
    {
        Male,
        Female,
    }

    class CsvData
    {
        public List<HeartDisease> getRecords()
        {
            using (var reader = new StreamReader("C:\\Users\\Russell\\OneDrive\\Desktop\\Backpropagation\\BackpropagationActivity\\heartdisease.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {

               //List<Diabetes> records = csv.GetRecords<Diabetes>().ToList();

                csv.Context.RegisterClassMap<HeartDiseaseDataClassMap>();
                var records = csv.GetRecords<HeartDisease>().ToList();

                return records;
            }
        }
        public int ParseGender(String g)
        {
            Genders result;
            if (Enum.TryParse(g, out result))
            {
                switch (result)
                {
                    case Genders.Male:
                        return 1;
                }
            }
            return 0;
        }
    }

    public class HeartDiseaseDataClassMap : ClassMap<HeartDisease>
    {
        public HeartDiseaseDataClassMap()
        {

            Map(m => m.Highbp).Name("highbp");
            Map(m => m.Highcol).Name("highcol");
            Map(m => m.Colcheck).Name("colcheck");
            Map(m => m.Bmi).Name("bmi");
            Map(m => m.Smoker).Name("smoker");
            Map(m => m.Stroke).Name("stroke");
            Map(m => m.Diabetes).Name("diabetes");
            Map(m => m.PhysActivity).Name("physactivity");
            Map(m => m.Fruits).Name("fruits");
            Map(m => m.Heart_Disease).Name("heart_disease");
        }
    }



    public class HeartDisease
    {

        [Name("highbp")]
        public double Highbp { get; set; }

        [Name("highcol")]
        public double Highcol { get; set; }

        [Name("colcheck")]
        public double Colcheck { get; set; }

        [Name("bmi")]
        public int Bmi { get; set; }

        [Name("smoker")]
        public int Smoker { get; set; }

        [Name("stroke")]
        public int Stroke { get; set; }

        [Name("diabetes")]
        public int Diabetes { get; set; }

        [Name("physactivity")]
        public int PhysActivity { get; set; }

        [Name("fruits")]
        public int Fruits { get; set; }

        [Name("heart_disease")]
        public int Heart_Disease { get; set; }



    }

}
