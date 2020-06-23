using System;
using System.Collections.Generic;
using System.Windows;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using DietApplication.Properties;

/*
 * https://www.ars.usda.gov/northeast-area/beltsville-md-bhnrc/beltsville-human-nutrition-research-center/nutrient-data-laboratory/docs/sr28-download-files/
*/

namespace DietApplication
{
    // The class that encapsulates everything related to USDA data
    // USDA National Nutrient Database for Standard Reference (SR)27 May 2015 Revision
    public static class USDA
    {
        #region Properties

        // References to USDA data tables, some of which may conditionally be null on purpose
        // The NUT_DATA, WEIGHT, and NUTR_DEF, and FD_GROUP tables are always needed and cannot be null
        private static DataTable DATA_SRC = null;
        private static DataTable DATSRCLN = null;
        private static DataTable DERIV_CD = null;
        private static DataTable FD_GROUP = null;
        private static DataTable FOOD_DES = null;
        private static DataTable FOOTNOTE = null;
        private static DataTable LANGDESC = null;
        private static DataTable LANGUAL = null;
        private static DataTable NUT_DATA = null;
        private static DataTable NUTR_DEF = null;
        private static DataTable SRC_CD = null;
        private static DataTable WEIGHT = null;

        // Constants that map columns headers in the NUT_DATA table
        // This has been validated against NUTR_DEF and excludes the individual measurements of fatty-acid chains
        private const string Protein = "203";
        private const string TotalLipids = "204";
        private const string Carbohydrates = "205";
        private const string Ash = "207";
        private const string EnergyKCal = "208";
        private const string Starch = "209";
        private const string Sucrose = "210";
        private const string Glucose = "211";
        private const string Fructose = "212";
        private const string Lactose = "213";
        private const string Maltose = "214";
        private const string Alcohol = "221";
        private const string Water = "255";
        private const string AdjustedProtein = "257";
        private const string Caffeine = "262";
        private const string Theobromine = "263";
        private const string EnergyKJ = "268";
        private const string TotalSugars = "269";
        private const string Galactose = "287";
        private const string TotalFiber = "291";
        private const string Calcium = "301";
        private const string Iron = "303";
        private const string Magnesium = "304";
        private const string Phosphorus = "305";
        private const string Potassium = "306";
        private const string Sodium = "307";
        private const string Zinc = "309";
        private const string Copper = "312";
        private const string Fluoride = "313";
        private const string Manganese = "315";
        private const string Selenium = "317";
        private const string VitaminAIU = "318";
        private const string Retinol = "319";
        private const string VitaminARAE = "320";
        private const string BetaCarotene = "321";
        private const string AlphaCarotene = "322";
        private const string VitaminE = "323";
        private const string VitaminD = "324";
        private const string VitaminD2 = "325";
        private const string VitaminD3 = "326";
        private const string Cryptoxanthin = "334";
        private const string Lycopene = "337";
        private const string LuteinPlusZeaxanthin = "338";
        private const string BetaTocopherol = "341";
        private const string GammaTocopherol = "342";
        private const string DeltaTocopherol = "343";
        private const string AlphaTocotrienol = "344";
        private const string BetaTocotrienol = "345";
        private const string GammaTocotrienol = "346";
        private const string DeltaTocotrienol = "347";
        private const string VitaminC = "401";
        private const string Thiamin = "404";
        private const string Riboflavin = "405";
        private const string Niacin = "406";
        private const string PantothenicAcid = "410";
        private const string VitaminB6 = "415";
        private const string FolateTotal = "417";
        private const string VitaminB12 = "418";
        private const string Choline = "421";
        private const string Menaquinone4 = "428";
        private const string Dihydrophylloquinone = "429";
        private const string VitaminK = "430";
        private const string FolicAcid = "431";
        private const string FolateFood = "432";
        private const string FolateDFE = "435";
        private const string Betaine = "454";
        private const string Tryptophan = "501";
        private const string Threonine = "502";
        private const string Isoleucine = "503";
        private const string Leucine = "504";
        private const string Lysine = "505";
        private const string Methionine = "506";
        private const string Cystine = "507";
        private const string Phenylalanine = "508";
        private const string Tyrosine = "509";
        private const string Valine = "510";
        private const string Arginine = "511";
        private const string Histidine = "512";
        private const string Alanine = "513";
        private const string AsparticAcid = "514";
        private const string GlutamicAcid = "515";
        private const string Glycine = "516";
        private const string Proline = "517";
        private const string Serine = "518";
        private const string Hydroxyproline = "521";
        private const string VitaminEAdded = "573";
        private const string VitaminB12Added = "578";
        private const string Cholesterol = "601";
        private const string FattyAcidsTrans = "605";
        private const string FattyAcidsSaturated = "606";
        private const string Phytosterols = "636";
        private const string Stigmasterol = "638";
        private const string Campesterol = "639";
        private const string BetaSitosterol = "641";
        private const string FattyAcidsMonounsaturated = "645";
        private const string FattyAcidsPolyunsaturated = "646";
        private const string FattyAcidsTransMonoenoic = "693";
        private const string FattyAcidsTransPolyenoic = "695";
        private const string AlphaLinolenicAcid = "851";
        private const string LinoleicAcid = "675";
        private const string EicosapentaenoicAcid = "629";
        private const string DocosahexaenoicAcid = "621";
        private const string GammaLinolenicAcid = "685";

        #endregion

        #region Methods

        // Constructor
        static USDA()
        {
            //ImportUSDAData();
            LoadUSDAData();
        }

        private static void ImportUSDAData()
        {
            // This function takes the original USDA files ASCII (ISO/IEC 8859-1) files (unzipped) and makes several modfications
            // TODO: CREATE A WIZARD THAT FIRES FROM THE MENU?

            string sourceFolder = @"C:\Users\Kent\Desktop\DietApplication\USDA_NEW\";
            string destinationFolder = @"C:\Users\Kent\Desktop\DietApplication\USDA_IMP\";

            // Perform a file inventory check before proceeding
            bool allFilesArePresent = true;
            if (!File.Exists(sourceFolder + "DATA_SRC.txt")) allFilesArePresent = false;
            if (!File.Exists(sourceFolder + "DATSRCLN.txt")) allFilesArePresent = false;
            if (!File.Exists(sourceFolder + "DERIV_CD.txt")) allFilesArePresent = false;
            if (!File.Exists(sourceFolder + "FD_GROUP.txt")) allFilesArePresent = false;
            if (!File.Exists(sourceFolder + "FOOD_DES.txt")) allFilesArePresent = false;
            if (!File.Exists(sourceFolder + "FOOTNOTE.txt")) allFilesArePresent = false;
            if (!File.Exists(sourceFolder + "LANGDESC.txt")) allFilesArePresent = false;
            if (!File.Exists(sourceFolder + "LANGUAL.txt")) allFilesArePresent = false;
            if (!File.Exists(sourceFolder + "NUT_DATA.txt")) allFilesArePresent = false;
            if (!File.Exists(sourceFolder + "NUTR_DEF.txt")) allFilesArePresent = false;
            if (!File.Exists(sourceFolder + "SRC_CD.txt")) allFilesArePresent = false;
            if (!File.Exists(sourceFolder + "WEIGHT.txt")) allFilesArePresent = false;

            if (allFilesArePresent == false)
            {
                MessageBox.Show("In order for the import of USDA Standard Reference nutrient database files to succeed, the following files need to be present in their original unaltered form:\r\n\r\nDATA_SRC.txt\r\nDATASRCLN.txt\r\nDERIV_CD.txt\r\nFD_GROUP.txt\r\nFOOD_DES.txt\r\nFOOTNOTE.txt\r\nLANGDESC.txt\r\nLANGUAL.txt\r\nNUT_DATA.txt\r\nNUTR_DEF.txt\r\nSRC_CD.txt\r\nWEIGHT.txt");
                return;
            }

            // The following files need only basic import procedures
            BasicUSDAFileImport(sourceFolder + "DATA_SRC.txt", destinationFolder + "DATA_SRC.txt");
            BasicUSDAFileImport(sourceFolder + "DATSRCLN.txt", destinationFolder + "DATSRCLN.txt");
            BasicUSDAFileImport(sourceFolder + "DERIV_CD.txt", destinationFolder + "DERIV_CD.txt");
            BasicUSDAFileImport(sourceFolder + "FD_GROUP.txt", destinationFolder + "FD_GROUP.txt");
            BasicUSDAFileImport(sourceFolder + "FOOTNOTE.txt", destinationFolder + "FOOTNOTE.txt");
            BasicUSDAFileImport(sourceFolder + "LANGDESC.txt", destinationFolder + "LANGDESC.txt");
            BasicUSDAFileImport(sourceFolder + "LANGUAL.txt", destinationFolder + "LANGUAL.txt");
            BasicUSDAFileImport(sourceFolder + "NUTR_DEF.txt", destinationFolder + "NUTR_DEF.txt");
            BasicUSDAFileImport(sourceFolder + "SRC_CD.txt", destinationFolder + "SRC_CD.txt");
            BasicUSDAFileImport(sourceFolder + "WEIGHT.txt", destinationFolder + "WEIGHT.txt");

            // First perform basic import proceedures on the following file
            BasicUSDAFileImport(sourceFolder + "FOOD_DES.txt", destinationFolder + "FOOD_DES.txt");

            // Modify the food description field in FOOD_DES.txt
            FOOD_DES = USDATextFileToDataTable(destinationFolder + "FOOD_DES.txt", new string[] { "NDB_No", "FdGrp_CD", "Long_Desc", "Shrt_Desc", "ComName", "ManufacName", "Survey", "Ref_Desc", "Refuse", "SciName", "N_Factor", "Pro_Factor", "Fat_Factor", "CHO_Factor" });
            StreamWriter newFile = new StreamWriter(destinationFolder + "FOOD_DES.txt");
            foreach (DataRow row in FOOD_DES.Rows)
            {
                // Modify row
                string foodName = row["Long_Desc"].ToString();
                foodName = foodName.ToLower().FirstLetterToUpper();
                foodName = foodName.Replace(",", ", ");
                foodName = foodName.Replace(",  ", ", ");
                row["Long_Desc"] = foodName;

                // Export row
                StringBuilder rowString = new StringBuilder();
                foreach (string item in row.ItemArray)
                {
                    rowString.Append(item);
                    if (item.ToString() != row.ItemArray[row.ItemArray.Length - 1].ToString()) rowString.Append("^");
                }
                newFile.WriteLine(rowString);
            }
            newFile.Close();

            // create a NUT_DATA crosstab file

            // First perform basic import proceedures on the following file
            BasicUSDAFileImport(sourceFolder + "NUT_DATA.txt", destinationFolder + "NUT_DATA.txt");

            // Load the imported file into a DataTable
            NUT_DATA = USDATextFileToDataTable(destinationFolder + "NUT_DATA.txt", new string[] { "NDB_No", "Nutr_No", "Nutr_Val", "Num_Data_Pts", "Std_Error", "Src_Cd", "Deriv_Cd", "Ref_NDB_No", "Add_Nutr_Mark", "Num_Studies", "Min", "Max", "DF", "Low_EB", "Up_EB", "Stat_Cmt", "AddMOd_Date", "Reserved" });

            // Open a file for writing
            newFile = new StreamWriter(destinationFolder + "NUT_DATA.txt");

            // Get a list of all unique NDB_No strings from NUT_DATA (these will define the rows in the crosstab file)
            var queryresults = from DataRow row in NUT_DATA.Rows
                               orderby row["NDB_No"]
                               select row["NDB_No"] as string
                               ;
            List<string> Ndb_No_List = queryresults.Distinct().ToList<string>();

            // Get a similar list with all unique Nutr_No strings (these will define the columns in the crosstab file)
            queryresults = from DataRow row in NUT_DATA.Rows
                           orderby row["Nutr_No"]
                           select row["Nutr_No"] as string
                           ;
            List<string> Nutr_No_List = queryresults.Distinct().ToList<string>();

            // Create a header for this custom crosstab file
            StringBuilder header = new StringBuilder();
            header.Append("NDB_No^");
            header.Append("Long_Desc^");
            header.Append("FdGrp_Cd^");
            foreach (string Nutr_No in Nutr_No_List)
            {
                header.Append(Nutr_No);
                if (Nutr_No.ToString() != Nutr_No_List[Nutr_No_List.Count - 1].ToString()) { header.Append("^"); }
            }
            File.WriteAllText(destinationFolder + "NUT_DATA_HEADER.txt", header.ToString());

            // Loop through each unique NDB_No (each iteration will produce one row in the crosstab file being built)
            foreach (string NDB_No in Ndb_No_List)
            {
                StringBuilder line = new StringBuilder();

                // Write the first column (NDB_No)
                line.Append(NDB_No);
                line.Append("^");

                // Write the second column (Long_Desc)
                var result1 = from row in FOOD_DES.AsEnumerable()
                              where row.Field<string>("NDB_No").Equals(NDB_No)
                              select row["Long_Desc"] as string
                              ;
                string longDesc = result1.First<string>();
                longDesc = (longDesc.ToLower()).FirstLetterToUpper();
                longDesc = longDesc.Replace(",", ", ");
                longDesc = longDesc.Replace(",  ", ", ");
                line.Append(longDesc);
                line.Append("^");

                // Write the third column (FdGrp_Cd)
                var result2 = from row in FOOD_DES.AsEnumerable()
                              where row.Field<string>("NDB_No").Equals(NDB_No)
                              select row["FdGrp_Cd"] as string
                              ;
                string fdGrp = result2.Single<string>();
                line.Append(fdGrp);
                line.Append("^");

                // NUT_DATA.txt contains many rows for the same NDB_No (one for each nutrient)
                // Query NUT_DATA to get a list of all rows with the NDB_No currently being iterated upon in the loop
                // This produces a list of all nutrients that the given NDB_No has data for
                var result3 = from DataRow row in NUT_DATA.Rows
                              where (string)row["NDB_No"] == NDB_No
                              select row
                              ;
                List<DataRow> nutrientValues = result3.ToList<DataRow>();

                // Loop through each unique Nutr_No (each iteration will produce one column in the crosstab file being built)
                foreach (string Nutr_No in Nutr_No_List)
                {
                    string Nutr_Val = "";

                    // Iterate through the list of rows
                    foreach (var nutrient in nutrientValues)
                    {
                        // If a nutrient from this loop matches the nutrNo currently being looped then overwrite the nutrVal with the correct value
                        if ((string)nutrient["Nutr_No"] == Nutr_No.ToString()) Nutr_Val = nutrient["Nutr_Val"].ToString();
                    }

                    // Always append a value even if it is blank
                    line.Append(Nutr_Val);
                    if (Nutr_No.ToString() != Nutr_No_List[Nutr_No_List.Count - 1].ToString()) line.Append("^");
                }

                newFile.WriteLine(line.ToString());
            }
            newFile.Close();
        }

        private static void LoadUSDAData()
        {
            string sourceFolder = @"C:\Users\Kent\Desktop\DietApplication\USDA_IMP\";

            // Load USDA data text files to data tables, starting with the four mandatory tables
            string[] nutDataHeader = (File.ReadAllText(sourceFolder + "NUT_DATA_HEADER.txt")).Split('^');
            NUT_DATA = USDATextFileToDataTable(sourceFolder + "NUT_DATA.txt", nutDataHeader);
            NUT_DATA.PrimaryKey = new DataColumn[] { NUT_DATA.Columns["NDB_No"] };
            FD_GROUP = USDATextFileToDataTable(sourceFolder + "FD_GROUP.txt", new string[] { "FdGrp_CD", "FdGrp_Desc" });
            NUTR_DEF = USDATextFileToDataTable(sourceFolder + "NUTR_DEF.txt", new string[] { "Nutr_No", "Units", "Tagname", "NutrDesc", "Num_Dec", "SR_Order" });
            WEIGHT = USDATextFileToDataTable(sourceFolder + "WEIGHT.txt", new string[] { "NDB_No", "Seq", "Amount", "Msre_Desc", "Gm_Wgt", "Num_Data_Pts", "Std_Dev" });

            if (Settings.Default.LoadDataSourceTables)
            {
                DATA_SRC = USDATextFileToDataTable(sourceFolder + "DATA_SRC.txt", new string[] { "DataSrc_ID", "Authors", "Title", "Year", "Journal", "Vol_City", "Issue_State", "Start_Page", "End_Page" });
                DATSRCLN = USDATextFileToDataTable(sourceFolder + "DATSRCLN.txt", new string[] { "NDB_No", "Nutr_No", "DataSrcID" });
            }

            if (Settings.Default.LoadAdditionalNutrientDataTables)
            {
                DERIV_CD = USDATextFileToDataTable(sourceFolder + "DERIV_CD.txt", new string[] { "Deriv_CD", "Deriv_Desc" });
                SRC_CD = USDATextFileToDataTable(sourceFolder + "SRC_CD.txt", new string[] { "Src_Cd", "SrcCd_Desc" });
            }

            if (Settings.Default.LoadAdditionalFoodDataTables)
            {
                FOOTNOTE = USDATextFileToDataTable(sourceFolder + "FOOTNOTE.txt", new string[] { "NDB_No", "Footnt_No", "Footnot_Typ", "Nutr_No", "Footnot_Txt" });
                FOOD_DES = USDATextFileToDataTable(sourceFolder + "FOOD_DES.txt", new string[] { "NDB_No", "FdGrp_CD", "Long_Desc", "Shrt_Desc", "ComName", "ManufacName", "Survey", "Ref_Desc", "Refuse", "SciName", "N_Factor", "Pro_Factor", "Fat_Factor", "CHO_Factor" });
            }

            if (Settings.Default.LoadLangualTables)
            {
                LANGDESC = USDATextFileToDataTable(sourceFolder + "LANGDESC.txt", new string[] { "Factor", "Description" });
                LANGUAL = USDATextFileToDataTable(sourceFolder + "LANGUAL.txt", new string[] { "NDB_No", "Factor" });
            }
        }

        private static void BasicUSDAFileImport(string source, string destination)
        {
            // This function does two things: preserves ANSI special characters and removes the tilde (~) text qualifier
            string _text = File.ReadAllText(source, Encoding.Default);
            _text = _text.Replace("~", "");
            File.WriteAllText(destination, _text);
        }

        private static double Nutrient(string NDB_No, string Nutr_No)
        {
            string value = NUT_DATA.GetSingleValueForRecordMatchingNDBNo(NDB_No, Nutr_No);
            double i;
            if (!Double.TryParse(value, out i)) { return 0; }
            else { return i; }
        }

        private static string Unit(string Nutr_No)
        {
            var queryresult =
                from DataRow row in NUTR_DEF.Rows
                where (string)row["Nutr_No"] == Nutr_No
                select row["Units"] as string
                ;
            return queryresult.SingleOrDefault<string>();
        }

        public static List<string> GetFoodList(string searchString, bool startsWith)
        {
            if (NUT_DATA == null) return null;

            List<string> list = new List<string>();
            searchString = searchString.ToLower();

            if (searchString == null || searchString == "")
            {
                var queryresults =
                    from DataRow row in NUT_DATA.Rows
                    select row["Long_Desc"] as string
                    ;
                list = queryresults.ToList<string>();
            }
            else if (startsWith)
            {
                var queryresults =
                    from DataRow row in NUT_DATA.Rows
                    where row.Field<string>("Long_Desc").ToLower().StartsWith(searchString)
                    select row["Long_Desc"] as string
                    ;
                list = queryresults.ToList<string>();
            }
            else
            {
                var queryresults =
                    from DataRow row in NUT_DATA.Rows
                    where row.Field<string>("Long_Desc").ToLower().Contains(searchString)
                    select row["Long_Desc"] as string
                    ;
                list = queryresults.ToList<string>();
            }

            return list;
        }

        public static List<string> GetFoodListByGroup(string FdGrp_Desc)
        {
            if (FdGrp_Desc != null && FD_GROUP != null && NUT_DATA != null)
            {
                // Get the FdGrp_CP of the food group
                var query1 =
                    from row in FD_GROUP.AsEnumerable()
                    where ((string)row["FdGrp_Desc"]).ToLower() == FdGrp_Desc.ToLower()
                    select row["FdGrp_CD"] as string
                    ;
                string FdGrp_CD = query1.SingleOrDefault<string>();

                // Return the list of foods belonging to the food group with the above FdGrp_CD
                var query2 =
                    from row in NUT_DATA.AsEnumerable()
                    where row.Field<string>("FdGrp_CD").Equals(FdGrp_CD)
                    select row["Long_Desc"] as string
                    ;
                return query2.ToList<string>();
            }
            else return null;
        }

        public static List<string> GetFoodGroups()
        {
            var queryresults =
                        from DataRow row in FD_GROUP.Rows
                        select row["FdGrp_Desc"] as string
                        ;
            return queryresults.ToList<string>();
        }

        public static List<string> GetUnits(string NDB_No)
        {
            var queryresults =
                       from DataRow row in WEIGHT.Rows
                       where row.Field<string>("NDB_No").ToLower().Equals(NDB_No)
                       select row["Msre_Desc"] as string
                       ;
            return queryresults.ToList<string>();
        }

        public static string GetNDBNumber(string Long_Desc)
        {
            return NUT_DATA.GetSingleValueForRecordMatchingLongDesc(Long_Desc, "NDB_No");
        }

        private static DataTable USDATextFileToDataTable(string fileName, string[] headers)
        {
            string contents = File.ReadAllText(fileName, Encoding.UTF8);
            DataTable table = new DataTable();

            foreach (var header in headers) { table.Columns.Add(header); }

            string[] stringSeparators = new string[] { "\r\n" };
            var rows = contents.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

            foreach (string row in rows) { table.Rows.Add(row.Split('^')); }

            return table;
        }

        public static double GetNutrientConversionFactor(string NDB_No, string unit, double quantity)
        {
            /* 
                Determine the number to multiply the nutrients of a food item by given the quantity and unit of the food item
                Nutrient values in the USDA database are per 100g of edible portion of a given food
                The purpose of this method is to generate a factor that can be used to adjust any of a food's nutrient values
                Total grams = quantity * gram weight of specified Unit (determined by checking the WEIGHT table)
                Since units are 100g, dividing by 100 yields 1g, so multiply by the total number of grams to get the adjusted quantity of a nutrient
                Like so: factor = quantity * gram weight / 100
            */

// Look up the gram weight of the given food (per NDB_No) and unit (per Seq) in the WEIGHT table
double gramWeight;

            // If the unit is "gram" then the gram weight should be 1 (the quantity of 100 is listed when a food is added to the plan and gram is the unit)
            if (unit.ToLower() == "gram") { gramWeight = 1; }
            else
            {
                var queryresult =
                            from DataRow row in WEIGHT.Rows
                            where (row.Field<string>("NDB_No") == NDB_No) && (row.Field<string>("Msre_Desc").ToLower() == unit.ToLower())
                            select row["Gm_Wgt"] as string
                            ;
                string result = queryresult.SingleOrDefault<string>();
                if (!Double.TryParse(result, out gramWeight)) { return 0; }
            }

            // Apply the formula as discussed above
            double factor = quantity * gramWeight / 100;
            return factor;
        }

        public static FoodData GetFoodData(string Long_Desc)
        {
            if (Long_Desc == null || Long_Desc == "") return null;
            string NBD_No = GetNDBNumber(Long_Desc);

            FoodData FoodItem = new FoodData();
            FoodItem.Protein = Nutrient(NBD_No, Protein); FoodItem.ProteinUnit = Unit(Protein);
            FoodItem.TotalLipids = Nutrient(NBD_No, TotalLipids); FoodItem.TotalLipidsUnit = Unit(TotalLipids);
            FoodItem.Carbohydrates = Nutrient(NBD_No, Carbohydrates); FoodItem.CarbohydratesUnit = Unit(Carbohydrates);
            FoodItem.Ash = Nutrient(NBD_No, Ash); FoodItem.AshUnit = Unit(Ash);
            FoodItem.EnergyKCal = Nutrient(NBD_No, EnergyKCal); FoodItem.EnergyKCalUnit = Unit(EnergyKCal);
            FoodItem.Starch = Nutrient(NBD_No, Starch); FoodItem.StarchUnit = Unit(Starch);
            FoodItem.Sucrose = Nutrient(NBD_No, Sucrose); FoodItem.SucroseUnit = Unit(Sucrose);
            FoodItem.Glucose = Nutrient(NBD_No, Glucose); FoodItem.GlucoseUnit = Unit(Glucose);
            FoodItem.Fructose = Nutrient(NBD_No, Fructose); FoodItem.FructoseUnit = Unit(Fructose);
            FoodItem.Lactose = Nutrient(NBD_No, Lactose); FoodItem.LactoseUnit = Unit(Lactose);
            FoodItem.Maltose = Nutrient(NBD_No, Maltose); FoodItem.MaltoseUnit = Unit(Maltose);
            FoodItem.Alcohol = Nutrient(NBD_No, Alcohol); FoodItem.AlcoholUnit = Unit(Alcohol);
            FoodItem.Water = Nutrient(NBD_No, Water); FoodItem.WaterUnit = Unit(Water);
            FoodItem.AdjustedProtein = Nutrient(NBD_No, AdjustedProtein); FoodItem.AdjustedProteinUnit = Unit(AdjustedProtein);
            FoodItem.Caffeine = Nutrient(NBD_No, Caffeine); FoodItem.CaffeineUnit = Unit(Caffeine);
            FoodItem.Theobromine = Nutrient(NBD_No, Theobromine); FoodItem.TheobromineUnit = Unit(Theobromine);
            FoodItem.EnergyKJ = Nutrient(NBD_No, EnergyKJ); FoodItem.EnergyKJUnit = Unit(EnergyKJ);
            FoodItem.TotalSugars = Nutrient(NBD_No, TotalSugars); FoodItem.TotalSugarsUnit = Unit(TotalSugars);
            FoodItem.Galactose = Nutrient(NBD_No, Galactose); FoodItem.GalactoseUnit = Unit(Galactose);
            FoodItem.TotalFiber = Nutrient(NBD_No, TotalFiber); FoodItem.TotalFiberUnit = Unit(TotalFiber);
            FoodItem.Calcium = Nutrient(NBD_No, Calcium); FoodItem.CalciumUnit = Unit(Calcium);
            FoodItem.Iron = Nutrient(NBD_No, Iron); FoodItem.IronUnit = Unit(Iron);
            FoodItem.Magnesium = Nutrient(NBD_No, Magnesium); FoodItem.MagnesiumUnit = Unit(Magnesium);
            FoodItem.Phosphorus = Nutrient(NBD_No, Phosphorus); FoodItem.PhosphorusUnit = Unit(Phosphorus);
            FoodItem.Potassium = Nutrient(NBD_No, Potassium); FoodItem.PotassiumUnit = Unit(Potassium);
            FoodItem.Sodium = Nutrient(NBD_No, Sodium); FoodItem.SodiumUnit = Unit(Sodium);
            FoodItem.Zinc = Nutrient(NBD_No, Zinc); FoodItem.ZincUnit = Unit(Zinc);
            FoodItem.Copper = Nutrient(NBD_No, Copper); FoodItem.CopperUnit = Unit(Copper);
            FoodItem.Fluoride = Nutrient(NBD_No, Fluoride); FoodItem.FluorideUnit = Unit(Fluoride);
            FoodItem.Manganese = Nutrient(NBD_No, Manganese); FoodItem.ManganeseUnit = Unit(Manganese);
            FoodItem.Selenium = Nutrient(NBD_No, Selenium); FoodItem.SeleniumUnit = Unit(Selenium);
            FoodItem.VitaminAIU = Nutrient(NBD_No, VitaminAIU); FoodItem.VitaminAIUUnit = Unit(VitaminAIU);
            FoodItem.Retinol = Nutrient(NBD_No, Retinol); FoodItem.RetinolUnit = Unit(Retinol);
            FoodItem.VitaminARAE = Nutrient(NBD_No, VitaminARAE); FoodItem.VitaminARAEUnit = Unit(VitaminARAE);
            FoodItem.BetaCarotene = Nutrient(NBD_No, BetaCarotene); FoodItem.BetaCaroteneUnit = Unit(BetaCarotene);
            FoodItem.AlphaCarotene = Nutrient(NBD_No, AlphaCarotene); FoodItem.AlphaCaroteneUnit = Unit(AlphaCarotene);
            FoodItem.VitaminE = Nutrient(NBD_No, VitaminE); FoodItem.VitaminEUnit = Unit(VitaminE);
            FoodItem.VitaminD = Nutrient(NBD_No, VitaminD); FoodItem.VitaminDUnit = Unit(VitaminD);
            FoodItem.VitaminD2 = Nutrient(NBD_No, VitaminD2); FoodItem.VitaminD2Unit = Unit(VitaminD2);
            FoodItem.VitaminD3 = Nutrient(NBD_No, VitaminD3); FoodItem.VitaminD3Unit = Unit(VitaminD3);
            FoodItem.Cryptoxanthin = Nutrient(NBD_No, Cryptoxanthin); FoodItem.CryptoxanthinUnit = Unit(Cryptoxanthin);
            FoodItem.Lycopene = Nutrient(NBD_No, Lycopene); FoodItem.LycopeneUnit = Unit(Lycopene);
            FoodItem.LuteinPlusZeaxanthin = Nutrient(NBD_No, LuteinPlusZeaxanthin); FoodItem.LuteinPlusZeaxanthinUnit = Unit(LuteinPlusZeaxanthin);
            FoodItem.VitaminC = Nutrient(NBD_No, VitaminC); FoodItem.VitaminCUnit = Unit(VitaminC);
            FoodItem.Thiamin = Nutrient(NBD_No, Thiamin); FoodItem.ThiaminUnit = Unit(Thiamin);
            FoodItem.Riboflavin = Nutrient(NBD_No, Riboflavin); FoodItem.RiboflavinUnit = Unit(Riboflavin);
            FoodItem.Niacin = Nutrient(NBD_No, Niacin); FoodItem.NiacinUnit = Unit(Niacin);
            FoodItem.PantothenicAcid = Nutrient(NBD_No, PantothenicAcid); FoodItem.PantothenicAcidUnit = Unit(PantothenicAcid);
            FoodItem.VitaminB6 = Nutrient(NBD_No, VitaminB6); FoodItem.VitaminB6Unit = Unit(VitaminB6);
            FoodItem.FolateTotal = Nutrient(NBD_No, FolateTotal); FoodItem.FolateTotalUnit = Unit(FolateTotal);
            FoodItem.VitaminB12 = Nutrient(NBD_No, VitaminB12); FoodItem.VitaminB12Unit = Unit(VitaminB12);
            FoodItem.Choline = Nutrient(NBD_No, Choline); FoodItem.CholineUnit = Unit(Choline);
            FoodItem.Menaquinone4 = Nutrient(NBD_No, Menaquinone4); FoodItem.Menaquinone4Unit = Unit(Menaquinone4);
            FoodItem.Dihydrophylloquinone = Nutrient(NBD_No, Dihydrophylloquinone); FoodItem.DihydrophylloquinoneUnit = Unit(Dihydrophylloquinone);
            FoodItem.VitaminK = Nutrient(NBD_No, VitaminK); FoodItem.VitaminKUnit = Unit(VitaminK);
            FoodItem.FolicAcid = Nutrient(NBD_No, FolicAcid); FoodItem.FolicAcidUnit = Unit(FolicAcid);
            FoodItem.FolateFood = Nutrient(NBD_No, FolateFood); FoodItem.FolateFoodUnit = Unit(FolateFood);
            FoodItem.Betaine = Nutrient(NBD_No, Betaine); FoodItem.BetaineUnit = Unit(Betaine);
            FoodItem.Tryptophan = Nutrient(NBD_No, Tryptophan); FoodItem.TryptophanUnit = Unit(Tryptophan);
            FoodItem.Threonine = Nutrient(NBD_No, Threonine); FoodItem.ThreonineUnit = Unit(Threonine);
            FoodItem.Isoleucine = Nutrient(NBD_No, Isoleucine); FoodItem.IsoleucineUnit = Unit(Isoleucine);
            FoodItem.Leucine = Nutrient(NBD_No, Leucine); FoodItem.LeucineUnit = Unit(Leucine);
            FoodItem.Lysine = Nutrient(NBD_No, Lysine); FoodItem.LysineUnit = Unit(Lysine);
            FoodItem.Methionine = Nutrient(NBD_No, Methionine); FoodItem.MethionineUnit = Unit(Methionine);
            FoodItem.Cystine = Nutrient(NBD_No, Cystine); FoodItem.CystineUnit = Unit(Cystine);
            FoodItem.Phenylalanine = Nutrient(NBD_No, Phenylalanine); FoodItem.PhenylalanineUnit = Unit(Phenylalanine);
            FoodItem.Tyrosine = Nutrient(NBD_No, Tyrosine); FoodItem.TyrosineUnit = Unit(Tyrosine);
            FoodItem.Valine = Nutrient(NBD_No, Valine); FoodItem.ValineUnit = Unit(Valine);
            FoodItem.Arginine = Nutrient(NBD_No, Arginine); FoodItem.ArginineUnit = Unit(Arginine);
            FoodItem.Histidine = Nutrient(NBD_No, Histidine); FoodItem.HistidineUnit = Unit(Histidine);
            FoodItem.Alanine = Nutrient(NBD_No, Alanine); FoodItem.AlanineUnit = Unit(Alanine);
            FoodItem.AsparticAcid = Nutrient(NBD_No, AsparticAcid); FoodItem.AsparticAcidUnit = Unit(AsparticAcid);
            FoodItem.GlutamicAcid = Nutrient(NBD_No, GlutamicAcid); FoodItem.GlutamicAcidUnit = Unit(GlutamicAcid);
            FoodItem.Glycine = Nutrient(NBD_No, Glycine); FoodItem.GlycineUnit = Unit(Glycine);
            FoodItem.Proline = Nutrient(NBD_No, Proline); FoodItem.ProlineUnit = Unit(Proline);
            FoodItem.Serine = Nutrient(NBD_No, Serine); FoodItem.SerineUnit = Unit(Serine);
            FoodItem.Hydroxyproline = Nutrient(NBD_No, Hydroxyproline); FoodItem.HydroxyprolineUnit = Unit(Hydroxyproline);
            FoodItem.VitaminEAdded = Nutrient(NBD_No, VitaminEAdded); FoodItem.VitaminEAddedUnit = Unit(VitaminEAdded);
            FoodItem.VitaminB12Added = Nutrient(NBD_No, VitaminB12Added); FoodItem.VitaminB12AddedUnit = Unit(VitaminB12Added);
            FoodItem.Cholesterol = Nutrient(NBD_No, Cholesterol); FoodItem.CholesterolUnit = Unit(Cholesterol);
            FoodItem.FattyAcidsTrans = Nutrient(NBD_No, FattyAcidsTrans); FoodItem.FattyAcidsTransUnit = Unit(FattyAcidsTrans);
            FoodItem.FattyAcidsSaturated = Nutrient(NBD_No, FattyAcidsSaturated); FoodItem.FattyAcidsSaturatedUnit = Unit(FattyAcidsSaturated);
            FoodItem.Phytosterols = Nutrient(NBD_No, Phytosterols); FoodItem.PhytosterolsUnit = Unit(Phytosterols);
            FoodItem.Stigmasterol = Nutrient(NBD_No, Stigmasterol); FoodItem.StigmasterolUnit = Unit(Stigmasterol);
            FoodItem.Campesterol = Nutrient(NBD_No, Campesterol); FoodItem.CampesterolUnit = Unit(Campesterol);
            FoodItem.BetaSitosterol = Nutrient(NBD_No, BetaSitosterol); FoodItem.BetaSitosterolUnit = Unit(BetaSitosterol);
            FoodItem.FattyAcidsMonounsaturated = Nutrient(NBD_No, FattyAcidsMonounsaturated); FoodItem.FattyAcidsMonounsaturatedUnit = Unit(FattyAcidsMonounsaturated);
            FoodItem.FattyAcidsPolyunsaturated = Nutrient(NBD_No, FattyAcidsPolyunsaturated); FoodItem.FattyAcidsPolyunsaturatedUnit = Unit(FattyAcidsPolyunsaturated);
            FoodItem.FattyAcidsTransMonoenoic = Nutrient(NBD_No, FattyAcidsTransMonoenoic); FoodItem.FattyAcidsTransMonoenoicUnit = Unit(FattyAcidsTransMonoenoic);
            FoodItem.AlphaLinolenicAcid = Nutrient(NBD_No, AlphaLinolenicAcid); FoodItem.AlphaLinolenicAcidUnit = Unit(AlphaLinolenicAcid);
            FoodItem.LinoleicAcid = Nutrient(NBD_No, LinoleicAcid); FoodItem.LinoleicAcidUnit = Unit(LinoleicAcid);
            FoodItem.DocosahexaenoicAcid = Nutrient(NBD_No, DocosahexaenoicAcid); FoodItem.DocosahexaenoicAcidUnit = Unit(DocosahexaenoicAcid);
            FoodItem.GammaLinolenicAcid = Nutrient(NBD_No, GammaLinolenicAcid); FoodItem.GammaLinolenicAcidUnit = Unit(GammaLinolenicAcid);
            FoodItem.EicosapentaenoicAcid = Nutrient(NBD_No, EicosapentaenoicAcid); FoodItem.EicosapentaenoicAcidUnit = Unit(EicosapentaenoicAcid);

            return FoodItem;
        }
    }

    #endregion

    #region Data Classes

    public class CategorizedFoodListItem
    {
        public CategorizedFoodListItem(string foodGroup, List<string> foodList)
        {
            FoodGroup = foodGroup;
            FoodList = foodList;
        }

        private string _foodGroup;
        public string FoodGroup
        {
            get { return _foodGroup; }
            set { _foodGroup = value; }
        }

        private List<string> _FoodList;
        public List<string> FoodList
        {
            get { return _FoodList; }
            set { _FoodList = value; }
        }
    }

    #endregion

    // Extension method to convert the first letter of a String object to upper case (USAGE: str = str.FirstLetterToUpper())
    public static class Extensions
    {
        public static string FirstLetterToUpper(this string s)
        {
            if (s.Length > 1) return char.ToUpper(s[0]) + s.Substring(1);
            else return s.ToUpper();
        }

        public static string GetSingleValueForRecordMatchingLongDesc(this DataTable datatable, string Long_Desc, string field)
        {
            var value =
                    from DataRow row in datatable.Rows
                    where row.Field<string>("Long_Desc").ToLower() == Long_Desc.ToLower()
                    select row[field] as string
                    ;
            return value.First<string>();
        }

        public static string GetSingleValueForRecordMatchingNDBNo(this DataTable datatable, string NDB_No, string field)
        {
            DataRow row = datatable.Rows.Find(NDB_No);
            return (string)row[field];
        }

        public static List<string> GetValueListForRecordMatchingLongDesc(this DataTable datatable, string Long_Desc, string field)
        {
            var value =
                    from DataRow row in datatable.Rows
                    where row.Field<string>("Long_Desc").ToLower() == Long_Desc.ToLower()
                    select row[field] as string
                    ;
            return value.ToList<string>();
        }
    }
}
