using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DietApplication
{
    // The class which contains nutrient information for a given food item or group of food items
    public class FoodData
    {
        // Nutrient values are defined as doubles and units are defined as strings
        public string FoodName { get; set; }
        public string FoodNumber { get; set; }
        public double Protein { get; set; }
        public string ProteinUnit { get; set; }
        public double TotalLipids { get; set; }
        public string TotalLipidsUnit { get; set; }
        public double Carbohydrates { get; set; }
        public string CarbohydratesUnit { get; set; }
        public double Ash { get; set; }
        public string AshUnit { get; set; }
        public double EnergyKCal { get; set; }
        public string EnergyKCalUnit { get; set; }
        public double Starch { get; set; }
        public string StarchUnit { get; set; }
        public double Sucrose { get; set; }
        public string SucroseUnit { get; set; }
        public double Glucose { get; set; }
        public string GlucoseUnit { get; set; }
        public double Fructose { get; set; }
        public string FructoseUnit { get; set; }
        public double Lactose { get; set; }
        public string LactoseUnit { get; set; }
        public double Maltose { get; set; }
        public string MaltoseUnit { get; set; }
        public double Alcohol { get; set; }
        public string AlcoholUnit { get; set; }
        public double AdjustedProtein { get; set; }
        public string AdjustedProteinUnit { get; set; }
        public double Water { get; set; }
        public string WaterUnit { get; set; }
        public double Caffeine { get; set; }
        public string CaffeineUnit { get; set; }
        public double Theobromine { get; set; }
        public string TheobromineUnit { get; set; }
        public double EnergyKJ { get; set; }
        public string EnergyKJUnit { get; set; }
        public double TotalSugars { get; set; }
        public string TotalSugarsUnit { get; set; }
        public double Galactose { get; set; }
        public string GalactoseUnit { get; set; }
        public double TotalFiber { get; set; }
        public string TotalFiberUnit { get; set; }
        public double Calcium { get; set; }
        public string CalciumUnit { get; set; }
        public double Iron { get; set; }
        public string IronUnit { get; set; }
        public double Magnesium { get; set; }
        public string MagnesiumUnit { get; set; }
        public double Phosphorus { get; set; }
        public string PhosphorusUnit { get; set; }
        public double Potassium { get; set; }
        public string PotassiumUnit { get; set; }
        public double Sodium { get; set; }
        public string SodiumUnit { get; set; }
        public double Zinc { get; set; }
        public string ZincUnit { get; set; }
        public double Copper { get; set; }
        public string CopperUnit { get; set; }
        public double Fluoride { get; set; }
        public string FluorideUnit { get; set; }
        public double Manganese { get; set; }
        public string ManganeseUnit { get; set; }
        public double Selenium { get; set; }
        public string SeleniumUnit { get; set; }
        public double VitaminAIU { get; set; }
        public string VitaminAIUUnit { get; set; }
        public double Retinol { get; set; }
        public string RetinolUnit { get; set; }
        public double VitaminARAE { get; set; }
        public string VitaminARAEUnit { get; set; }
        public double BetaCarotene { get; set; }
        public string BetaCaroteneUnit { get; set; }
        public double AlphaCarotene { get; set; }
        public string AlphaCaroteneUnit { get; set; }
        public double VitaminE { get; set; }
        public string VitaminEUnit { get; set; }
        public double VitaminD { get; set; }
        public string VitaminDUnit { get; set; }
        public double VitaminD2 { get; set; }
        public string VitaminD2Unit { get; set; }
        public double VitaminD3 { get; set; }
        public string VitaminD3Unit { get; set; }
        public double Cryptoxanthin { get; set; }
        public string CryptoxanthinUnit { get; set; }
        public double Lycopene { get; set; }
        public string LycopeneUnit { get; set; }
        public double LuteinPlusZeaxanthin { get; set; }
        public string LuteinPlusZeaxanthinUnit { get; set; }
        public double VitaminC { get; set; }
        public string VitaminCUnit { get; set; }
        public double Thiamin { get; set; }
        public string ThiaminUnit { get; set; }
        public double Riboflavin { get; set; }
        public string RiboflavinUnit { get; set; }
        public double Niacin { get; set; }
        public string NiacinUnit { get; set; }
        public double PantothenicAcid { get; set; }
        public string PantothenicAcidUnit { get; set; }
        public double VitaminB6 { get; set; }
        public string VitaminB6Unit { get; set; }
        public double FolateTotal { get; set; }
        public string FolateTotalUnit { get; set; }
        public double VitaminB12 { get; set; }
        public string VitaminB12Unit { get; set; }
        public double Choline { get; set; }
        public string CholineUnit { get; set; }
        public double Menaquinone4 { get; set; }
        public string Menaquinone4Unit { get; set; }
        public double Dihydrophylloquinone { get; set; }
        public string DihydrophylloquinoneUnit { get; set; }
        public double VitaminK { get; set; }
        public string VitaminKUnit { get; set; }
        public double FolicAcid { get; set; }
        public string FolicAcidUnit { get; set; }
        public double FolateFood { get; set; }
        public string FolateFoodUnit { get; set; }
        public double Betaine { get; set; }
        public string BetaineUnit { get; set; }
        public double Tryptophan { get; set; }
        public string TryptophanUnit { get; set; }
        public double Threonine { get; set; }
        public string ThreonineUnit { get; set; }
        public double Isoleucine { get; set; }
        public string IsoleucineUnit { get; set; }
        public double Leucine { get; set; }
        public string LeucineUnit { get; set; }
        public double Lysine { get; set; }
        public string LysineUnit { get; set; }
        public double Methionine { get; set; }
        public string MethionineUnit { get; set; }
        public double Cystine { get; set; }
        public string CystineUnit { get; set; }
        public double Phenylalanine { get; set; }
        public string PhenylalanineUnit { get; set; }
        public double Tyrosine { get; set; }
        public string TyrosineUnit { get; set; }
        public double Valine { get; set; }
        public string ValineUnit { get; set; }
        public double Arginine { get; set; }
        public string ArginineUnit { get; set; }
        public double Histidine { get; set; }
        public string HistidineUnit { get; set; }
        public double Alanine { get; set; }
        public string AlanineUnit { get; set; }
        public double AsparticAcid { get; set; }
        public string AsparticAcidUnit { get; set; }
        public double GlutamicAcid { get; set; }
        public string GlutamicAcidUnit { get; set; }
        public double Glycine { get; set; }
        public string GlycineUnit { get; set; }
        public double Proline { get; set; }
        public string ProlineUnit { get; set; }
        public double Serine { get; set; }
        public string SerineUnit { get; set; }
        public double Hydroxyproline { get; set; }
        public string HydroxyprolineUnit { get; set; }
        public double VitaminEAdded { get; set; }
        public string VitaminEAddedUnit { get; set; }
        public double VitaminB12Added { get; set; }
        public string VitaminB12AddedUnit { get; set; }
        public double Cholesterol { get; set; }
        public string CholesterolUnit { get; set; }
        public double FattyAcidsTrans { get; set; }
        public string FattyAcidsTransUnit { get; set; }
        public double FattyAcidsSaturated { get; set; }
        public string FattyAcidsSaturatedUnit { get; set; }
        public double Phytosterols { get; set; }
        public string PhytosterolsUnit { get; set; }
        public double Stigmasterol { get; set; }
        public string StigmasterolUnit { get; set; }
        public double Campesterol { get; set; }
        public string CampesterolUnit { get; set; }
        public double BetaSitosterol { get; set; }
        public string BetaSitosterolUnit { get; set; }
        public double FattyAcidsMonounsaturated { get; set; }
        public string FattyAcidsMonounsaturatedUnit { get; set; }
        public double FattyAcidsPolyunsaturated { get; set; }
        public string FattyAcidsPolyunsaturatedUnit { get; set; }
        public double FattyAcidsTransMonoenoic { get; set; }
        public string FattyAcidsTransMonoenoicUnit { get; set; }
        public double FattyAcidsTransPolyenoic { get; set; }
        public string FattyAcidsTransPolyenoicUnit { get; set; }
        public double AlphaLinolenicAcid { get; set; }
        public string AlphaLinolenicAcidUnit { get; set; }
        public double LinoleicAcid { get; set; }
        public string LinoleicAcidUnit { get; set; }
        public double DocosahexaenoicAcid { get; set; }
        public string DocosahexaenoicAcidUnit { get; set; }
        public double GammaLinolenicAcid { get; set; }
        public string GammaLinolenicAcidUnit { get; set; }
        public double EicosapentaenoicAcid { get; set; }
        public string EicosapentaenoicAcidUnit { get; set; }

        // Static method to round nutrient values to the given number of fractional digits
        // This is intended to be performed against the final set of data just prior to display on the Totals tab
        public static FoodData Round(FoodData f1, int fractionalDigits)
        {
            FoodData r = new FoodData();

            // Since a new FoodData item is being created copy the units to it
            CopyUnits(f1, r);
            r.Protein = Math.Round(f1.Protein, fractionalDigits);
            r.TotalLipids = Math.Round(f1.TotalLipids, fractionalDigits);
            r.Carbohydrates = Math.Round(f1.Carbohydrates, fractionalDigits);
            r.Ash = Math.Round(f1.Ash, fractionalDigits);
            r.EnergyKCal = Math.Round(f1.EnergyKCal, fractionalDigits);
            r.Starch = Math.Round(f1.Starch, fractionalDigits);
            r.Sucrose = Math.Round(f1.Sucrose, fractionalDigits);
            r.Glucose = Math.Round(f1.Glucose, fractionalDigits);
            r.Fructose = Math.Round(f1.Fructose, fractionalDigits);
            r.Lactose = Math.Round(f1.Lactose, fractionalDigits);
            r.Maltose = Math.Round(f1.Maltose, fractionalDigits);
            r.Alcohol = Math.Round(f1.Alcohol, fractionalDigits);
            r.AdjustedProtein = Math.Round(f1.AdjustedProtein, fractionalDigits);
            r.Water = Math.Round(f1.Water, fractionalDigits);
            r.Caffeine = Math.Round(f1.Caffeine, fractionalDigits);
            r.Theobromine = Math.Round(f1.Theobromine, fractionalDigits);
            r.EnergyKJ = Math.Round(f1.EnergyKJ, fractionalDigits);
            r.TotalSugars = Math.Round(f1.TotalSugars, fractionalDigits);
            r.Galactose = Math.Round(f1.Galactose, fractionalDigits);
            r.TotalFiber = Math.Round(f1.TotalFiber, fractionalDigits);
            r.Calcium = Math.Round(f1.Calcium, fractionalDigits);
            r.Iron = Math.Round(f1.Iron, fractionalDigits);
            r.Magnesium = Math.Round(f1.Magnesium, fractionalDigits);
            r.Phosphorus = Math.Round(f1.Phosphorus, fractionalDigits);
            r.Potassium = Math.Round(f1.Potassium, fractionalDigits);
            r.Sodium = Math.Round(f1.Sodium, fractionalDigits);
            r.Zinc = Math.Round(f1.Zinc, fractionalDigits);
            r.Copper = Math.Round(f1.Copper, fractionalDigits);
            r.Fluoride = Math.Round(f1.Fluoride, fractionalDigits);
            r.Manganese = Math.Round(f1.Manganese, fractionalDigits);
            r.Selenium = Math.Round(f1.Selenium, fractionalDigits);
            r.VitaminAIU = Math.Round(f1.VitaminAIU, fractionalDigits);
            r.Retinol = Math.Round(f1.Retinol, fractionalDigits);
            r.VitaminARAE = Math.Round(f1.VitaminARAE, fractionalDigits);
            r.BetaCarotene = Math.Round(f1.BetaCarotene, fractionalDigits);
            r.AlphaCarotene = Math.Round(f1.AlphaCarotene, fractionalDigits);
            r.VitaminE = Math.Round(f1.VitaminE, fractionalDigits);
            r.VitaminD = Math.Round(f1.VitaminD, fractionalDigits);
            r.VitaminD2 = Math.Round(f1.VitaminD2, fractionalDigits);
            r.VitaminD3 = Math.Round(f1.VitaminD3, fractionalDigits);
            r.Cryptoxanthin = Math.Round(f1.Cryptoxanthin, fractionalDigits);
            r.Lycopene = Math.Round(f1.Lycopene, fractionalDigits);
            r.LuteinPlusZeaxanthin = Math.Round(f1.LuteinPlusZeaxanthin, fractionalDigits);
            r.VitaminC = Math.Round(f1.VitaminC, fractionalDigits);
            r.Thiamin = Math.Round(f1.Thiamin, fractionalDigits);
            r.Riboflavin = Math.Round(f1.Riboflavin, fractionalDigits);
            r.Niacin = Math.Round(f1.Niacin, fractionalDigits);
            r.PantothenicAcid = Math.Round(f1.PantothenicAcid, fractionalDigits);
            r.VitaminB6 = Math.Round(f1.VitaminB6, fractionalDigits);
            r.FolateTotal = Math.Round(f1.FolateTotal, fractionalDigits);
            r.VitaminB12 = Math.Round(f1.VitaminB12, fractionalDigits);
            r.Choline = Math.Round(f1.Choline, fractionalDigits);
            r.Menaquinone4 = Math.Round(f1.Menaquinone4, fractionalDigits);
            r.Dihydrophylloquinone = Math.Round(f1.Dihydrophylloquinone, fractionalDigits);
            r.VitaminK = Math.Round(f1.VitaminK, fractionalDigits);
            r.FolicAcid = Math.Round(f1.FolicAcid, fractionalDigits);
            r.FolateFood = Math.Round(f1.FolateFood, fractionalDigits);
            r.Betaine = Math.Round(f1.Betaine, fractionalDigits);
            r.Tryptophan = Math.Round(f1.Tryptophan, fractionalDigits);
            r.Threonine = Math.Round(f1.Threonine, fractionalDigits);
            r.Isoleucine = Math.Round(f1.Isoleucine, fractionalDigits);
            r.Leucine = Math.Round(f1.Leucine, fractionalDigits);
            r.Lysine = Math.Round(f1.Lysine, fractionalDigits);
            r.Methionine = Math.Round(f1.Methionine, fractionalDigits);
            r.Cystine = Math.Round(f1.Cystine, fractionalDigits);
            r.Phenylalanine = Math.Round(f1.Phenylalanine, fractionalDigits);
            r.Tyrosine = Math.Round(f1.Tyrosine, fractionalDigits);
            r.Valine = Math.Round(f1.Valine, fractionalDigits);
            r.Arginine = Math.Round(f1.Arginine, fractionalDigits);
            r.Histidine = Math.Round(f1.Histidine, fractionalDigits);
            r.Alanine = Math.Round(f1.Alanine, fractionalDigits);
            r.AsparticAcid = Math.Round(f1.AsparticAcid, fractionalDigits);
            r.GlutamicAcid = Math.Round(f1.GlutamicAcid, fractionalDigits);
            r.Glycine = Math.Round(f1.Glycine, fractionalDigits);
            r.Proline = Math.Round(f1.Proline, fractionalDigits);
            r.Serine = Math.Round(f1.Serine, fractionalDigits);
            r.Hydroxyproline = Math.Round(f1.Hydroxyproline, fractionalDigits);
            r.VitaminEAdded = Math.Round(f1.VitaminEAdded, fractionalDigits);
            r.VitaminB12Added = Math.Round(f1.VitaminB12Added, fractionalDigits);
            r.Cholesterol = Math.Round(f1.Cholesterol, fractionalDigits);
            r.FattyAcidsTrans = Math.Round(f1.FattyAcidsTrans, fractionalDigits);
            r.FattyAcidsSaturated = Math.Round(f1.FattyAcidsSaturated, fractionalDigits);
            r.Phytosterols = Math.Round(f1.Phytosterols, fractionalDigits);
            r.Stigmasterol = Math.Round(f1.Stigmasterol, fractionalDigits);
            r.Campesterol = Math.Round(f1.Campesterol, fractionalDigits);
            r.BetaSitosterol = Math.Round(f1.BetaSitosterol, fractionalDigits);
            r.FattyAcidsMonounsaturated = Math.Round(f1.FattyAcidsMonounsaturated, fractionalDigits);
            r.FattyAcidsPolyunsaturated = Math.Round(f1.FattyAcidsPolyunsaturated, fractionalDigits);
            r.FattyAcidsTransMonoenoic = Math.Round(f1.FattyAcidsTransMonoenoic, fractionalDigits);
            r.FattyAcidsTransPolyenoic = Math.Round(f1.FattyAcidsTransPolyenoic, fractionalDigits);
            r.AlphaLinolenicAcid = Math.Round(f1.AlphaLinolenicAcid, fractionalDigits);
            r.LinoleicAcid = Math.Round(f1.LinoleicAcid, fractionalDigits);
            r.DocosahexaenoicAcid = Math.Round(f1.DocosahexaenoicAcid, fractionalDigits);
            r.GammaLinolenicAcid = Math.Round(f1.GammaLinolenicAcid, fractionalDigits);
            r.EicosapentaenoicAcid = Math.Round(f1.EicosapentaenoicAcid, fractionalDigits);
            return r;
        }

        // Operator overload to allow adding two FoodData items together
        public static FoodData operator +(FoodData f1, FoodData f2)
        {
            FoodData r = new FoodData();

            // Since a new FoodData item is being created copy the units to it
            CopyUnits(f2, r);
            r.FoodName = "";
            r.FoodNumber = "";
            r.Protein = f1.Protein + f2.Protein;
            r.TotalLipids = f1.TotalLipids + f2.TotalLipids;
            r.Carbohydrates = f1.Carbohydrates + f2.Carbohydrates;
            r.Ash = f1.Ash + f2.Ash;
            r.EnergyKCal = f1.EnergyKCal + f2.EnergyKCal;
            r.Starch = f1.Starch + f2.Starch;
            r.Sucrose = f1.Sucrose + f2.Sucrose;
            r.Glucose = f1.Glucose + f2.Glucose;
            r.Fructose = f1.Fructose + f2.Fructose;
            r.Lactose = f1.Lactose + f2.Lactose;
            r.Maltose = f1.Maltose + f2.Maltose;
            r.Alcohol = f1.Alcohol + f2.Alcohol;
            r.AdjustedProtein = f1.AdjustedProtein + f2.AdjustedProtein;
            r.Water = f1.Water + f2.Water;
            r.Caffeine = f1.Caffeine + f2.Caffeine;
            r.Theobromine = f1.Theobromine + f2.Theobromine;
            r.EnergyKJ = f1.EnergyKJ + f2.EnergyKJ;
            r.TotalSugars = f1.TotalSugars + f2.TotalSugars;
            r.Galactose = f1.Galactose + f2.Galactose;
            r.TotalFiber = f1.TotalFiber + f2.TotalFiber;
            r.Calcium = f1.Calcium + f2.Calcium;
            r.Iron = f1.Iron + f2.Iron;
            r.Magnesium = f1.Magnesium + f2.Magnesium;
            r.Phosphorus = f1.Phosphorus + f2.Phosphorus;
            r.Potassium = f1.Potassium + f2.Potassium;
            r.Sodium = f1.Sodium + f2.Sodium;
            r.Zinc = f1.Zinc + f2.Zinc;
            r.Copper = f1.Copper + f2.Copper;
            r.Fluoride = f1.Fluoride + f2.Fluoride;
            r.Manganese = f1.Manganese + f2.Manganese;
            r.Selenium = f1.Selenium + f2.Selenium;
            r.VitaminAIU = f1.VitaminAIU + f2.VitaminAIU;
            r.Retinol = f1.Retinol + f2.Retinol;
            r.VitaminARAE = f1.VitaminARAE + f2.VitaminARAE;
            r.BetaCarotene = f1.BetaCarotene + f2.BetaCarotene;
            r.AlphaCarotene = f1.AlphaCarotene + f2.AlphaCarotene;
            r.VitaminE = f1.VitaminE + f2.VitaminE;
            r.VitaminD = f1.VitaminD + f2.VitaminD;
            r.VitaminD2 = f1.VitaminD2 + f2.VitaminD2;
            r.VitaminD3 = f1.VitaminD3 + f2.VitaminD3;
            r.Cryptoxanthin = f1.Cryptoxanthin + f2.Cryptoxanthin;
            r.Lycopene = f1.Lycopene + f2.Lycopene;
            r.LuteinPlusZeaxanthin = f1.LuteinPlusZeaxanthin + f2.LuteinPlusZeaxanthin;
            r.VitaminC = f1.VitaminC + f2.VitaminC;
            r.Thiamin = f1.Thiamin + f2.Thiamin;
            r.Riboflavin = f1.Riboflavin + f2.Riboflavin;
            r.Niacin = f1.Niacin + f2.Niacin;
            r.PantothenicAcid = f1.PantothenicAcid + f2.PantothenicAcid;
            r.VitaminB6 = f1.VitaminB6 + f2.VitaminB6;
            r.FolateTotal = f1.FolateTotal + f2.FolateTotal;
            r.VitaminB12 = f1.VitaminB12 + f2.VitaminB12;
            r.Choline = f1.Choline + f2.Choline;
            r.Menaquinone4 = f1.Menaquinone4 + f2.Menaquinone4;
            r.Dihydrophylloquinone = f1.Dihydrophylloquinone + f2.Dihydrophylloquinone;
            r.VitaminK = f1.VitaminK + f2.VitaminK;
            r.FolicAcid = f1.FolicAcid + f2.FolicAcid;
            r.FolateFood = f1.FolateFood + f2.FolateFood;
            r.Betaine = f1.Betaine + f2.Betaine;
            r.Tryptophan = f1.Tryptophan + f2.Tryptophan;
            r.Threonine = f1.Threonine + f2.Threonine;
            r.Isoleucine = f1.Isoleucine + f2.Isoleucine;
            r.Leucine = f1.Leucine + f2.Leucine;
            r.Lysine = f1.Lysine + f2.Lysine;
            r.Methionine = f1.Methionine + f2.Methionine;
            r.Cystine = f1.Cystine + f2.Cystine;
            r.Phenylalanine = f1.Phenylalanine + f2.Phenylalanine;
            r.Tyrosine = f1.Tyrosine + f2.Tyrosine;
            r.Valine = f1.Valine + f2.Valine;
            r.Arginine = f1.Arginine + f2.Arginine;
            r.Histidine = f1.Histidine + f2.Histidine;
            r.Alanine = f1.Alanine + f2.Alanine;
            r.AsparticAcid = f1.AsparticAcid + f2.AsparticAcid;
            r.GlutamicAcid = f1.GlutamicAcid + f2.GlutamicAcid;
            r.Glycine = f1.Glycine + f2.Glycine;
            r.Proline = f1.Proline + f2.Proline;
            r.Serine = f1.Serine + f2.Serine;
            r.Hydroxyproline = f1.Hydroxyproline + f2.Hydroxyproline;
            r.VitaminEAdded = f1.VitaminEAdded + f2.VitaminEAdded;
            r.VitaminB12Added = f1.VitaminB12Added + f2.VitaminB12Added;
            r.Cholesterol = f1.Cholesterol + f2.Cholesterol;
            r.FattyAcidsTrans = f1.FattyAcidsTrans + f2.FattyAcidsTrans;
            r.FattyAcidsSaturated = f1.FattyAcidsSaturated + f2.FattyAcidsSaturated;
            r.Phytosterols = f1.Phytosterols + f2.Phytosterols;
            r.Stigmasterol = f1.Stigmasterol + f2.Stigmasterol;
            r.Campesterol = f1.Campesterol + f2.Campesterol;
            r.BetaSitosterol = f1.BetaSitosterol + f2.BetaSitosterol;
            r.FattyAcidsMonounsaturated = f1.FattyAcidsMonounsaturated + f2.FattyAcidsMonounsaturated;
            r.FattyAcidsPolyunsaturated = f1.FattyAcidsPolyunsaturated + f2.FattyAcidsPolyunsaturated;
            r.FattyAcidsTransMonoenoic = f1.FattyAcidsTransMonoenoic + f2.FattyAcidsTransMonoenoic;
            r.FattyAcidsTransPolyenoic = f1.FattyAcidsTransPolyenoic + f2.FattyAcidsTransPolyenoic;
            r.AlphaLinolenicAcid = f1.AlphaLinolenicAcid + f2.AlphaLinolenicAcid;
            r.LinoleicAcid = f1.LinoleicAcid + f2.LinoleicAcid;
            r.DocosahexaenoicAcid = f1.DocosahexaenoicAcid + f2.DocosahexaenoicAcid;
            r.GammaLinolenicAcid = f1.GammaLinolenicAcid + f2.GammaLinolenicAcid;
            r.EicosapentaenoicAcid = f1.EicosapentaenoicAcid + f2.EicosapentaenoicAcid;
            return r;
        }

        // Operator overload to allow multiplying a FoodData object with a double
        // This is intended for adjusting nutrient totals in a FoodData object based on quantity and unit
        public static FoodData operator *(FoodData f1, double c)
        {
            FoodData r = new FoodData();

            // Since a new FoodData item is being created copy the units to it
            CopyUnits(f1, r);
            r.FoodName = "";
            r.FoodNumber = "";
            r.Protein = f1.Protein * c;
            r.TotalLipids = f1.TotalLipids * c;
            r.Carbohydrates = f1.Carbohydrates * c;
            r.Ash = f1.Ash * c;
            r.EnergyKCal = f1.EnergyKCal * c;
            r.Starch = f1.Starch * c;
            r.Sucrose = f1.Sucrose * c;
            r.Glucose = f1.Glucose * c;
            r.Fructose = f1.Fructose * c;
            r.Lactose = f1.Lactose * c;
            r.Maltose = f1.Maltose * c;
            r.Alcohol = f1.Alcohol * c;
            r.AdjustedProtein = f1.AdjustedProtein * c;
            r.Water = f1.Water * c;
            r.Caffeine = f1.Caffeine * c;
            r.Theobromine = f1.Theobromine * c;
            r.EnergyKJ = f1.EnergyKJ * c;
            r.TotalSugars = f1.TotalSugars * c;
            r.Galactose = f1.Galactose * c;
            r.TotalFiber = f1.TotalFiber * c;
            r.Calcium = f1.Calcium * c;
            r.Iron = f1.Iron * c;
            r.Magnesium = f1.Magnesium * c;
            r.Phosphorus = f1.Phosphorus * c;
            r.Potassium = f1.Potassium * c;
            r.Sodium = f1.Sodium * c;
            r.Zinc = f1.Zinc * c;
            r.Copper = f1.Copper * c;
            r.Fluoride = f1.Fluoride * c;
            r.Manganese = f1.Manganese * c;
            r.Selenium = f1.Selenium * c;
            r.VitaminAIU = f1.VitaminAIU * c;
            r.Retinol = f1.Retinol * c;
            r.VitaminARAE = f1.VitaminARAE * c;
            r.BetaCarotene = f1.BetaCarotene * c;
            r.AlphaCarotene = f1.AlphaCarotene * c;
            r.VitaminE = f1.VitaminE * c;
            r.VitaminD = f1.VitaminD * c;
            r.VitaminD2 = f1.VitaminD2 * c;
            r.VitaminD3 = f1.VitaminD3 * c;
            r.Cryptoxanthin = f1.Cryptoxanthin * c;
            r.Lycopene = f1.Lycopene * c;
            r.LuteinPlusZeaxanthin = f1.LuteinPlusZeaxanthin * c;
            r.VitaminC = f1.VitaminC * c;
            r.Thiamin = f1.Thiamin * c;
            r.Riboflavin = f1.Riboflavin * c;
            r.Niacin = f1.Niacin * c;
            r.PantothenicAcid = f1.PantothenicAcid * c;
            r.VitaminB6 = f1.VitaminB6 * c;
            r.FolateTotal = f1.FolateTotal * c;
            r.VitaminB12 = f1.VitaminB12 * c;
            r.Choline = f1.Choline * c;
            r.Menaquinone4 = f1.Menaquinone4 * c;
            r.Dihydrophylloquinone = f1.Dihydrophylloquinone * c;
            r.VitaminK = f1.VitaminK * c;
            r.FolicAcid = f1.FolicAcid * c;
            r.FolateFood = f1.FolateFood * c;
            r.Betaine = f1.Betaine * c;
            r.Tryptophan = f1.Tryptophan * c;
            r.Threonine = f1.Threonine * c;
            r.Isoleucine = f1.Isoleucine * c;
            r.Leucine = f1.Leucine * c;
            r.Lysine = f1.Lysine * c;
            r.Methionine = f1.Methionine * c;
            r.Cystine = f1.Cystine * c;
            r.Phenylalanine = f1.Phenylalanine * c;
            r.Tyrosine = f1.Tyrosine * c;
            r.Valine = f1.Valine * c;
            r.Arginine = f1.Arginine * c;
            r.Histidine = f1.Histidine * c;
            r.Alanine = f1.Alanine * c;
            r.AsparticAcid = f1.AsparticAcid * c;
            r.GlutamicAcid = f1.GlutamicAcid * c;
            r.Glycine = f1.Glycine * c;
            r.Proline = f1.Proline * c;
            r.Serine = f1.Serine * c;
            r.Hydroxyproline = f1.Hydroxyproline * c;
            r.VitaminEAdded = f1.VitaminEAdded * c;
            r.VitaminB12Added = f1.VitaminB12Added * c;
            r.Cholesterol = f1.Cholesterol * c;
            r.FattyAcidsTrans = f1.FattyAcidsTrans * c;
            r.FattyAcidsSaturated = f1.FattyAcidsSaturated * c;
            r.Phytosterols = f1.Phytosterols * c;
            r.Stigmasterol = f1.Stigmasterol * c;
            r.Campesterol = f1.Campesterol * c;
            r.BetaSitosterol = f1.BetaSitosterol * c;
            r.FattyAcidsMonounsaturated = f1.FattyAcidsMonounsaturated * c;
            r.FattyAcidsPolyunsaturated = f1.FattyAcidsPolyunsaturated * c;
            r.FattyAcidsTransMonoenoic = f1.FattyAcidsTransMonoenoic * c;
            r.FattyAcidsTransPolyenoic = f1.FattyAcidsTransPolyenoic * c;
            r.AlphaLinolenicAcid = f1.AlphaLinolenicAcid * c;
            r.LinoleicAcid = f1.LinoleicAcid * c;
            r.DocosahexaenoicAcid = f1.DocosahexaenoicAcid * c;
            r.GammaLinolenicAcid = f1.GammaLinolenicAcid * c;
            r.EicosapentaenoicAcid = f1.EicosapentaenoicAcid * c;
            return r;
        }

        // Static method to copy units from one FoodData object to another
        private static void CopyUnits(FoodData from, FoodData to)
        {
            to.FoodName = from.FoodName;
            to.FoodNumber = from.FoodNumber;
            to.ProteinUnit = from.ProteinUnit;
            to.TotalLipidsUnit = from.TotalLipidsUnit;
            to.CarbohydratesUnit = from.CarbohydratesUnit;
            to.AshUnit = from.AshUnit;
            to.EnergyKCalUnit = from.EnergyKCalUnit;
            to.StarchUnit = from.StarchUnit;
            to.SucroseUnit = from.SucroseUnit;
            to.GlucoseUnit = from.GlucoseUnit;
            to.FructoseUnit = from.FructoseUnit;
            to.LactoseUnit = from.LactoseUnit;
            to.MaltoseUnit = from.MaltoseUnit;
            to.AlcoholUnit = from.AlcoholUnit;
            to.AdjustedProteinUnit = from.AdjustedProteinUnit;
            to.WaterUnit = from.WaterUnit;
            to.CaffeineUnit = from.CaffeineUnit;
            to.TheobromineUnit = from.TheobromineUnit;
            to.EnergyKJUnit = from.EnergyKJUnit;
            to.TotalSugarsUnit = from.TotalSugarsUnit;
            to.GalactoseUnit = from.GalactoseUnit;
            to.TotalFiberUnit = from.TotalFiberUnit;
            to.CalciumUnit = from.CalciumUnit;
            to.IronUnit = from.IronUnit;
            to.MagnesiumUnit = from.MagnesiumUnit;
            to.PhosphorusUnit = from.PhosphorusUnit;
            to.PotassiumUnit = from.PotassiumUnit;
            to.SodiumUnit = from.SodiumUnit;
            to.ZincUnit = from.ZincUnit;
            to.CopperUnit = from.CopperUnit;
            to.FluorideUnit = from.FluorideUnit;
            to.ManganeseUnit = from.ManganeseUnit;
            to.SeleniumUnit = from.SeleniumUnit;
            to.VitaminAIUUnit = from.VitaminAIUUnit;
            to.RetinolUnit = from.RetinolUnit;
            to.VitaminARAEUnit = from.VitaminARAEUnit;
            to.BetaCaroteneUnit = from.BetaCaroteneUnit;
            to.AlphaCaroteneUnit = from.AlphaCaroteneUnit;
            to.VitaminEUnit = from.VitaminEUnit;
            to.VitaminDUnit = from.VitaminDUnit;
            to.VitaminD2Unit = from.VitaminD2Unit;
            to.VitaminD3Unit = from.VitaminD3Unit;
            to.CryptoxanthinUnit = from.CryptoxanthinUnit;
            to.LycopeneUnit = from.LycopeneUnit;
            to.LuteinPlusZeaxanthinUnit = from.LuteinPlusZeaxanthinUnit;
            to.VitaminCUnit = from.VitaminCUnit;
            to.ThiaminUnit = from.ThiaminUnit;
            to.RiboflavinUnit = from.RiboflavinUnit;
            to.NiacinUnit = from.NiacinUnit;
            to.PantothenicAcidUnit = from.PantothenicAcidUnit;
            to.VitaminB6Unit = from.VitaminB6Unit;
            to.FolateTotalUnit = from.FolateTotalUnit;
            to.VitaminB12Unit = from.VitaminB12Unit;
            to.CholineUnit = from.CholineUnit;
            to.Menaquinone4Unit = from.Menaquinone4Unit;
            to.DihydrophylloquinoneUnit = from.DihydrophylloquinoneUnit;
            to.VitaminKUnit = from.VitaminKUnit;
            to.FolicAcidUnit = from.FolicAcidUnit;
            to.FolateFoodUnit = from.FolateFoodUnit;
            to.BetaineUnit = from.BetaineUnit;
            to.TryptophanUnit = from.TryptophanUnit;
            to.ThreonineUnit = from.ThreonineUnit;
            to.IsoleucineUnit = from.IsoleucineUnit;
            to.LeucineUnit = from.LeucineUnit;
            to.LysineUnit = from.LysineUnit;
            to.MethionineUnit = from.MethionineUnit;
            to.CystineUnit = from.CystineUnit;
            to.PhenylalanineUnit = from.PhenylalanineUnit;
            to.TyrosineUnit = from.TyrosineUnit;
            to.ValineUnit = from.ValineUnit;
            to.ArginineUnit = from.ArginineUnit;
            to.HistidineUnit = from.HistidineUnit;
            to.AlanineUnit = from.AlanineUnit;
            to.AsparticAcidUnit = from.AsparticAcidUnit;
            to.GlutamicAcidUnit = from.GlutamicAcidUnit;
            to.GlycineUnit = from.GlycineUnit;
            to.ProlineUnit = from.ProlineUnit;
            to.SerineUnit = from.SerineUnit;
            to.HydroxyprolineUnit = from.HydroxyprolineUnit;
            to.VitaminEAddedUnit = from.VitaminEAddedUnit;
            to.VitaminB12AddedUnit = from.VitaminB12AddedUnit;
            to.CholesterolUnit = from.CholesterolUnit;
            to.FattyAcidsTransUnit = from.FattyAcidsTransUnit;
            to.FattyAcidsSaturatedUnit = from.FattyAcidsSaturatedUnit;
            to.PhytosterolsUnit = from.PhytosterolsUnit;
            to.StigmasterolUnit = from.StigmasterolUnit;
            to.CampesterolUnit = from.CampesterolUnit;
            to.BetaSitosterolUnit = from.BetaSitosterolUnit;
            to.FattyAcidsMonounsaturatedUnit = from.FattyAcidsMonounsaturatedUnit;
            to.FattyAcidsPolyunsaturatedUnit = from.FattyAcidsPolyunsaturatedUnit;
            to.FattyAcidsTransMonoenoicUnit = from.FattyAcidsTransMonoenoicUnit;
            to.FattyAcidsTransPolyenoicUnit = from.FattyAcidsTransPolyenoicUnit;
            to.AlphaLinolenicAcidUnit = from.AlphaLinolenicAcidUnit;
            to.LinoleicAcidUnit = from.LinoleicAcidUnit;
            to.DocosahexaenoicAcidUnit = from.DocosahexaenoicAcidUnit;
            to.GammaLinolenicAcidUnit = from.GammaLinolenicAcidUnit;
            to.EicosapentaenoicAcidUnit = from.EicosapentaenoicAcidUnit;
        }
    }
}
