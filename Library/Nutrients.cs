using System;
using System.Reflection;

namespace DietApplication
{
    public class Nutrients
    {
        public Nutrient Protein { get; set; }
        public Nutrient TotalLipids { get; set; }
        public Nutrient Carbohydrates { get; set; }
        public Nutrient Ash { get; set; }
        public Nutrient EnergyKCal { get; set; }
        public Nutrient Starch { get; set; }
        public Nutrient Sucrose { get; set; }
        public Nutrient Glucose { get; set; }
        public Nutrient Fructose { get; set; }
        public Nutrient Lactose { get; set; }
        public Nutrient Maltose { get; set; }
        public Nutrient Alcohol { get; set; }
        public Nutrient AdjustedProtein { get; set; }
        public Nutrient Water { get; set; }
        public Nutrient Caffeine { get; set; }
        public Nutrient Theobromine { get; set; }
        public Nutrient EnergyKJ { get; set; }
        public Nutrient TotalSugars { get; set; }
        public Nutrient Galactose { get; set; }
        public Nutrient TotalFiber { get; set; }
        public Nutrient Calcium { get; set; }
        public Nutrient Iron { get; set; }
        public Nutrient Magnesium { get; set; }
        public Nutrient Phosphorus { get; set; }
        public Nutrient Potassium { get; set; }
        public Nutrient Sodium { get; set; }
        public Nutrient Zinc { get; set; }
        public Nutrient Copper { get; set; }
        public Nutrient Fluoride { get; set; }
        public Nutrient Manganese { get; set; }
        public Nutrient Selenium { get; set; }
        public Nutrient VitaminAIU { get; set; }
        public Nutrient Retinol { get; set; }
        public Nutrient VitaminARAE { get; set; }
        public Nutrient BetaCarotene { get; set; }
        public Nutrient AlphaCarotene { get; set; }
        public Nutrient VitaminE { get; set; }
        public Nutrient VitaminD { get; set; }
        public Nutrient VitaminD2 { get; set; }
        public Nutrient VitaminD3 { get; set; }
        public Nutrient Cryptoxanthin { get; set; }
        public Nutrient Lycopene { get; set; }
        public Nutrient LuteinPlusZeaxanthin { get; set; }
        public Nutrient VitaminC { get; set; }
        public Nutrient Thiamin { get; set; }
        public Nutrient Riboflavin { get; set; }
        public Nutrient Niacin { get; set; }
        public Nutrient PantothenicAcid { get; set; }
        public Nutrient VitaminB6 { get; set; }
        public Nutrient FolateTotal { get; set; }
        public Nutrient VitaminB12 { get; set; }
        public Nutrient Choline { get; set; }
        public Nutrient Menaquinone4 { get; set; }
        public Nutrient Dihydrophylloquinone { get; set; }
        public Nutrient VitaminK { get; set; }
        public Nutrient FolicAcid { get; set; }
        public Nutrient FolateFood { get; set; }
        public Nutrient Betaine { get; set; }
        public Nutrient Tryptophan { get; set; }
        public Nutrient Threonine { get; set; }
        public Nutrient Isoleucine { get; set; }
        public Nutrient Leucine { get; set; }
        public Nutrient Lysine { get; set; }
        public Nutrient Methionine { get; set; }
        public Nutrient Cystine { get; set; }
        public Nutrient Phenylalanine { get; set; }
        public Nutrient Tyrosine { get; set; }
        public Nutrient Valine { get; set; }
        public Nutrient Arginine { get; set; }
        public Nutrient Histidine { get; set; }
        public Nutrient Alanine { get; set; }
        public Nutrient AsparticAcid { get; set; }
        public Nutrient GlutamicAcid { get; set; }
        public Nutrient Glycine { get; set; }
        public Nutrient Proline { get; set; }
        public Nutrient Serine { get; set; }
        public Nutrient Hydroxyproline { get; set; }
        public Nutrient VitaminEAdded { get; set; }
        public Nutrient VitaminB12Added { get; set; }
        public Nutrient Cholesterol { get; set; }
        public Nutrient FattyAcidsTrans { get; set; }
        public Nutrient FattyAcidsSaturated { get; set; }
        public Nutrient Phytosterols { get; set; }
        public Nutrient Stigmasterol { get; set; }
        public Nutrient Campesterol { get; set; }
        public Nutrient BetaSitosterol { get; set; }
        public Nutrient FattyAcidsMonounsaturated { get; set; }
        public Nutrient FattyAcidsPolyunsaturated { get; set; }
        public Nutrient FattyAcidsTransMonoenoic { get; set; }
        public Nutrient FattyAcidsTransPolyenoic { get; set; }
        public Nutrient AlphaLinolenicAcid { get; set; }
        public Nutrient LinoleicAcid { get; set; }
        public Nutrient DocosahexaenoicAcid { get; set; }
        public Nutrient GammaLinolenicAcid { get; set; }
        public Nutrient EicosapentaenoicAcid { get; set; }

        public static Nutrients operator +(Nutrients n1, Nutrients n2)
        {
            Nutrients added = new Nutrients();

            // Add individual nutrients here...

            return added;
        }

        public static Nutrients operator *(Nutrients n1, double factor)
        {
            Nutrients multiplied = new Nutrients();

            // Add individual nutrients here...

            return multiplied;
        }

        public static Status CopyUnits(Nutrients n1, Nutrients n2)
        {
            Status s = new Status();

            // Copy individual nutrients here...

            return s;
        }

        public static Nutrients Round(Nutrients n1, int fractionalDigits)
        {
            Nutrients rounded = new Nutrients();

            // Round individual nutrients here...

            return rounded;
        }
    }

    public struct Nutrient
    {
        double Value;
        string Unit;
    }
}